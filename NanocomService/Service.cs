using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Windows.Threading;
using System.Threading;
using System.Runtime.InteropServices;



namespace Nanocom.Service
{
    public partial class Service : ServiceBase
    {
        private System.Threading.Thread _thread;
        SynchronizationContext _context = null;
        Dispatcher _dispatcher = null;
        Nanocom.Control.Connection _connection = null;
        public Service()
        {
            InitializeComponent();
            Trace.WriteLine("Service constructor enter");
            Nanocom.Counters.Counter.Instanziate();
            Trace.WriteLine("Service Counter.Instanziated");
            _thread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(ThreadProc));
            Trace.WriteLine("Service thread created");
            Trace.WriteLine("Service constructor leave");
        }

        protected override void OnStart( string[] args_ )
        {
            Trace.WriteLine("Service.OnStart enter");
            //System.Diagnostics.EventLog.WriteEntry("SimpleService.OnStart", DateTime.Now.ToLongTimeString() + " - Pausing the service worker thread.");
            DoStart(args_);
            Trace.WriteLine("Service.OnStart leave");
        }

        protected override void OnStop()
        {
            Trace.WriteLine("Service.OnStop enter");
            //System.Diagnostics.EventLog.WriteEntry("SimpleService.OnStop", DateTime.Now.ToLongTimeString() + " - Pausing the service worker thread.");
            if (_dispatcher != null)
            {
                Trace.WriteLine("Service.OnStop InvokeShutdown");
                _dispatcher.InvokeShutdown();
            }
            Trace.WriteLine("Service.OnStop Join Tthread");
            _thread.Join();
            Trace.WriteLine("Service.OnStop leave");
        }

        protected override void OnPause()
        {
            Trace.WriteLine("Service.OnPause enter");
            //System.Diagnostics.EventLog.WriteEntry("SimpleService.OnPause", DateTime.Now.ToLongTimeString() + " - Pausing the service worker thread.");
            // it is called in the context of another thread
            if (_context != null)
                _context.Send(new System.Threading.SendOrPostCallback(DoPause), null );
            Trace.WriteLine("Service.OnPause leave");
        }

        protected override void OnContinue()
        {
            Trace.WriteLine("Service.OnContinue enter");
            //System.Diagnostics.EventLog.WriteEntry("SimpleService.OnContinue", DateTime.Now.ToLongTimeString() + " - Continue the service worker thread.");
            // it is called in the context of another thread
            if (_context != null)
                _context.Send(new System.Threading.SendOrPostCallback(DoContinue), null);
            Trace.WriteLine("Service.OnContinue leave");
        }

        public void DoStart(string[] args_)
        {
            Trace.WriteLine("Service.DoStart enter");
            _thread.Start(this);
            Trace.WriteLine("Service.DoStart leave");
        }

        void ThreadProc()
        {

            Trace.WriteLine("ThreadProc enter");
            try
            {
                _dispatcher = Dispatcher.CurrentDispatcher;
                _context = new DispatcherSynchronizationContext(Dispatcher.CurrentDispatcher);
                _connection = new Nanocom.Control.Connection(_context);
                
                Nanocom.Control.CounterValueProvider[] valueProvider = _connection.ValueProviders;
                Nanocom.Counters.Counter[] counter = Nanocom.Counters.Counter.CounterList();
                ServiceCounter[] serviceCounter = new ServiceCounter[counter.Length];
                for (int i = 0; i < serviceCounter.Length; i++) serviceCounter[i] = new ServiceCounter(counter[i], valueProvider[i]);
            
                Dispatcher.Run();
            }
            catch( Exception e )
            {
                Trace.WriteLine("Exception occured");
                Trace.WriteLine(e.ToString());
            }
            finally
            {
                _connection.Stop();
            }
            Trace.WriteLine("ThreadProc leave");
        }

        static void ThreadProc(object service_)
        {
            Service service = (Service)service_;
            service.ThreadProc();
        }

        internal void DoPause(object e_)
        {
            Trace.WriteLine("Service.DoPause enter");
            _connection.Pause();
            Trace.WriteLine("Service.DoPause leave");
        }

        internal void DoContinue( object e_ )
        {
            Trace.WriteLine("Service.DoContinue enter");
            _connection.Continue();
            Trace.WriteLine("Service.DoContinue leave");
        }

    }
}
