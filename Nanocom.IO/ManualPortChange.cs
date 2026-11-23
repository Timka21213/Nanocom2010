using System;
using System.Threading;
using System.Linq;
using System.Text;

namespace Nanocom.IO
{
    public class ManualPortChange :  PortChangeNotifier
    {
    private string _portName;
    public ManualPortChange( SynchronizationContext context_ ) : base( context_ )
   //---------------------------------------------------------------------------
    {
        _portName = null;
    }
    public override void StartNotification()
    //---------------------------------------------------------------------------
    {
        OnDeviceChanged(new PortChangeEventArgs(_portName == null ? PortChange.Removed : PortChange.Arrival, _portName));
    }

    public override void StopNotification()
    //---------------------------------------------------------------------------
    {
    }
    
    public string PortName
    //---------------------------------------------------------------------------
    {
        get
        {
            return _portName;
        }
        set
        {
            _portName = value;
            OnDeviceChanged(new PortChangeEventArgs(_portName==null ? PortChange.Removed : PortChange.Arrival, _portName));
        }
    }
    }
}
