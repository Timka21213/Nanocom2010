using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;


namespace NanocomConsoleMonitor
{
    class Program
    {
        /// <summary>
        /// Writes a line of comma separeted performance counter names
        /// </summary>
        static void WriteCsvHeader(Nanocom.Counters.Counter[] counters_)
        {
            bool firstCounter = true;
            foreach (Nanocom.Counters.Counter c in counters_)
            {
                if (firstCounter)
                    firstCounter = false;
                else
                    Console.Write(",");
                Console.Write(c.Name);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Writes a line of comma separeted performance counter values
        /// </summary>
        static void WriteCsvLine(Nanocom.Counters.Counter[] counters_)
        {
            bool firstCounter = true;
            foreach (Nanocom.Counters.Counter c in counters_)
            {
                if (firstCounter)
                    firstCounter = false;
                else
                    Console.Write(", ");
                Console.Write("{0}", c.Value.ToString(c.Format));
            }
            Console.WriteLine();
        }
        
        /// <summary>
        /// The main entry point for the nanocom performance counter monitor application.
        /// </summary>
        static void Main(string[] args)
        {
            // check the running state of the nanocom service,
            // and start the service if necessary
            ServiceController nanocomSvc = new ServiceController("NanocomSvc");
            switch (nanocomSvc.Status)
            {
            case ServiceControllerStatus.Running:
                break;
            case ServiceControllerStatus.StartPending:
                nanocomSvc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                break;
            default:
                // we must have the permissons to start the service
                System.Security.Principal.WindowsPrincipal pricipal = new System.Security.Principal.WindowsPrincipal(System.Security.Principal.WindowsIdentity.GetCurrent());
                if( !pricipal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator) )
                {
                    // if we don't have, restart the process with admin rigths
                    System.Diagnostics.ProcessStartInfo processInfo = new System.Diagnostics.ProcessStartInfo();
                    processInfo.FileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                    processInfo.Verb = "runas";
                    System.Diagnostics.Process.Start(processInfo);
                    return;
                }
                nanocomSvc.Start();
                nanocomSvc.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));
                break;
            }

            Nanocom.Counters.Counter[] counters = Nanocom.Counters.Counter.CounterList();
            // set culture to get a '.' as comma in the decimals
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            // print the csv header
            WriteCsvHeader(counters);
            while (true)
            {
                // print one csv line
                WriteCsvLine(counters);
                System.Threading.Thread.Sleep(1000/*[ms] polling interval*/);
            }
        }
    }
}
