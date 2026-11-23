using System;
using System.Threading;
using System.Timers;
using System.Diagnostics;
using System.IO;
using Nanocom.IO;

namespace Nanocom.Control
{
    public class Connection : Context
    {
        System.Threading.SynchronizationContext _sync;
        private AutomaticPortChange _portChange;
        private Port _port;
        private FrameProtocol _frameProtocol;
        private Frame.Type _lastFrameType = Frame.Type.None;
        System.Timers.Timer _timer;
        byte[] _command;
        CounterValueProvider[] _valueProviders;
        private int _frameCounter=0;
    
        public Connection(System.Threading.SynchronizationContext sync_)
            : base(ConnectionBaseState.StateStopped())
        {
            _command = new byte[0];
            _valueProviders = new CounterValueProvider[23];
            for (int i = 0; i < _valueProviders.Length; i++ ) _valueProviders[i] = new CounterValueProvider();
            _sync = sync_;
            _timer = new System.Timers.Timer();
            _timer.Elapsed += new ElapsedEventHandler(ElapsedAsync);
            _frameProtocol = new FrameProtocol();
            _port = new Nanocom.IO.Port(sync_);
            System.IO.Ports.SerialPort serialPort = _port.Serial;

            serialPort.BaudRate = 57600;
            serialPort.DataBits = 8;
            serialPort.StopBits = System.IO.Ports.StopBits.One;
            serialPort.Parity = System.IO.Ports.Parity.None;

            // Set the read/write timeouts
            // serialPort.ReadTimeout = 500;
            serialPort.WriteTimeout = 500 /*ms*/;
            // default Buffer size = 2048
            //serialPort.WriteBufferSize = 1024; // >= 256
            //serialPort.ReadBufferSize = 1024; // >= 256

            _port.DataReceived += new System.EventHandler(PortDataReceived);
            _port.DataWritten += new System.EventHandler(PortDataWritten);
            _portChange = new AutomaticPortChange( sync_ );
            _portChange.DeviceChanged += new EventHandler(PortChanged);
            Start();
        }

        public Frame.Type LastFrameType
        {
            get
            {
                return _lastFrameType;
            }
            set
            {
                _lastFrameType = value;
            }
        }

        public System.Timers.Timer Timer
        {
            get
            {
                return _timer;
            }
            set
            {
                _timer = value;
            }
        }

        public Nanocom.IO.Port Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
            }
        }

        public byte[] Command
        {
            get
            {
                return _command;
            }
            set
            {
                _command = value;
            }
        }

        public int FrameCounter
        {
            get
            {
                return _frameCounter;
            }
            set
            {
                _frameCounter=value;
            }
        }

        public CounterValueProvider[] ValueProviders
        {
            get
            {
                return _valueProviders;
            }
        }

        public byte[] ConsumeCommand()
        {
            byte[] cmd = Command;
            Command = new byte[0];
            return cmd;
        }
        public void Start()
        {
            Trace.WriteLine("Connection.Start enter");
            State().OnStart(this);
            Trace.WriteLine("Connection.Start leave");
        }
        public void Stop() 
        {
            Trace.WriteLine("Connection.Stop enter");
            State().OnStop(this);
            Trace.WriteLine("Connection.Stop enter");
        }
        public void Pause()
        {
            Trace.WriteLine("Connection.Pause enter");
            OnPause();
            Trace.WriteLine("Connection.Pause leave");
        }

        public void Continue()
        {
            Trace.WriteLine("Connection.Continue enter");
            OnContinue();
            Trace.WriteLine("Connection.Continue leave");
        }
        public ConnectionBaseState State() { return CurrentState() as ConnectionBaseState; }
        void OnConnect(string portName_) {  State().OnConnect(this,portName_); }
        void OnNotReady() { State().OnNotReady(this); }
        void OnDisconnect() { State().OnDisconnect(this); }
        void OnFrame(Frame frame_) { State().OnFrame(this, frame_); }
        void OnTimeout(object e_ ) { State().OnTimeout(this); }
        void OnPause() { State().OnPause(this); }
        void OnContinue() { State().OnContinue(this); }

        internal void DoStartPortNotifications()
        {
            _portChange.StartNotification();
        }
        internal void DoStopPortNotifications()
        {
            _portChange.StopNotification();
        }
        internal void DoResetProtocol()
        {
            _frameProtocol.Reset();  
        }
        internal void DoSend(Frame frame_)
        {
            byte[] frameBytes = FrameProtocol.Encode(frame_);
            Debug.WriteLine(String.Format("TX<-- {0}", frame_.ToString()));
            Dump("<--", frameBytes);
            _port.Serial.Write(frameBytes, 0, frameBytes.Length);
        }
        internal void DoPost(Frame frame_)
        {
            byte[] frameBytes = FrameProtocol.Encode(frame_);
            Debug.WriteLine(String.Format("Tx<-- {0}", frame_.ToString()));
            Dump("<--", frameBytes);
            _port.InitiateWrite(frameBytes, 0, frameBytes.Length);
        }
        /// <summary>
        /// Dumps a hex output of the Buffer
        /// </summary>
        /// <param name="buffer_"></param>
        internal static void Dump(string message_, byte[] buffer_)
        {
            StringWriter dump = new StringWriter();
            dump.Write(String.Format("{0}:", message_));
            foreach (byte b in buffer_)
            {
                dump.Write(String.Format("{0} ", b.ToString("X2")));
            }
            Debug.WriteLine(dump.ToString());
        }

        private void ElapsedAsync(object sender_, EventArgs e_ ) 
        {
            if (_sync != null)
            {
                _sync.Post(new System.Threading.SendOrPostCallback(OnTimeout), e_);
            }
        }

      

        private void PortDataReceived(object sender_, EventArgs e_)
        {
            Nanocom.IO.Port port = (Nanocom.IO.Port)sender_;
            //Debug.WriteLine("{0}: PortDataReceived form {1}", Thread.CurrentThread.ManagedThreadId.ToString(),port.PortName);
            if (e_ is System.IO.Ports.SerialDataReceivedEventArgs)
            {
                if( port.IsOpen )
                {
                    System.IO.Ports.SerialDataReceivedEventArgs e = (System.IO.Ports.SerialDataReceivedEventArgs)e_;
                    switch( e.EventType )
                    {
                    case System.IO.Ports.SerialData.Chars:
                       {
                           int bytesToRead = port.Serial.BytesToRead;
                           //Debug.WriteLine("System.IO.Ports.SerialData.Chars, bytes received = {0}", bytesToRead.ToString() );
                           if( bytesToRead > 0 )
                           {
                               byte [] buffer = new byte[bytesToRead];
                               port.Serial.Read(buffer, 0, bytesToRead);
                               Dump( "<--", buffer );
                               ProcessBytes(buffer);                      
                           }
                       }
                       break;
                    case System.IO.Ports.SerialData.Eof:
                       //Debug.WriteLine("System.IO.Ports.SerialData.Eof");                   
                       break;
                    }
                }
                else
                {
                    // ignore events if the port is close in the meantime
                }
                
            }
                          
        }
        private void PortDataWritten(object sender_, EventArgs e_)
        {
            Nanocom.IO.Port port = (Nanocom.IO.Port)sender_;
            //Debug.WriteLine("{0}: PortDataWritten form {1}", Thread.CurrentThread.ManagedThreadId.ToString(), port.PortName);
            if (e_ is Nanocom.IO.PortDataWrittenEventArgs)
            {
                Nanocom.IO.PortDataWrittenEventArgs e = e_ as Nanocom.IO.PortDataWrittenEventArgs;
                switch (e.EventType)
                {
                    case Nanocom.IO.PortDataWrittenEventArgs.DataType.BytesWritten:
                        {
                            int bytesToRead = port.Serial.BytesToRead;
                            //Debug.WriteLine("Nanocom.IO.PortDataWrittenEventArgs.DataType.BytesWritten = {0}", e.Count);
                            Dump("-->", e.Buffer);
                        }
                        break;
                    case Nanocom.IO.PortDataWrittenEventArgs.DataType.Timeout:
                        Debug.WriteLine("Nanocom.IO.PortDataWrittenEventArgs.DataType.Timeout");
                        break;
                    case Nanocom.IO.PortDataWrittenEventArgs.DataType.Exception:
                        Debug.WriteLine("Nanocom.IO.PortDataWrittenEventArgs.DataType.Exception");
                        break;
                }

            }
        }
        private void PortChanged(object sender_, EventArgs e_)
        {
            if (e_ is Nanocom.IO.PortChangeEventArgs)
            {
                Nanocom.IO.PortChangeEventArgs e = (Nanocom.IO.PortChangeEventArgs)e_;
                Nanocom.IO.PortChangeNotifier notifier = (Nanocom.IO.PortChangeNotifier)sender_;
                switch (e.EventType)
                {
                    case Nanocom.IO.PortChange.Arrival:
                        Debug.WriteLine(String.Format("{0}: Nanocom arrival \"{1}\"", Thread.CurrentThread.ManagedThreadId.ToString(),e.PortName));
                        OnConnect(e.PortName);
                        break;
                    case Nanocom.IO.PortChange.Removed:
                        Debug.WriteLine(String.Format("{0}: Nanocom remove", Thread.CurrentThread.ManagedThreadId.ToString()));
                        OnDisconnect();
                        break;
                }
            }
        }
        private void ProcessBytes(byte[] buffer_)
        {
            foreach (byte b in buffer_)
            {
                try
                {
                    Frame frame = _frameProtocol.Decode(b);
                    if (frame != null)
                    {
                        Debug.WriteLine(String.Format("RX--> {0}", frame.ToString()));
                        OnFrame(frame);
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.ToString());
                }
            }
        }

    }
    public abstract class ConnectionBaseState : State
    {
        public enum StateID : int { Stopped = 0, Disconnected = 1, Connected = 2, Synchronized = 3, Initializing = 4, Ready = 5, Active = 6, Paused = 9, Error = 10, NotReady = 11 }
        public abstract StateID ID();
        public virtual bool IsInitialized() { return false; }
        public virtual void OnConnect(Connection ctx_, string portName_ ) { }
        public virtual void OnNotReady(Connection ctx_) { }
        public virtual void OnDisconnect(Connection ctx_) { }
        public virtual void OnFrame(Connection ctx_, Frame frame_) { }
        public virtual void OnTimeout(Connection ctx_) { }
        public virtual void OnStart(Connection ctx_ ) { }
        public virtual void OnContinue(Connection ctx_) { ChangeState(ctx_, StateDisconnected()); }
        public virtual void OnPause(Connection ctx_) { ChangeState(ctx_, StatePaused()); }
        public virtual void OnStop(Connection ctx_) { ChangeState(ctx_, StateStopped()); }
        internal protected void ChangeState(Connection ctx_, ConnectionBaseState newState_) 
        {
            Trace.WriteLine(String.Format("ChangeState From {0}--> {1}", Enum.GetName(typeof(StateID), ctx_.State().ID()),
                                                                         Enum.GetName(typeof(StateID), newState_.ID())));
            ctx_.ChangeState(newState_);
            // set the new connection state
            ctx_.ValueProviders[0].Value = (int)(newState_.ID());
            Trace.WriteLine(String.Format("Connection Status set to {0}", (int)(newState_.ID())));
        }

        static public ConnectionBaseState _stateDisconnected = new ConnectionStateDisconnected();
        static public ConnectionBaseState _stateConnected = new ConnectionStateConnected();
        static public ConnectionBaseState _stateSynchronized = new ConnectionStateSynchronized();
        static public ConnectionBaseState _stateInitializing = new ConnectionStateInitializing();
        static public ConnectionBaseState _stateReady = new ConnectionStateReady();
        static public ConnectionBaseState _stateActive = new ConnectionStateActive();
        static public ConnectionBaseState _statePaused = new ConnectionStatePaused();
        static public ConnectionBaseState _stateError = new ConnectionStateError();
        static public ConnectionBaseState _stateNotReady = new ConnectionStateNotReady();
        static public ConnectionBaseState _stateStopped = new ConnectionStateStopped();
        static public ConnectionBaseState StateDisconnected() { return _stateDisconnected; }
        static public ConnectionBaseState StateConnected() { return _stateConnected; }
        static public ConnectionBaseState StateSynchronized() { return _stateSynchronized; }
        static public ConnectionBaseState StateInitializing() { return _stateInitializing; }
        static public ConnectionBaseState StateReady() { return _stateReady; }
        static public ConnectionBaseState StatePaused() { return _statePaused; }
        static public ConnectionBaseState StateActive() { return _stateActive; }
        static public ConnectionBaseState StateError() { return _stateError; }
        static public ConnectionBaseState StateNotReady() { return _stateNotReady; }
        static public ConnectionBaseState StateStopped() { return _stateStopped; }
    }

    abstract class ConnectionStateNotOpen : ConnectionBaseState
    {
        public override void OnConnect(Connection ctx_, string portName_ )
        {
            try
            {
                ctx_.Port.PortName = portName_;
                ctx_.Port.Open();
                ChangeState(ctx_, StateConnected());
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                ChangeState(ctx_, StateNotReady());
            }
        }
    }

    abstract class ConnectionStateOpen : ConnectionBaseState
    {
        public override void OnDisconnect(Connection ctx_)
        {
            ctx_.Port.Close();
            ChangeState(ctx_, StateDisconnected());
        }
        public override void OnFrame(Connection ctx_, Frame frame_)
        {
            switch( frame_.TypeID )
            {
            case Frame.Type.Init:
                ctx_.DoSend(new Frame(Frame.Type.Ok, 1));
                if (ctx_.LastFrameType != frame_.TypeID)
                {
                    ChangeState(ctx_, StateInitializing() );
                }
                if ( frame_.Number == 1)
                {
                    ChangeState(ctx_, StateReady() );
                }
                break;
            case Frame.Type.Hallo:
            case Frame.Type.StatusReq:
            case Frame.Type.ObjectData:
                {
                    Frame answer = new Frame(Frame.Type.StatusAnswer, 1);
                    byte[] cmd = ctx_.ConsumeCommand();
                    answer.AddByte(cmd.Length > 0 ? cmd[0] : (byte)0xFF);
                    answer.AddByte(cmd.Length > 1 ? cmd[1] : (byte)0xFF);
                    answer.AddByte(cmd.Length > 2 ? cmd[2] : (byte)0xFF);
                    answer.AddByte(0xFF);
                    answer.AddByte(0xFF);
                    answer.AddByte((byte)( this.IsInitialized() ? 0x01 : 0xFF));
                    answer.AddByte((byte)'^');
                    ctx_.DoSend(answer);
                }
                break;
            case Frame.Type.StandbyReset:
                {
                    Frame ok0 = new Frame(Frame.Type.Ok, 1);
                    ok0.AddByte(0xFF);
                    ok0.AddByte(0xFF);
                    ok0.AddByte(0xFF);
                    ctx_.DoSend(ok0);
                }
                break;
            case Frame.Type.Box:
                //System.Windows.MessageBox.Show("Box: {}", frame_.Text);
                ctx_.DoSend(new Frame(Frame.Type.Ok, 1));
                break;
            case Frame.Type.BoxReset:
                //System.Windows.MessageBox.Hide();
                ctx_.DoSend(new Frame(Frame.Type.Ok, 1));
                break;

            default:
                ctx_.DoSend(new Frame(Frame.Type.Ok, 1) );
                break;
            }
            ctx_.LastFrameType = frame_.TypeID;
        }
    }

    class ConnectionStateDisconnected : ConnectionStateNotOpen
    {
        public override StateID ID() { return StateID.Disconnected; }
        public override void EntryAction( Context ctx_ )
        {
            Connection ctx = ctx_ as Connection;
            ctx.Port.Close();
            ctx.DoStartPortNotifications();
        } 
    }

    class ConnectionStateConnected : ConnectionStateOpen
    {
        public override StateID ID() { return StateID.Connected; }
        public override void EntryAction(Context ctx_)
        {
            Connection ctx = ctx_ as Connection;
            ctx.DoResetProtocol();
            ctx.LastFrameType = Frame.Type.None;
        }
        public override void OnFrame(Connection ctx_, Frame frame_)
        {
            switch( frame_.TypeID )
            {
            case Frame.Type.Hallo:
                // send a hello answer
                ctx_.DoSend(new Frame(Frame.Type.Hallo, 1) );
                ChangeState( ctx_, StateSynchronized());
                break;
            default:
                ChangeState( ctx_, StateSynchronized() );
                StateSynchronized().OnFrame( ctx_, frame_ );
                break;
            }
        }
    }

    class ConnectionStateSynchronized : ConnectionStateOpen
    {
        public override StateID ID() { return StateID.Synchronized; }
    }

    class ConnectionStateNotReady : ConnectionStateNotOpen
    {
        public override StateID ID() { return StateID.NotReady; }
        public override void EntryAction(Context ctx_)
        {
            Connection ctx = ctx_ as Connection;
            ctx.Timer.Interval = 1000/*ms*/;
            ctx.Timer.Start();
        }
        public override void ExitAction(Context ctx_)
        {
            Connection ctx = ctx_ as Connection;
            ctx.Timer.Stop();
        }
        public override void OnTimeout(Connection ctx_)
        {
            if( ctx_.Port.PortName == null )
                ctx_.Port.PortName = AutomaticPortChange.nanocomPortName();
            OnConnect(ctx_, ctx_.Port.PortName);
        }
    }
    
    class ConnectionStateInitializing : ConnectionStateOpen
    {
        public override StateID ID() { return StateID.Initializing; }
    }
    
    class ConnectionStateReady : ConnectionStateOpen
    {
        public override bool IsInitialized() { return true; }
        public override StateID ID() { return StateID.Ready; }
        public override void EntryAction(Context ctx_)
        {
            Connection ctx = ctx_ as Connection;
            ctx.FrameCounter  = 0;
        }
        public override void OnFrame(Connection ctx_, Frame frame_)
        {
            switch( frame_.TypeID )
            {
            case Frame.Type.Hallo:
            case Frame.Type.StatusReq:
                ctx_.FrameCounter++;
                base.OnFrame(ctx_, frame_);
                if (ctx_.FrameCounter > 3)
                {
                    ChangeState(ctx_, StateActive());
                }
                break;
            default:
                base.OnFrame(ctx_, frame_);
                break;
            }
        }
    }

    class ConnectionStateActive : ConnectionStateOpen
    {
        public override bool IsInitialized() { return true; }
        public override StateID ID() { return StateID.Active; }
        public override void EntryAction(Context ctx_)
        {
            Connection ctx = ctx_ as Connection;
            ctx.Command = new byte[] { 0x04, 0x03 };
            ctx.FrameCounter = 0;
            ctx.Timer.Interval = 5 * 1000;
            ctx.Timer.Start();
        }
        public override void ExitAction(Context ctx_)
        {
            Connection ctx = ctx_ as Connection;
            ctx.Timer.Stop();
        }
        public override void OnFrame(Connection ctx_, Frame frame_)
        {
            if( frame_.TypeID ==  Frame.Type.ObjectData )
            {
                byte b0 = frame_.Buffer[0];
                byte b1 = frame_.Buffer[1];
                if( b0 == 0x01 && b1 == 0x16 )
                {
                    ctx_.FrameCounter++;
                    string text = frame_.Text(2,-2);
                    System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("\\|");
                    string[] values = regex.Split(text);
                    CounterValueProvider[] vps = ctx_.ValueProviders;
                    for (int i = 0; i < values.Length && ((i+1)<(vps.Length)); i++)
                    {
                        vps[i + 1].Value = Convert.ToSingle(values[i],System.Globalization.CultureInfo.InvariantCulture);
                    }
                }
            }
            base.OnFrame(ctx_, frame_);
        }
        public override void OnTimeout(Connection ctx_)
        {
            // if we can't get a data frame within 5 secs there must be an ECU error
            if( ctx_.FrameCounter == 0 )
                ChangeState(ctx_, StateError());
            else
                ctx_.FrameCounter = 0;
        }
    }
    
    class ConnectionStateError : ConnectionStateOpen
    {
        public override bool IsInitialized() { return true; }
        public override StateID ID() { return StateID.Error; }
        public override void EntryAction(Context ctx_)
        {
            Connection ctx = ctx_ as Connection;
            ctx.Timer.Interval = 5*1000;
            ctx.Timer.Start();
        }
        public override void ExitAction(Context ctx_)
        {
            Connection ctx = ctx_ as Connection;
            ctx.Timer.Stop();
        }
        public override void OnTimeout(Connection ctx_)
        {
            ChangeState( ctx_, StateActive() );
        }
    }
    
    class ConnectionStateStopped : ConnectionBaseState
    {
        public override StateID ID() { return StateID.Stopped; }
        public override void EntryAction( Context ctx_) 
        {
            Connection ctx = ctx_ as Connection;
            ctx.DoStopPortNotifications();
            ctx.Timer.Stop();
            ctx.Port.Close();
        }
        public override void ExitAction(Context ctx_)
        {
//            Connection ctx = ctx_ as Connection;
//            ctx.DoStartPortNotifications();
        }
        public override void OnStart(Connection ctx_)
        {
            ChangeState(ctx_, StateDisconnected());
        }
    }

    class ConnectionStatePaused : ConnectionStateStopped
    {
        public override StateID ID() { return StateID.Paused; }
    }

}
