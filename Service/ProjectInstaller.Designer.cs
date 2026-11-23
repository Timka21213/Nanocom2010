namespace Service
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.serviceInstaller = new System.ServiceProcess.ServiceInstaller();
            this.performanceCounterInstaller = new System.Diagnostics.PerformanceCounterInstaller();
            // 
            // serviceProcessInstaller
            // 
            this.serviceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.serviceProcessInstaller.Password = null;
            this.serviceProcessInstaller.Username = null;
            this.serviceProcessInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceProcessInstaller_AfterInstall);
            // 
            // serviceInstaller
            // 
            this.serviceInstaller.Description = "Provides performance counters of the Land Rover Td5 Diesel engine.";
            this.serviceInstaller.DisplayName = "Nanocom Performance Counters Service";
            this.serviceInstaller.ServiceName = "NanocomSvc";
            this.serviceInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.serviceInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceInstaller_AfterInstall);
            // 
            // performanceCounterInstaller
            // 
            this.performanceCounterInstaller.CategoryHelp = "Land Rover Td5 Diesel Engine Performance Data";
            this.performanceCounterInstaller.CategoryName = "Nanocom";
            this.performanceCounterInstaller.CategoryType = System.Diagnostics.PerformanceCounterCategoryType.SingleInstance;
            this.performanceCounterInstaller.Counters.AddRange(new System.Diagnostics.CounterCreationData[] {
            new System.Diagnostics.CounterCreationData("Connection Status", "Connection status:\\n 0: not connected\\n1: connected\\n2: open\\n3:initialized", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
            new System.Diagnostics.CounterCreationData("Engine Speed [rpm]", "Engine speed help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
            new System.Diagnostics.CounterCreationData("Idle Speed [rpm]", "Idle Speed Help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
            new System.Diagnostics.CounterCreationData("Road Speed [km/h]", "Road Speed help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
            new System.Diagnostics.CounterCreationData("Battery [mV]", "Battery Voltage", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
            new System.Diagnostics.CounterCreationData("Accel. Way 1 [mV]", "Accel. Way 1 Help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
            new System.Diagnostics.CounterCreationData("Accel. Way 2 [mv]", "Accel. Way 2 help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
            new System.Diagnostics.CounterCreationData("Accel. Way 3 [mv]", "Accel. Way 3 help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
            new System.Diagnostics.CounterCreationData("Accel. Way Supply [mv]", "Accel. Way Supply help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
            new System.Diagnostics.CounterCreationData("Coolant Temperature [1/10 °C]", "Coolant Temperature help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
            new System.Diagnostics.CounterCreationData("Fuel Temperature [1/10 °C]", "Fuel Temperature help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
            new System.Diagnostics.CounterCreationData("Air Inlet Temperature [1/10 °C]", "Air Inlet Temperature help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
            new System.Diagnostics.CounterCreationData("Air Flow [1/10 g/h]", "Air Flow Help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
            new System.Diagnostics.CounterCreationData("Ambient Pressure [1/10 Kpa]", "Ambient Pressure help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
            new System.Diagnostics.CounterCreationData("Manifold Pressure [1/10 Kpa]", "Manifold Pressure help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
            new System.Diagnostics.CounterCreationData("EGR Modulator [1/10 %]", "EGR Modulator help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
            new System.Diagnostics.CounterCreationData("EGR Inlet [1/10 %]", "EGR Inlet help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
            new System.Diagnostics.CounterCreationData("Wastegate Modulator [1/10 %]", "Wastegate Modulator help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
            new System.Diagnostics.CounterCreationData("Cylinder 1 Balance [+50]", "Cylinder 1 help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
            new System.Diagnostics.CounterCreationData("Cylinder 2 Balance [+50]", "Cylinder 2 help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
            new System.Diagnostics.CounterCreationData("Cylinder 3 Balance [+50]", "Cylinder 3 help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
            new System.Diagnostics.CounterCreationData("Cylinder 4 Balance [+50]", "Cylinder 4 help", System.Diagnostics.PerformanceCounterType.NumberOfItems32),
            new System.Diagnostics.CounterCreationData("Cylinder 5 Balance [+50]", "Cylinder 5 help", System.Diagnostics.PerformanceCounterType.NumberOfItems32)});
            this.performanceCounterInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.performanceCounterInstaller_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller,
            this.serviceInstaller,
            this.performanceCounterInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller serviceInstaller;
        private System.Diagnostics.PerformanceCounterInstaller performanceCounterInstaller;
    }
}