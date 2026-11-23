using System;
using System.Runtime.InteropServices;

namespace Nanocom.IO
{
	sealed class WinApi
	{
		
		// API declarations relating to device management (SetupDixxx and
		// RegisterDeviceNotification functions).
		
		// ******************************************************************************
		// API constants
		// ******************************************************************************
        public const int WM_USER = 0x0400;
        // from winbase.h
        public static readonly IntPtr HWND_MESSAGE = new IntPtr(-3);
        // from winbase.h
		public static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        // from winnt.h
        //
        // Registry Specific Access Rights.
        //

        public const int READ_CONTROL            = 0x00020000;
        public const int SYNCHRONIZE             = 0x00100000;

        public const int STANDARD_RIGHTS_READ    = (READ_CONTROL);
        public const int STANDARD_RIGHTS_WRITE   = (READ_CONTROL);
        public const int STANDARD_RIGHTS_EXECUTE = (READ_CONTROL);

		public const int KEY_QUERY_VALUE         = 0x0001;
		public const int KEY_SET_VALUE           = 0x0002;
		public const int KEY_CREATE_SUB_KEY      = 0x0004;
		public const int KEY_ENUMERATE_SUB_KEYS  = 0x0008;
		public const int KEY_NOTIFY              = 0x0010;
		public const int KEY_CREATE_LINK         = 0x0020;
		public const int KEY_READ                = ((STANDARD_RIGHTS_READ       |
                                  KEY_QUERY_VALUE            |
                                  KEY_ENUMERATE_SUB_KEYS     |
                                  KEY_NOTIFY)                 
                                  &                           
                                 (~SYNCHRONIZE));

        //
        // Predefined Value Types.
        //

		public const int REG_NONE                = 0;   // No value Type
		public const int REG_SZ                  = 1;   // Unicode nul terminated string
		public const int REG_EXPAND_SZ           = 2;   // Unicode nul terminated string
                                                        // (with environment variable references)
		public const int REG_BINARY              = 3;   // Free form binary
		public const int REG_DWORD               = 4;   // 32-bit Number
		public const int REG_DWORD_LITTLE_ENDIAN = 4;   // 32-bit Number (same as REG_DWORD)
		public const int REG_DWORD_BIG_ENDIAN    = 5;   // 32-bit Number
		public const int REG_LINK                = 6;   // Symbolic Link (unicode)
		public const int REG_MULTI_SZ            = 7;   // Multiple Unicode strings

		// from dbt.h
		public const int DBT_DEVICEARRIVAL = 0x8000;
		public const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
		public const int DBT_DEVTYP_DEVICEINTERFACE = 5;
		public const int DBT_DEVTYP_HANDLE = 6;
		public const int DEVICE_NOTIFY_ALL_INTERFACE_CLASSES = 4;
		public const int DEVICE_NOTIFY_SERVICE_HANDLE = 1;
		public const int DEVICE_NOTIFY_WINDOW_HANDLE = 0;
		public const int WM_DEVICECHANGE = 0x219;
		
		// from setupapi.h
        //
        // Flags controlling what is included in the device information set built
        // by SetupDiGetClassDevs
		public const short DIGCF_DEFAULT          = 0x00000001;  // only valid with DIGCF_DEVICEINTERFACE
		public const short DIGCF_PRESENT          = 0x00000002;
		public const short DIGCF_ALLCLASSES       = 0x00000004;
		public const short DIGCF_PROFILE          = 0x00000008;
		public const short DIGCF_DEVICEINTERFACE  = 0x00000010;

        // Values specifying the scope of a device property change
		public const short DICS_FLAG_GLOBAL         = 0x00000001;  // make change in all hardware profiles
		public const short DICS_FLAG_CONFIGSPECIFIC = 0x00000002;  // make change in specified profile only
		public const short DICS_FLAG_CONFIGGENERAL  = 0x00000004;  // 1 or more hardware profile-specific

        // KeyType values for SetupDiCreateDevRegKey, SetupDiOpenDevRegKey, and
        // SetupDiDeleteDevRegKey.
        public const short DIREG_DEV  =   0x00000001;          // Open/Create/Delete device key
        public const short DIREG_DRV  =   0x00000002;          // Open/Create/Delete driver key
        public const short DIREG_BOTH =   0x00000004;          // Delete both driver and Device key


		//
        // Device registry property codes
        // (Codes marked as read-only (R) may only be used for
        // SetupDiGetDeviceRegistryProperty)
        //
        // These values should cover the same set of registry properties
        // as defined by the CM_DRP codes in cfgmgr32.h.
        //
        // Note that SPDRP codes are zero based while CM_DRP codes are one based!
        //
        public const short SPDRP_DEVICEDESC = 0x00000000; // DeviceDesc (R/W)
        public const short SPDRP_HARDWAREID = 0x00000001;  // HardwareID (R/W)
        //...

		// ******************************************************************************
		// Structures and classes for API calls, listed alphabetically
		// ******************************************************************************
		
		// There are two declarations for the DEV_BROADCAST_DEVICEINTERFACE structure.
		
		// Use this in the call to RegisterDeviceNotification() and
		// in checking dbch_devicetype in a DEV_BROADCAST_HDR structure.
		[StructLayout(LayoutKind.Sequential)]
    public class DEV_BROADCAST_DEVICEINTERFACE
		{
			public int dbcc_size;
			public int dbcc_devicetype;
			public int dbcc_reserved;
			public Guid dbcc_classguid;
			public short dbcc_name;
        }
		
		// Use this to read the dbcc_name string and classguid.
		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
    public class DEV_BROADCAST_DEVICEINTERFACE_1
		{
			public int dbcc_size;
			public int dbcc_devicetype;
			public int dbcc_reserved;
			[MarshalAs(UnmanagedType.ByValArray, ArraySubType=UnmanagedType.U1, SizeConst=16)]public byte[] dbcc_classguid;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst=255)]public char[] dbcc_name;
		}
		
		[StructLayout(LayoutKind.Sequential)]
    public class DEV_BROADCAST_HANDLE
		{
			public int dbch_size;
			public int dbch_devicetype;
			public int dbch_reserved;
			public int dbch_handle;
			public int dbch_hdevnotify;
		}
		
		[StructLayout(LayoutKind.Sequential)]
    public class DEV_BROADCAST_HDR
		{
			public int dbch_size;
			public int dbch_devicetype;
			public int dbch_reserved;
		}
		
		[StructLayout(LayoutKind.Sequential)]
    public struct SP_DEVICE_INTERFACE_DATA
		{
			public int cbSize;
			public System.Guid InterfaceClassGuid;
			public int Flags;
			public int Reserved;
		}
		
		[StructLayout(LayoutKind.Sequential)]
    public struct SP_DEVICE_INTERFACE_DETAIL_DATA
		{
			public int cbSize;
			public string DevicePath;
		}
		
		[StructLayout(LayoutKind.Sequential)]
    public struct SP_DEVINFO_DATA
		{
			public int cbSize;
			public System.Guid ClassGuid;
			public int DevInst;
			public int Reserved;
		}
		
		// ******************************************************************************
		// API functions, listed alphabetically
		// ******************************************************************************

		
	//[DllImport("user32.dll", SetLastError=true)]
    //static public extern IntPtr RegisterDeviceNotification(IntPtr hRecipient, ref DEV_BROADCAST_DEVICEINTERFACE NotificationFilter, int Flags);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr RegisterDeviceNotification(IntPtr hRecipient, IntPtr NotificationFilter, Int32 Flags);
    
    [DllImport("user32.dll")]
    static public extern bool UnregisterDeviceNotification(IntPtr Handle);

    [DllImport("setupapi.dll")] 
    static public extern int SetupDiClassGuidsFromName( string ClassName, ref System.Guid ClassGuidList, int ClassGuidListSize, ref int RequiredSize );

	[DllImport("setupapi.dll")]
    static public extern int SetupDiCreateDeviceInfoList(ref System.Guid ClassGuid, int hwndParent);
		
	[DllImport("setupapi.dll")]
    static public extern int SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);
		
	[DllImport("setupapi.dll")]
    static public extern int SetupDiEnumDeviceInfo( IntPtr DeviceInfoSet , int MemberIndex, ref SP_DEVINFO_DATA DeviceInfoData );

	[DllImport("setupapi.dll")]
    static public extern int SetupDiEnumDeviceInterfaces(IntPtr DeviceInfoSet, int DeviceInfoData, ref System.Guid InterfaceClassGuid, int MemberIndex, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData);
		
	[DllImport("setupapi.dll", CharSet=CharSet.Auto)]
    static public extern IntPtr SetupDiGetClassDevs(ref System.Guid ClassGuid, string Enumerator, int hwndParent, int Flags);
		
	[DllImport("setupapi.dll")]
    static public extern bool SetupDiGetDeviceInterfaceDetail(IntPtr DeviceInfoSet, ref SP_DEVICE_INTERFACE_DATA DeviceInterfaceData, IntPtr DeviceInterfaceDetailData, int DeviceInterfaceDetailDataSize, ref int RequiredSize, IntPtr DeviceInfoData);

    [DllImport("setupapi.dll", SetLastError = true)]
    static public extern IntPtr SetupDiOpenDevRegKey( IntPtr DeviceInfoSet, ref SP_DEVINFO_DATA DeviceInfoData, int Scope, int HwProfile, int KeyType, int samDesired );

    [DllImport("setupapi.dll", CharSet = CharSet.Auto)]
    static public extern int SetupDiGetDeviceRegistryProperty( IntPtr DeviceInfoSet, ref SP_DEVINFO_DATA  DeviceInfoData, int Property, ref int PropertyRegDataType, [Out] byte[] PropertyBuffer, int PropertyBufferSize, ref int RequiredSize );



    [DllImport("advapi32.dll", CharSet = CharSet.Auto)]
    static public extern int RegQueryValueEx(IntPtr keyBase, string valueName, IntPtr reserved, ref int type, [Out] byte[] data, ref int dataSize);
    [DllImport("advapi32.dll")]
    static public extern int RegCloseKey(IntPtr keyHandle);

    }
	
}
