using System;
using System.Threading;
using System.ServiceProcess;
using System.Diagnostics;
using System.Management;
using System.Management.Instrumentation;

namespace Nanocom.IO
{
    public class AutomaticPortChange : ManualPortChange
    {
        const string NanocomDescription = "NANOCOM diagnostic tool";
        const string UsbDriverName = "usbser";

       
        /// <summary>
        /// Verifies if the NANOCOM UsbSer Driver is installed.
        /// It check if a driver with name "usbser" is installed and has a display Name "NANOCOM diagnostic tool"
        /// </summary>
        /// <returns>true: The Nanocom UsbSer Driver is installed</returns>
        public static bool isNanocomUsbSerDriverInstalled()
        //---------------------------------------------------------------------------
        {
            ServiceController[] devices = ServiceController.GetDevices(); // get all devices
            foreach (ServiceController device in devices)
            {
                if ((device.ServiceName == UsbDriverName) &&
                    (device.DisplayName == NanocomDescription))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Determines the name of the Nanocom COM port
        /// </summary>
        /// <returns>null: no nancom connected, otherwise the name of the COM port</returns>
        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        public static string nanocomPortName()
        //---------------------------------------------------------------------------
        {
            string portName = null;
            ManagementClass serialPortClass = new ManagementClass("Win32_SerialPort");
            foreach (ManagementObject serialPort in serialPortClass.GetInstances())
            {
                if (serialPort["Description"].ToString() == NanocomDescription)
                {

                    portName = serialPort["DeviceID"].ToString();
                    break;
                }
            }
            return portName;
        }
        private WqlEventQuery _queryCreation;
        private WqlEventQuery _queryDeletion;
        private ManagementEventWatcher _watcherCreation;
        private ManagementEventWatcher _watcherDeletion;
        
        public AutomaticPortChange(SynchronizationContext context_)
            : base(context_)
        //---------------------------------------------------------------------------
        {
            _queryCreation =new WqlEventQuery("__InstanceCreationEvent",
                                              new TimeSpan(0, 0, 1),
                                              "TargetInstance isa \"Win32_SerialPort\"");
            _queryDeletion =new WqlEventQuery("__InstanceDeletionEvent",
                                              new TimeSpan(0, 0, 1),
                                              "TargetInstance isa \"Win32_SerialPort\"");
            _watcherCreation = new ManagementEventWatcher(_queryCreation);
            _watcherDeletion = new ManagementEventWatcher(_queryDeletion);

            // Set up a listener for events
            _watcherCreation.EventArrived += new EventArrivedEventHandler(HandleCreation);
            _watcherDeletion.EventArrived += new EventArrivedEventHandler(HandleDeletion);
        }

        internal void HandleCreation(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject serialPort = e.NewEvent["TargetInstance"] as ManagementBaseObject;
            if( serialPort["Description"].ToString() == NanocomDescription )
            {
                string portName = serialPort["DeviceID"].ToString();
                Debug.WriteLine(String.Format("Port Arrival {0}", portName ));
                OnDeviceChangedInternal(new PortChangeEventArgs(PortChange.Arrival, portName));
            }
        }
        internal void HandleDeletion(object sender, EventArrivedEventArgs e)
        {
            ManagementBaseObject serialPort = e.NewEvent["TargetInstance"] as ManagementBaseObject;
            if( serialPort["Description"].ToString() == NanocomDescription )
            {
                string portName = serialPort["DeviceID"].ToString();
                Debug.WriteLine(String.Format("Port Removal {0}", portName));
                OnDeviceChangedInternal(new PortChangeEventArgs(PortChange.Removed));
            }
        }

        internal void OnDeviceChangedInternal(PortChangeEventArgs e_)
        {
            Debug.WriteLine(String.Format("{0}: OnDeviceChangedInternal", Thread.CurrentThread.ManagedThreadId.ToString()));
            OnDeviceChanged(e_);
        }
        
        public override void StartNotification()
        {
            base.PortName = nanocomPortName();
            _watcherCreation.Start();
            _watcherDeletion.Start();
        }

        public override void StopNotification()
        {
            _watcherCreation.Stop();
            _watcherDeletion.Stop();
            base.StopNotification();
        }     
    }
}
