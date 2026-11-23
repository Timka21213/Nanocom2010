using System;
using System.Threading;
using System.IO.Ports;

namespace Nanocom.IO
{
    public class Port
    {
        private SynchronizationContext _context = SynchronizationContext.Current;
        private SerialPort _serialPort;

        public Port( SynchronizationContext context_ )
        //---------------------------------------------------------------------------
        {
            _context = context_;
            _serialPort = new SerialPort();
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(OnSerialDataReceived);
        }



        private void OnSerialDataReceived( Object sender_, EventArgs e_ )
        //---------------------------------------------------------------------------
        {
            lock( this ) { OnDataReceived(e_); }
        }



        public event EventHandler DataReceived;

        protected void OnDataReceived( EventArgs e_ )
        //---------------------------------------------------------------------------
        {
            if( DataReceived != null )
            {
                if (_context != null)
                    _context.Post(new System.Threading.SendOrPostCallback(OnDataReceivedInternal), e_);
            }
        }

        private void OnDataReceivedInternal( object e_ )
        //---------------------------------------------------------------------------
        {
            DataReceived(this, e_ as EventArgs);
        }


        public SynchronizationContext Context
        //---------------------------------------------------------------------------
        {
            get
            {
                return _context;
            }
            set
            {
                lock( this )
                {
                    _context = value;
                }
            }
        }
        public SerialPort Serial
        {
            get
            {
                return _serialPort;
            }
       }

       public string PortName
       {
            get
            {
                return _serialPort.PortName;
            }
            set
            {
                if (_serialPort.PortName != value )
                {
                    _serialPort.Close();
                    _serialPort.PortName = value;
                }
            }
        }
       public void Open()
       {
           _serialPort.Open();
       }

       public void Close()
       {
           if( _serialPort.IsOpen )
           {
               try
               {
                   /// todo: if disconnect close throws an exception 
                   _serialPort.Close();
               }
               catch( Exception )
               {
                   
               }
           }
       }

       public void InitiateWrite( string text_ )
       {
           char [] chars = text_.ToCharArray();
           InitiateWrite( chars, 0, chars.Length );
       }
       internal  void DoWrite( object args_ )
       {
           PortDataWrittenEventArgs args = args_ as PortDataWrittenEventArgs;
           try
           {
                _serialPort.Write( args.Buffer, args.Offset, args.Count );
                args.EventType = PortDataWrittenEventArgs.DataType.BytesWritten;
           }
           catch( System.ServiceProcess.TimeoutException e )
           {
               args.EventType = PortDataWrittenEventArgs.DataType.Timeout;
               args.Exception = e;

           }
           catch( Exception e )
           {
               args.EventType = PortDataWrittenEventArgs.DataType.Exception;
               args.Exception = e;
           }
           OnDataWritten(args);
       }
       
       public void InitiateWrite( byte[] buffer_, int offset_, int count_ )
       {
           ThreadPool.QueueUserWorkItem( new WaitCallback(DoWrite), 
                                         new PortDataWrittenEventArgs( buffer_, offset_, count_ ));
       }
       public void InitiateWrite( char[] buffer_, int offset, int count_)
       {
       }
       public event EventHandler DataWritten;

       protected void OnDataWritten(EventArgs e_)
       //---------------------------------------------------------------------------
       {
           if (DataWritten != null)
           {
               if (_context != null)
                   _context.Post(new System.Threading.SendOrPostCallback(OnDataWrittenInternal), e_);
           }
       }

       private void OnDataWrittenInternal(object e_)
       //---------------------------------------------------------------------------
       {
           DataWritten(this, e_ as EventArgs);
       }

       public bool IsOpen
       {
           get
           {
               return _serialPort.IsOpen;
           }
       }
    }
}
