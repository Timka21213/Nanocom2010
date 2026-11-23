namespace NanocomPanelApplication
{
    partial class PanelForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelForm));
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.thermoMeter2 = new Nanocom.Gauge.ThermoMeter();
            this.thermoMeter1 = new Nanocom.Gauge.ThermoMeter();
            this.revMeter = new Nanocom.Gauge.RevMeter();
            this.speedoMeter = new Nanocom.Gauge.SpeedoMeter();
            this.voltMeter = new Nanocom.Gauge.VoltMeter();
            this.turboMeter = new Nanocom.Gauge.ManoMeter();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.balanceMeter = new Nanocom.Gauge.BalanceMeter();
            this.accelMeter = new Nanocom.Gauge.AccelMeter();
            this.stdThermoMeter = new Nanocom.Gauge.StdThermoMeter();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonNanocom = new System.Windows.Forms.Button();
            this._buttonPerfMon = new System.Windows.Forms.Button();
            this._buttonPauseContinue = new System.Windows.Forms.Button();
            this._buttonStartStop = new System.Windows.Forms.Button();
            this.buttonServices = new System.Windows.Forms.Button();
            this._labelService = new System.Windows.Forms.Label();
            this.secTimer = new System.Windows.Forms.Timer(this.components);
            this._nanocomServiceController = new System.ServiceProcess.ServiceController();
            this.percentMeter1 = new Nanocom.Gauge.PercentMeter();
            this.percentMeter2 = new Nanocom.Gauge.PercentMeter();
            this.percentMeter3 = new Nanocom.Gauge.PercentMeter();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // updateTimer
            // 
            this.updateTimer.Interval = 500;
            this.updateTimer.Tick += new System.EventHandler(this.updatTimer_Tick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Controls.Add(this.tabPage6);
            this.tabControl.Controls.Add(this.tabPage7);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.ItemSize = new System.Drawing.Size(50, 25);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(20, 4);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(632, 446);
            this.tabControl.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(624, 413);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel1.Controls.Add(this.label24, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.label23, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label22, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label21, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.label20, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label19, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label18, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label17, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label16, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label15, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label14, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label12, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label11, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label9, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(624, 413);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label24.ForeColor = System.Drawing.Color.White;
            this.label24.Location = new System.Drawing.Point(417, 357);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(204, 56);
            this.label24.TabIndex = 23;
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label23.ForeColor = System.Drawing.Color.White;
            this.label23.Location = new System.Drawing.Point(210, 357);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(201, 56);
            this.label23.TabIndex = 22;
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label22.ForeColor = System.Drawing.Color.White;
            this.label22.Location = new System.Drawing.Point(3, 357);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(201, 56);
            this.label22.TabIndex = 21;
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label21.ForeColor = System.Drawing.Color.White;
            this.label21.Location = new System.Drawing.Point(417, 306);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(204, 51);
            this.label21.TabIndex = 20;
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(210, 306);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(201, 51);
            this.label20.TabIndex = 19;
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(3, 306);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(201, 51);
            this.label19.TabIndex = 18;
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(417, 255);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(204, 51);
            this.label18.TabIndex = 17;
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.ForeColor = System.Drawing.Color.White;
            this.label17.Location = new System.Drawing.Point(210, 255);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(201, 51);
            this.label17.TabIndex = 16;
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.ForeColor = System.Drawing.Color.White;
            this.label16.Location = new System.Drawing.Point(3, 255);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(201, 51);
            this.label16.TabIndex = 15;
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(417, 204);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(204, 51);
            this.label15.TabIndex = 14;
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(210, 204);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(201, 51);
            this.label14.TabIndex = 13;
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(3, 204);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(201, 51);
            this.label13.TabIndex = 12;
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(417, 153);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(204, 51);
            this.label12.TabIndex = 11;
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(210, 153);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(201, 51);
            this.label11.TabIndex = 10;
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(3, 153);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(201, 51);
            this.label10.TabIndex = 9;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(417, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(204, 51);
            this.label9.TabIndex = 8;
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(210, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(201, 51);
            this.label8.TabIndex = 7;
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(3, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(201, 51);
            this.label7.TabIndex = 6;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(417, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(204, 51);
            this.label6.TabIndex = 5;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(210, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(201, 51);
            this.label5.TabIndex = 4;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(201, 51);
            this.label4.TabIndex = 3;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(417, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(204, 51);
            this.label3.TabIndex = 2;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(210, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 51);
            this.label2.TabIndex = 1;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 51);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(624, 413);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel2.Controls.Add(this.thermoMeter2, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.thermoMeter1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.revMeter, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.speedoMeter, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.voltMeter, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.turboMeter, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(624, 413);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // thermoMeter2
            // 
            this.thermoMeter2.AutoScroll = true;
            this.thermoMeter2.AutoScrollMinSize = new System.Drawing.Size(200, 200);
            this.thermoMeter2.BackColor = System.Drawing.Color.Black;
            this.thermoMeter2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thermoMeter2.FrameSize = 200;
            this.thermoMeter2.FrameWidth = 5;
            this.thermoMeter2.Interact = false;
            this.thermoMeter2.Location = new System.Drawing.Point(414, 206);
            this.thermoMeter2.Margin = new System.Windows.Forms.Padding(0);
            this.thermoMeter2.Name = "thermoMeter2";
            this.thermoMeter2.Size = new System.Drawing.Size(210, 207);
            this.thermoMeter2.TabIndex = 8;
            this.thermoMeter2.Value = 0F;
            // 
            // thermoMeter1
            // 
            this.thermoMeter1.AutoScroll = true;
            this.thermoMeter1.AutoScrollMinSize = new System.Drawing.Size(200, 200);
            this.thermoMeter1.BackColor = System.Drawing.Color.Black;
            this.thermoMeter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thermoMeter1.FrameSize = 200;
            this.thermoMeter1.FrameWidth = 5;
            this.thermoMeter1.Interact = false;
            this.thermoMeter1.Location = new System.Drawing.Point(207, 206);
            this.thermoMeter1.Margin = new System.Windows.Forms.Padding(0);
            this.thermoMeter1.Name = "thermoMeter1";
            this.thermoMeter1.Size = new System.Drawing.Size(207, 207);
            this.thermoMeter1.TabIndex = 7;
            this.thermoMeter1.Value = 0F;
            // 
            // revMeter
            // 
            this.revMeter.AutoScroll = true;
            this.revMeter.AutoScrollMinSize = new System.Drawing.Size(200, 200);
            this.revMeter.BackColor = System.Drawing.Color.Black;
            this.revMeter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.revMeter.FrameSize = 200;
            this.revMeter.FrameWidth = 5;
            this.revMeter.Interact = false;
            this.revMeter.Location = new System.Drawing.Point(414, 0);
            this.revMeter.Margin = new System.Windows.Forms.Padding(0);
            this.revMeter.Name = "revMeter";
            this.revMeter.Size = new System.Drawing.Size(210, 206);
            this.revMeter.TabIndex = 3;
            this.revMeter.Value = 0F;
            // 
            // speedoMeter
            // 
            this.speedoMeter.AutoScroll = true;
            this.speedoMeter.AutoScrollMinSize = new System.Drawing.Size(200, 200);
            this.speedoMeter.BackColor = System.Drawing.Color.Black;
            this.speedoMeter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.speedoMeter.FrameSize = 200;
            this.speedoMeter.FrameWidth = 5;
            this.speedoMeter.Interact = false;
            this.speedoMeter.Location = new System.Drawing.Point(207, 0);
            this.speedoMeter.Margin = new System.Windows.Forms.Padding(0);
            this.speedoMeter.Name = "speedoMeter";
            this.speedoMeter.Size = new System.Drawing.Size(207, 206);
            this.speedoMeter.TabIndex = 2;
            this.speedoMeter.Value = 0F;
            // 
            // voltMeter
            // 
            this.voltMeter.AutoScroll = true;
            this.voltMeter.AutoScrollMinSize = new System.Drawing.Size(200, 200);
            this.voltMeter.BackColor = System.Drawing.Color.Black;
            this.voltMeter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.voltMeter.FrameSize = 200;
            this.voltMeter.FrameWidth = 5;
            this.voltMeter.Interact = false;
            this.voltMeter.Location = new System.Drawing.Point(0, 0);
            this.voltMeter.Margin = new System.Windows.Forms.Padding(0);
            this.voltMeter.Name = "voltMeter";
            this.voltMeter.Size = new System.Drawing.Size(207, 206);
            this.voltMeter.TabIndex = 1;
            this.voltMeter.Value = 0F;
            // 
            // turboMeter
            // 
            this.turboMeter.AutoScroll = true;
            this.turboMeter.AutoScrollMinSize = new System.Drawing.Size(200, 200);
            this.turboMeter.BackColor = System.Drawing.Color.Black;
            this.turboMeter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.turboMeter.FrameSize = 200;
            this.turboMeter.FrameWidth = 5;
            this.turboMeter.Interact = false;
            this.turboMeter.Location = new System.Drawing.Point(0, 206);
            this.turboMeter.Margin = new System.Windows.Forms.Padding(0);
            this.turboMeter.MarkerValue = 0F;
            this.turboMeter.Name = "turboMeter";
            this.turboMeter.Size = new System.Drawing.Size(207, 207);
            this.turboMeter.TabIndex = 4;
            this.turboMeter.Value = 0F;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(624, 413);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSize = true;
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel3.Controls.Add(this.percentMeter3, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.percentMeter2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.balanceMeter, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.accelMeter, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.stdThermoMeter, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.percentMeter1, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(624, 413);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // balanceMeter
            // 
            this.balanceMeter.AutoScroll = true;
            this.balanceMeter.AutoScrollMinSize = new System.Drawing.Size(200, 200);
            this.balanceMeter.BackColor = System.Drawing.Color.Black;
            this.balanceMeter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.balanceMeter.FrameSize = 200;
            this.balanceMeter.FrameWidth = 5;
            this.balanceMeter.Interact = false;
            this.balanceMeter.Location = new System.Drawing.Point(0, 0);
            this.balanceMeter.Margin = new System.Windows.Forms.Padding(0);
            this.balanceMeter.Name = "balanceMeter";
            this.balanceMeter.Size = new System.Drawing.Size(207, 206);
            this.balanceMeter.TabIndex = 0;
            this.balanceMeter.Value1 = 0F;
            this.balanceMeter.Value2 = 0F;
            this.balanceMeter.Value3 = 0F;
            this.balanceMeter.Value4 = 0F;
            this.balanceMeter.Value5 = 0F;
            // 
            // accelMeter
            // 
            this.accelMeter.AutoScroll = true;
            this.accelMeter.AutoScrollMinSize = new System.Drawing.Size(200, 200);
            this.accelMeter.BackColor = System.Drawing.Color.Black;
            this.accelMeter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accelMeter.FrameSize = 200;
            this.accelMeter.FrameWidth = 5;
            this.accelMeter.Interact = false;
            this.accelMeter.Location = new System.Drawing.Point(207, 0);
            this.accelMeter.Margin = new System.Windows.Forms.Padding(0);
            this.accelMeter.Name = "accelMeter";
            this.accelMeter.Size = new System.Drawing.Size(207, 206);
            this.accelMeter.TabIndex = 1;
            this.accelMeter.Value1 = 0F;
            this.accelMeter.Value2 = 0F;
            this.accelMeter.Value3 = 0F;
            this.accelMeter.ValueSupply = 0F;
            // 
            // stdThermoMeter
            // 
            this.stdThermoMeter.AutoScroll = true;
            this.stdThermoMeter.AutoScrollMinSize = new System.Drawing.Size(200, 200);
            this.stdThermoMeter.BackColor = System.Drawing.Color.Black;
            this.stdThermoMeter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stdThermoMeter.FrameSize = 200;
            this.stdThermoMeter.FrameWidth = 6;
            this.stdThermoMeter.Interact = false;
            this.stdThermoMeter.Location = new System.Drawing.Point(414, 206);
            this.stdThermoMeter.Margin = new System.Windows.Forms.Padding(0);
            this.stdThermoMeter.Name = "stdThermoMeter";
            this.stdThermoMeter.Size = new System.Drawing.Size(210, 207);
            this.stdThermoMeter.TabIndex = 2;
            this.stdThermoMeter.Value = 0F;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tabPage4.Controls.Add(this.tableLayoutPanel4);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(624, 413);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "4";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoSize = true;
            this.tableLayoutPanel4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(624, 413);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.tableLayoutPanel5);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(0);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(624, 413);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(624, 413);
            this.tableLayoutPanel5.TabIndex = 1;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.tableLayoutPanel6);
            this.tabPage6.Location = new System.Drawing.Point(4, 29);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(624, 413);
            this.tabPage6.TabIndex = 2;
            this.tabPage6.Text = "6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoSize = true;
            this.tableLayoutPanel6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel6.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel6.ColumnCount = 3;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(618, 407);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.tableLayoutPanel7);
            this.tabPage7.Location = new System.Drawing.Point(4, 29);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(624, 413);
            this.tabPage7.TabIndex = 3;
            this.tabPage7.Text = "Control";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.AutoSize = true;
            this.tableLayoutPanel7.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel7.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel7.ColumnCount = 3;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tableLayoutPanel7.Controls.Add(this.buttonNanocom, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this._buttonPerfMon, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this._buttonPauseContinue, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this._buttonStartStop, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.buttonServices, 2, 1);
            this.tableLayoutPanel7.Controls.Add(this._labelService, 2, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(618, 407);
            this.tableLayoutPanel7.TabIndex = 1;
            // 
            // buttonNanocom
            // 
            this.buttonNanocom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonNanocom.ForeColor = System.Drawing.Color.White;
            this.buttonNanocom.Image = global::NanocomPanelApplication.Properties.Resources.NancomNew;
            this.buttonNanocom.Location = new System.Drawing.Point(3, 206);
            this.buttonNanocom.Name = "buttonNanocom";
            this.buttonNanocom.Size = new System.Drawing.Size(199, 198);
            this.buttonNanocom.TabIndex = 6;
            this.buttonNanocom.UseVisualStyleBackColor = true;
            this.buttonNanocom.Click += new System.EventHandler(this.buttonNanocom_Click);
            // 
            // _buttonPerfMon
            // 
            this._buttonPerfMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this._buttonPerfMon.ForeColor = System.Drawing.Color.White;
            this._buttonPerfMon.Image = global::NanocomPanelApplication.Properties.Resources.PerfMon;
            this._buttonPerfMon.Location = new System.Drawing.Point(208, 206);
            this._buttonPerfMon.Name = "_buttonPerfMon";
            this._buttonPerfMon.Size = new System.Drawing.Size(199, 198);
            this._buttonPerfMon.TabIndex = 5;
            this._buttonPerfMon.Text = "Performance Monitor";
            this._buttonPerfMon.UseVisualStyleBackColor = true;
            this._buttonPerfMon.Click += new System.EventHandler(this.buttonPerfMon_Click);
            // 
            // _buttonPauseContinue
            // 
            this._buttonPauseContinue.Dock = System.Windows.Forms.DockStyle.Fill;
            this._buttonPauseContinue.Enabled = false;
            this._buttonPauseContinue.Image = global::NanocomPanelApplication.Properties.Resources.PauseDisabled;
            this._buttonPauseContinue.Location = new System.Drawing.Point(208, 3);
            this._buttonPauseContinue.Name = "_buttonPauseContinue";
            this._buttonPauseContinue.Size = new System.Drawing.Size(199, 197);
            this._buttonPauseContinue.TabIndex = 2;
            this._buttonPauseContinue.Text = "Pause/Continue";
            this._buttonPauseContinue.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._buttonPauseContinue.UseVisualStyleBackColor = true;
            this._buttonPauseContinue.Click += new System.EventHandler(this._buttonPauseContinue_Click);
            // 
            // _buttonStartStop
            // 
            this._buttonStartStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this._buttonStartStop.Enabled = false;
            this._buttonStartStop.Image = global::NanocomPanelApplication.Properties.Resources.PlayDisabled;
            this._buttonStartStop.Location = new System.Drawing.Point(3, 3);
            this._buttonStartStop.Name = "_buttonStartStop";
            this._buttonStartStop.Size = new System.Drawing.Size(199, 197);
            this._buttonStartStop.TabIndex = 0;
            this._buttonStartStop.Text = "Start/Stop";
            this._buttonStartStop.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._buttonStartStop.UseVisualStyleBackColor = true;
            this._buttonStartStop.Click += new System.EventHandler(this._buttonStartStop_Click);
            // 
            // buttonServices
            // 
            this.buttonServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonServices.ForeColor = System.Drawing.Color.Black;
            this.buttonServices.Image = global::NanocomPanelApplication.Properties.Resources.Service;
            this.buttonServices.Location = new System.Drawing.Point(413, 206);
            this.buttonServices.Name = "buttonServices";
            this.buttonServices.Size = new System.Drawing.Size(202, 198);
            this.buttonServices.TabIndex = 1;
            this.buttonServices.Text = "Services";
            this.buttonServices.UseVisualStyleBackColor = true;
            this.buttonServices.Click += new System.EventHandler(this.buttonServices_Click);
            // 
            // _labelService
            // 
            this._labelService.AutoSize = true;
            this._labelService.Dock = System.Windows.Forms.DockStyle.Fill;
            this._labelService.ForeColor = System.Drawing.Color.White;
            this._labelService.Location = new System.Drawing.Point(413, 0);
            this._labelService.Name = "_labelService";
            this._labelService.Size = new System.Drawing.Size(202, 203);
            this._labelService.TabIndex = 7;
            this._labelService.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // secTimer
            // 
            this.secTimer.Interval = 1000;
            this.secTimer.Tick += new System.EventHandler(this.secTimer_Tick);
            // 
            // _nanocomServiceController
            // 
            this._nanocomServiceController.ServiceName = "NanocomSvc";
            // 
            // percentMeter1
            // 
            this.percentMeter1.AutoScroll = true;
            this.percentMeter1.AutoScrollMinSize = new System.Drawing.Size(200, 200);
            this.percentMeter1.BackColor = System.Drawing.Color.Black;
            this.percentMeter1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.percentMeter1.FrameSize = 200;
            this.percentMeter1.FrameWidth = 6;
            this.percentMeter1.Interact = false;
            this.percentMeter1.Location = new System.Drawing.Point(414, 0);
            this.percentMeter1.Margin = new System.Windows.Forms.Padding(0);
            this.percentMeter1.Name = "percentMeter1";
            this.percentMeter1.Size = new System.Drawing.Size(210, 206);
            this.percentMeter1.TabIndex = 3;
            this.percentMeter1.Value = 0F;
            // 
            // percentMeter2
            // 
            this.percentMeter2.AutoScroll = true;
            this.percentMeter2.AutoScrollMinSize = new System.Drawing.Size(200, 200);
            this.percentMeter2.BackColor = System.Drawing.Color.Black;
            this.percentMeter2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.percentMeter2.FrameSize = 200;
            this.percentMeter2.FrameWidth = 6;
            this.percentMeter2.Interact = false;
            this.percentMeter2.Location = new System.Drawing.Point(0, 206);
            this.percentMeter2.Margin = new System.Windows.Forms.Padding(0);
            this.percentMeter2.Name = "percentMeter2";
            this.percentMeter2.Size = new System.Drawing.Size(207, 207);
            this.percentMeter2.TabIndex = 4;
            this.percentMeter2.Value = 0F;
            // 
            // percentMeter3
            // 
            this.percentMeter3.AutoScroll = true;
            this.percentMeter3.AutoScrollMinSize = new System.Drawing.Size(200, 200);
            this.percentMeter3.BackColor = System.Drawing.Color.Black;
            this.percentMeter3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.percentMeter3.FrameSize = 200;
            this.percentMeter3.FrameWidth = 6;
            this.percentMeter3.Interact = false;
            this.percentMeter3.Location = new System.Drawing.Point(207, 206);
            this.percentMeter3.Margin = new System.Windows.Forms.Padding(0);
            this.percentMeter3.Name = "percentMeter3";
            this.percentMeter3.Size = new System.Drawing.Size(207, 207);
            this.percentMeter3.TabIndex = 5;
            this.percentMeter3.Value = 0F;
            // 
            // PanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(632, 446);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PanelForm";
            this.Text = "NanocomPanel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Button _buttonStartStop;
        private System.Windows.Forms.Button buttonServices;
        private System.Windows.Forms.Timer secTimer;
        private System.ServiceProcess.ServiceController _nanocomServiceController;
        private System.Windows.Forms.Button _buttonPauseContinue;
        private System.Windows.Forms.Button _buttonPerfMon;
        public System.Windows.Forms.Label label15;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label16;
        public System.Windows.Forms.Label label21;
        public System.Windows.Forms.Label label20;
        public System.Windows.Forms.Label label19;
        public System.Windows.Forms.Label label18;
        public System.Windows.Forms.Label label17;
        public System.Windows.Forms.Label label24;
        public System.Windows.Forms.Label label23;
        public System.Windows.Forms.Label label22;
        private Nanocom.Gauge.RevMeter revMeter;
        private Nanocom.Gauge.SpeedoMeter speedoMeter;
        private Nanocom.Gauge.VoltMeter voltMeter;
        private System.Windows.Forms.Button buttonNanocom;
        private Nanocom.Gauge.ManoMeter turboMeter;
        private Nanocom.Gauge.ThermoMeter thermoMeter2;
        private Nanocom.Gauge.ThermoMeter thermoMeter1;
        private System.Windows.Forms.Label _labelService;
        private Nanocom.Gauge.BalanceMeter balanceMeter;
        private Nanocom.Gauge.AccelMeter accelMeter;
        private Nanocom.Gauge.StdThermoMeter stdThermoMeter;
        private Nanocom.Gauge.PercentMeter percentMeter3;
        private Nanocom.Gauge.PercentMeter percentMeter2;
        private Nanocom.Gauge.PercentMeter percentMeter1;
    }
}

