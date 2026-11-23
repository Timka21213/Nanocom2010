using System;
using System.Threading;

namespace Nanocom.IO
{
    public abstract class PortChangeNotifier
    {

        public event EventHandler DeviceChanged;

        private SynchronizationContext _context = SynchronizationContext.Current;

        protected PortChangeNotifier( SynchronizationContext context_ )
        //---------------------------------------------------------------------------
        {
            _context = context_;
        }
        public abstract void StartNotification();

        public abstract void StopNotification();
        
        protected void OnDeviceChanged(PortChangeEventArgs e_)
        //---------------------------------------------------------------------------
        {
            lock (this)
            {
                if (DeviceChanged != null)
                {
                    Console.WriteLine("{0}: OnDeviceChanged()", Thread.CurrentThread.ManagedThreadId.ToString());
                    if (_context != null)
                        _context.Post(new System.Threading.SendOrPostCallback(OnDeviceChangedInternal), e_);
                }
            }
        }

        private void OnDeviceChangedInternal(object  e_)
        //---------------------------------------------------------------------------
        {
            DeviceChanged(this, e_ as EventArgs);
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



    }
}
