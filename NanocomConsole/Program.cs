using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Threading;
using Nanocom.IO;
using Nanocom.Control;

namespace NanocomConsole
{
    class Program 
    {
#if true
        public class ServiceCounter
        {
            private Nanocom.Counters.Counter _counter;
            private Nanocom.Control.CounterValueProvider _vp;
            public ServiceCounter(Nanocom.Counters.Counter counter_, Nanocom.Control.CounterValueProvider provider_)
            {
                _counter = counter_;
                _vp = null;
                this.ValueProvider = provider_;
                if (_vp != null)
                    _counter.Value = _vp.Value;

            }
            private void ValueChangedInternal(object sender_, EventArgs e_)
            {
                _counter.Value = this.ValueProvider.Value;
            }
            public Nanocom.Control.CounterValueProvider ValueProvider
            {
                get
                {
                    return _vp;
                }
                set
                {
                    if (_vp != value)
                    {
                        if (_vp != null)
                            _vp.ValueChanged -= ValueChangedInternal;
                        _vp = value;
                        if (_vp != null)
                            _vp.ValueChanged += ValueChangedInternal;
                        _counter.PC.ReadOnly = value == null;
                    }
                }
            }
        };
#endif
        /// <summary>
        /// Called on every timer tick, terminates the dispatcher
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void DispatcherTimerTick(object sender, EventArgs e)
        {
            System.Windows.Threading.Dispatcher.ExitAllFrames();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
            Trace.AutoFlush = true;
            SynchronizationContext sync = new DispatcherSynchronizationContext(Dispatcher.CurrentDispatcher);
            Nanocom.Control.Connection connection = new Nanocom.Control.Connection(sync);
            Debug.WriteLine(String.Format("{0}: Main", Thread.CurrentThread.ManagedThreadId.ToString()));
#if true
            Nanocom.Control.CounterValueProvider[] valueProvider = connection.ValueProviders;
            Nanocom.Counters.Counter[] counter = Nanocom.Counters.Counter.CounterList();
            ServiceCounter[] serviceCounter = new ServiceCounter[counter.Length];
            for (int i = 0; i < serviceCounter.Length; i++) serviceCounter[i] = new ServiceCounter(counter[i], valueProvider[i]);
#endif
            try
            {

                //  DispatcherTimer setup
                DispatcherTimer terminationTimer = new DispatcherTimer();
                terminationTimer.Tick += new EventHandler(DispatcherTimerTick);
 //               terminationTimer.Interval = NanocomConsole.Properties.Settings.Default.RunTime;
                terminationTimer.Interval = TimeSpan.FromSeconds(60);
                terminationTimer.Start();
                Debug.WriteLine("Begin Run");                  
                Dispatcher.Run();
                Debug.WriteLine("Stopped Run");
            }
            catch( Exception e )
            {
                Debug.WriteLine("Exception occured");
                Debug.WriteLine(e.ToString());
            }
            finally
            {
                connection.Stop();
            }
        }        
    }
}
