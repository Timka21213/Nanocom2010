using System;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace Nanocom.IO
{
    internal class DevChangeWindow : System.Windows.Forms.NativeWindow
    {

        private AutomaticPortChange _notifier;

        public DevChangeWindow(AutomaticPortChange notifier_)
        {
            _notifier = notifier_;
            System.Windows.Forms.CreateParams cp = new System.Windows.Forms.CreateParams();

            // Fill in the CreateParams details.
            cp.ClassName = "Message";//"Static";

            // Set the position on the form
            cp.X = 0;
            cp.Y = 0;
            cp.Height = 0;
            cp.Width = 0;

            cp.Parent = WinApi.HWND_MESSAGE;


            unchecked
            {
                const int WS_POPUP = (int)0x80000000;
                cp.Style = WS_POPUP;
            }

            // Create the actual window
            this.CreateHandle(cp);
        }

        [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref System.Windows.Forms.Message msg_)
        {
            // Listen for messages that are sent to the button window. Some messages are sent
            // to the parent window instead of the button's window.
            switch (msg_.Msg)
            {
            case WinApi.WM_DEVICECHANGE:
                {
                    string baseDevName = "\\\\?\\USB#VID_1D52&PID_0001"; // verdorId=0x1D52, ProductId=0x0001
                    int nEventType = msg_.WParam.ToInt32();
                    switch (nEventType)
                    {
                        case WinApi.WM_USER:        // -- A device has been inserted and is now available. 
                            {
                                string portName = AutomaticPortChange.nanocomPortName();
                                if( portName == null )
                                {
                                    _notifier.OnDeviceChangedInternal(new PortChangeEventArgs(PortChange.Removed));
                                }
                                else
                                {
                                    _notifier.OnDeviceChangedInternal(new PortChangeEventArgs(PortChange.Arrival, portName));
                                }
                            }
                            
                            break;
                        case WinApi.DBT_DEVICEARRIVAL:        // -- A device has been inserted and is now available. 
                        {
                            int devType = System.Runtime.InteropServices.Marshal.ReadInt32(msg_.LParam, 4);
                            if (devType == WinApi.DBT_DEVTYP_DEVICEINTERFACE)
                            {
                                WinApi.DEV_BROADCAST_DEVICEINTERFACE_1 di = (WinApi.DEV_BROADCAST_DEVICEINTERFACE_1)
                                System.Runtime.InteropServices.Marshal.PtrToStructure(msg_.LParam, typeof(WinApi.DEV_BROADCAST_DEVICEINTERFACE_1));
                                string dbcc_name = new string(di.dbcc_name);
                                string devName = dbcc_name.Substring(0, dbcc_name.IndexOf('\0'));
                                //System.Windows.MessageBox.Show(devName + " arrival");
                                if (string.Compare( devName, 0, baseDevName, 0, baseDevName.Length, true )==0)
                                {
                                    // -- it is the nanocom, connect to it!
                                    string portName = AutomaticPortChange.nanocomPortName();
                                    Debug.WriteLine(String.Format("{0}: \"{1}\" arrival \"{2}\"", Thread.CurrentThread.ManagedThreadId.ToString(), devName));
                                    _notifier.OnDeviceChangedInternal(new PortChangeEventArgs( PortChange.Arrival, portName));
                                }
                            }
                        }
                        break;
                    case WinApi.DBT_DEVICEREMOVECOMPLETE: // -- Device has been removed.
                        {
                            int devType = System.Runtime.InteropServices.Marshal.ReadInt32(msg_.LParam, 4);
                            if (devType == WinApi.DBT_DEVTYP_DEVICEINTERFACE)
                            {
                                {
                                    WinApi.DEV_BROADCAST_DEVICEINTERFACE_1 di = (WinApi.DEV_BROADCAST_DEVICEINTERFACE_1)
                                    System.Runtime.InteropServices.Marshal.PtrToStructure(msg_.LParam, typeof(WinApi.DEV_BROADCAST_DEVICEINTERFACE_1));
                                    string dbcc_name = new string(di.dbcc_name);
                                    string devName = dbcc_name.Substring(0, dbcc_name.IndexOf('\0'));
                                    if (string.Compare(devName, 0, baseDevName, 0, baseDevName.Length, true) == 0)
                                    {
                                        // -- it is the nanocom, disconnect!
                                        Debug.WriteLine(String.Format("{0}: \"{1}\" removal", Thread.CurrentThread.ManagedThreadId.ToString(), devName));
                                        _notifier.OnDeviceChangedInternal(new PortChangeEventArgs(PortChange.Removed));
                                    }  
                                }
                            }
                        }
                        break;
                    }
                }
                break; //WinApi.WM_DEVICECHANGE
            }
            base.WndProc(ref msg_);
        }
    }
}
