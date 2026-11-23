using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace Service
{

    public partial class Service : ServiceBase
    {
        private System.Threading.Thread _thread;
        private System.Threading.AutoResetEvent _terminate;

        // http://www.codeproject.com/KB/dotnet/perfcounter.aspx
        public Service()
        {
            InitializeComponent();
            _terminate = new System.Threading.AutoResetEvent(false);
            _thread = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(ThreadProc));

            /*if (!System.Diagnostics.EventLog.SourceExists(eventLog.Source))
            {
                System.Diagnostics.EventLog.CreateEventSource(eventLog.Source, eventLog.Log);
                _terminate.WaitOne(1000);
            }*/
            /* if we attach a value provider the counters will be instanciated as read/write */
            Nanocom.Counter[] counter = Nanocom.Counter.CounterList();

            counter[0].ValueProvider = new Nanocom.CounterValueSimulator(0, 3, 100);
            counter[1].ValueProvider = new Nanocom.CounterValueSimulator(0, 4200, 100);
            counter[2].ValueProvider = new Nanocom.CounterValueSimulator(0,100,20);
            counter[3].ValueProvider = new Nanocom.CounterValueSimulator(0,120,120);
            counter[4].ValueProvider = new Nanocom.CounterValueSimulator(13.9,14.4,100);
            counter[5].ValueProvider = new Nanocom.CounterValueSimulator(1,2, 100);
            counter[6].ValueProvider = new Nanocom.CounterValueSimulator(2,3,100);
            counter[7].ValueProvider = new Nanocom.CounterValueSimulator(3,4,100);
            counter[8].ValueProvider = new Nanocom.CounterValueSimulator(4.2,5.1,100);
            counter[9].ValueProvider = new Nanocom.CounterValueSimulator(10,98,200);
            counter[10].ValueProvider = new Nanocom.CounterValueSimulator(10,50,100);
            counter[11].ValueProvider = new Nanocom.CounterValueSimulator(10,40,100);
            counter[12].ValueProvider = new Nanocom.CounterValueSimulator(100,120,100);
            counter[13].ValueProvider = new Nanocom.CounterValueSimulator(0,120,100);
            counter[14].ValueProvider = new Nanocom.CounterValueSimulator(0,120,100);
            counter[15].ValueProvider = new Nanocom.CounterValueSimulator(0,100,100);
            counter[16].ValueProvider = new Nanocom.CounterValueSimulator(0,100,100);
            counter[17].ValueProvider = new Nanocom.CounterValueSimulator(0,100,100);
            counter[18].ValueProvider = new Nanocom.CounterValueSimulator(-10,10,20);
            counter[19].ValueProvider = new Nanocom.CounterValueSimulator(-20,20,30);
            counter[20].ValueProvider = new Nanocom.CounterValueSimulator(-15,15,40);
            counter[21].ValueProvider = new Nanocom.CounterValueSimulator(-10,10,25);
            counter[22].ValueProvider = new Nanocom.CounterValueSimulator(-10,10,29);
        }

        protected override void OnStart( string[] args_ )
        {     
            DoStart( args_ );
        }

        protected override void OnStop()
        {
            DoStop();
        }
        public void DoStart( string[] args_ )
        {
            _thread.Start( this );
        }

        public void DoStop()
        {
            _terminate.Set();
            _thread.Join();
        }
        void ThreadProc()
        {
            while (!_terminate.WaitOne(1000/*update frequence millsecs*/))
            {
                // do the work
                Nanocom.Counter.UpdateValues();
                //Console.WriteLine("Service Thread do");
            }
            //Console.WriteLine("Service Thread done");
        }

        static void ThreadProc(object service_)
        {
            Service service = (Service)service_;
            service.ThreadProc();
        }

    }
}
