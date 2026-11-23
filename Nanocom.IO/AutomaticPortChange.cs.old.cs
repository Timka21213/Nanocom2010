using System;
using System.Threading;
using System.ServiceProcess;
using System.Diagnostics;
using System.Management;
using System.Management.Instrumentation;

namespace Nanocom.IO
{
    public class AutomaticPortChange : PortChangeNotifier
    {
        const string nanocomDisplayName = "NANOCOM diagnostic tool";
        const string usbDriverName = "usbser";

        private static readonly object _contextKey = new object();
        private ManualResetEvent _initializedEvent = null;
        private Thread _observerThread = null;
        private System.Windows.Forms.NativeWindow _notificationWindow=null;
        System.Windows.Forms.ApplicationContext _context = null;
        
        public override void StartNotification()
        //---------------------------------------------------------------------------
        {
            _observerThread = new Thread(new ThreadStart(this.DeviceChangeThreadProc));
            _observerThread.Start();
            _initializedEvent.WaitOne();
            _initializedEvent.Reset();
        }

        public override void StopNotification()
        //---------------------------------------------------------------------------
        {
            if( _context != null )
            {
                // todo: syncronize with DeviceChangeThreadProc
                _context.ExitThread();
                _observerThread.Join();
            }
            _observerThread = null;
            _context = null;
            
        }
        /// <summary>
        /// Verfies if the NANOCOM UsbSer Driver is installed.
        /// It check if a driver with name "usbser" is installed and has a display Name "NANOCOM diagnostic tool"
        /// </summary>
        /// <returns>true: The Nanocom UsbSer Driver is installed</returns>
        public static bool isNanocomUsbSerDriverInstalled()
        //---------------------------------------------------------------------------
        {
            ServiceController[] devices = ServiceController.GetDevices(); // get all devices
            foreach (ServiceController device in devices)
            {
                if ((device.ServiceName == usbDriverName) &&
                    (device.DisplayName == nanocomDisplayName))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Determines the name of the Nanocom COM port
        /// </summary>
        /// <returns>null: no nancom connected, otherwise the name of the COM port</returns>
        public static string nanocomPortName()
        //---------------------------------------------------------------------------
        {
            string portName = null;
            ManagementObjectCollection manObjFound;
            ManagementObjectSearcher manObjSearcher;
            manObjSearcher = new ManagementObjectSearcher("Select * from Win32_PnPEntity");
            manObjFound = manObjSearcher.Get();
            foreach (ManagementObject manObj in manObjFound)
            {
                if(manObj["ClassGUID"].ToString() == "{4D36E978-E325-11CE-BFC1-08002BE10318}")
                {
                    if( manObj["Description"].ToString() == nanocomDisplayName )
                    {

                        string name = manObj["Name"].ToString();
                        portName = System.Text.RegularExpressions.Regex.Match(name, @"COM[[0-9]+").ToString();
                        break;
                        /*
                        PropertyDataCollection properties = manObj.Properties;
                        foreach (PropertyData property in properties)
                        {
                            Console.WriteLine(property.Name);
                            if( manObj[property.Name] == null )
                                Console.WriteLine("<null>");
                            else
                                Console.WriteLine(manObj[property.Name].ToString());
                        }*/
                    }
                }
            }
            return portName;
        }

        public AutomaticPortChange( SynchronizationContext context_ ) : base( context_ )
        //---------------------------------------------------------------------------
        {
            _initializedEvent = new ManualResetEvent(false);
        }
        
        public void DeviceChangeThreadProc( ) 
        //---------------------------------------------------------------------------
        {
            _context = new System.Windows.Forms.ApplicationContext();
            _notificationWindow = new DevChangeWindow(this);
            // register for usb device change notifications
             System.Guid GUID_DEVINTERFACE_USB_DEVICE = new System.Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED");
            //System.Guid GUID_DEVINTERFACE_USB_DEVICE = new System.Guid( 0xA5DCBF10, 0x6530, 0x11D2, 0x90, 0x1F, 0x00, 0xC0, 0x4F, 0xB9, 0x51, 0xED );
            WinApi.DEV_BROADCAST_DEVICEINTERFACE notificationFilter = new WinApi.DEV_BROADCAST_DEVICEINTERFACE();
            notificationFilter.dbcc_size = System.Runtime.InteropServices.Marshal.SizeOf(notificationFilter);
            notificationFilter.dbcc_devicetype = WinApi.DBT_DEVTYP_DEVICEINTERFACE;
            notificationFilter.dbcc_classguid  = GUID_DEVINTERFACE_USB_DEVICE;
            notificationFilter.dbcc_reserved = 0;
            notificationFilter.dbcc_name = 0;
            System.IntPtr wndHandle = _notificationWindow.Handle;
            System.IntPtr buffer = System.Runtime.InteropServices.Marshal.AllocHGlobal(System.Runtime.InteropServices.Marshal.SizeOf(notificationFilter));
            System.Runtime.InteropServices.Marshal.StructureToPtr(notificationFilter, buffer, true);
            System.IntPtr hDevNotify = WinApi.RegisterDeviceNotification(wndHandle, buffer, WinApi.DEVICE_NOTIFY_WINDOW_HANDLE);
            if (hDevNotify == System.IntPtr.Zero)
            {
                int errorCode = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
                System.Console.WriteLine(errorCode);
            }
            // set the initialized event before device change notification
            // otherwise dead locks are possible
            _initializedEvent.Set();
            
            string portName = nanocomPortName();
            if (isNanocomUsbSerDriverInstalled() && (portName != null))
            {
                // if the nanocom is allready connected we won't get a notification
                OnDeviceChangedSynchronized( new PortChangeEventArgs( PortChange.Arrival, portName) );
            }
            System.Windows.Forms.Application.Run( _context );
            WinApi.UnregisterDeviceNotification(hDevNotify);
        }
        public void OnDeviceChangedSynchronized( PortChangeEventArgs e_ )
        {
            Debug.WriteLine(String.Format("{0}: OnDeviceChangedSynchronized", Thread.CurrentThread.ManagedThreadId.ToString()));
            OnDeviceChanged(e_);
        }
    }
}
