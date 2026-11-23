using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Diagnostics;
using System.Management;
using System.Management.Instrumentation;

namespace Nanocom.Service
{
    public class ServiceCounter  
    {
        private Nanocom.Counters.Counter _counter;
        private Nanocom.Control.CounterValueProvider _vp;
        public ServiceCounter( Nanocom.Counters.Counter counter_, Nanocom.Control.CounterValueProvider provider_)
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

 static class Program
    {
        /// <summary>
        /// The main entry point for the service application.
        /// </summary>
        static void Main()
        {
//            TraceListener tl = new TextWriterTraceListener(new System.IO.StreamWriter("C:\\Temp\\Nanocom.log"));
//            Trace.Listeners.Add(tl);
//            Trace.AutoFlush = true;
            try
            {
                Service ServiceToRun = new Service();
                ServiceBase.Run(ServiceToRun);
            }
            catch( Exception e )
            {
                Trace.WriteLine(e);
            }
        }
    }
}
