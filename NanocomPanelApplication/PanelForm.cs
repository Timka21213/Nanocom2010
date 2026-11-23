using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using Nanocom.Counters;

namespace NanocomPanelApplication
{
    public partial class PanelForm : Form
    {
        private Counter[] _counter=null;
        private Counter _roadSpeedCounter = null;
        private Counter _engineSpeedCounter=null;
        private Counter _idleSpeedCounter = null;
        private Counter _batteryCounter = null;
        private Counter _manifoldCounter = null;
        private Counter _ambientCounter = null;
        private Counter _coolantTempCounter = null;
        private Counter _fuelTempCounter = null;
        private Counter _airTempCounter = null;
        private Counter _pot1Counter = null;
        private Counter _pot2Counter = null;
        private Counter _pot3Counter = null;
        private Counter _potSupplyCounter = null;
        private Counter _egrInletCounter = null;
        private Counter _egrModulatorCounter = null;
        private Counter _wastegateModulatorCounter = null;

        private Counter _cylinder1Counter = null;
        private Counter _cylinder2Counter = null;
        private Counter _cylinder3Counter = null;
        private Counter _cylinder4Counter = null;
        private Counter _cylinder5Counter = null;
        private string _title = null;
        public PanelForm()
        {
            InitializeComponent();
            _title = this.Text;
            try
            {
                _nanocomServiceController.Refresh();
                this.UpdateServiceControlButtons();
            }
            catch( Exception e )
            {
                StringBuilder message = new StringBuilder();
                message.Append("Can't get Status of Nanocom Service\nMaybe the Nanocom Service is not installed.\n\n");
                message.Append(e.Message);
                // Show message box
                System.Windows.Forms.MessageBox.Show(this, message.ToString(), this.Text,  MessageBoxButtons.OK, MessageBoxIcon.Hand);
                throw;
            }
            try
            {
                _counter = Nanocom.Counters.Counter.CounterList();
            }
            catch (Exception e)
            {
                StringBuilder message = new StringBuilder();
                message.Append("Can't get Nanocom Performance Counter\nMaybe the Nanocom Service is not installed.\n\n");
                message.Append(e.Message);
                // Show message box
                System.Windows.Forms.MessageBox.Show(this, message.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                throw;
            }
            _roadSpeedCounter = _counter[(int)Counter.Index.RoadSpeed];
            _engineSpeedCounter = _counter[(int)Counter.Index.EngineSpeed];
            _idleSpeedCounter = _counter[(int)Counter.Index.IdleSpeed];
            _batteryCounter  = _counter[(int)Counter.Index.Battery];
            _manifoldCounter = _counter[(int)Counter.Index.ManifoldPressure];
            _ambientCounter = _counter[(int)Counter.Index.AmbientPressure];
            _coolantTempCounter = _counter[(int)Counter.Index.CoolantTemp];
            _fuelTempCounter = _counter[(int)Counter.Index.FuelTemp];
            _airTempCounter = _counter[(int)Counter.Index.AirInletTemp];
            _pot1Counter = _counter[(int)Counter.Index.Pot1];
            _pot2Counter = _counter[(int)Counter.Index.Pot2];
            _pot3Counter = _counter[(int)Counter.Index.Pot3];
            _potSupplyCounter = _counter[(int)Counter.Index.PotSupply];
            _cylinder1Counter = _counter[(int)Counter.Index.Cylinder1];
            _cylinder2Counter = _counter[(int)Counter.Index.Cylinder2];
            _cylinder3Counter = _counter[(int)Counter.Index.Cylinder3];
            _cylinder4Counter = _counter[(int)Counter.Index.Cylinder4];
            _cylinder5Counter = _counter[(int)Counter.Index.Cylinder5];
            _egrInletCounter = _counter[(int)Counter.Index.EGRInlet];
            _egrModulatorCounter = _counter[(int)Counter.Index.EGRModulator];
            _wastegateModulatorCounter = _counter[(int)Counter.Index.WastegateModulator];

            voltMeter.AddBaseFrameLabel("Battery");
            turboMeter.AddBaseFrameLabel("Turbo");
            speedoMeter.AddBaseFrameLabel("Speed");
            revMeter.AddBaseFrameLabel("Td5");
            thermoMeter1.AddBaseFrameLabel("Water");
            thermoMeter2.AddBaseFrameLabel("Fuel");
            stdThermoMeter.AddBaseFrameLabel("Air Inlet");
            percentMeter1.AddBaseFrameLabel("EGR Inlet");
            percentMeter2.AddBaseFrameLabel("EGR");
            percentMeter3.AddBaseFrameLabel("Wastegate");
            _labelService.Text = _nanocomServiceController.DisplayName;

            updateControls();
            updateTimer.Enabled = true;
            secTimer.Enabled = true;
        }

        static private string ToString( Nanocom.Counters.Counter counter_)
        {
            StringBuilder str = new StringBuilder();
            // remove the units within square bracket [*] from the counter name
            string baseName = System.Text.RegularExpressions.Regex.Replace(counter_.Name,@"[\s]*\[[^\]]*\]","");
            str.Append(baseName);
            str.Append(": ");
            str.Append(counter_.Value.ToString(counter_.Format));
            str.Append(counter_.Unit);
            return str.ToString();
        }
        private void updateControl(Label label_, Counter counter_ )
        {
            label_.Text = ToString( counter_ );
        }
        private void updateControls()
        {
            int connectionStatus = (int)_counter[0].RawValue;
            this.Text = _title+" - " + Counter.StatusText(connectionStatus);
            updateControl(label1, _counter[1]);
            updateControl(label2, _counter[2]);
            updateControl(label3, _counter[3]);
            updateControl(label4, _counter[4]);
            updateControl(label5, _counter[5]);
            updateControl(label6, _counter[6]);
            updateControl(label7, _counter[7]);
            updateControl(label8, _counter[8]);
            updateControl(label9, _counter[9]);
            updateControl(label10, _counter[10]);
            updateControl(label11, _counter[11]);
            updateControl(label12, _counter[12]);
            updateControl(label13, _counter[13]);
            updateControl(label14, _counter[14]);
            updateControl(label15, _counter[15]);
            updateControl(label16, _counter[16]);
            updateControl(label17, _counter[17]);
            updateControl(label18, _counter[18]);
            updateControl(label19, _counter[19]);
            updateControl(label20, _counter[20]);
            updateControl(label21, _counter[21]);
            updateControl(label22, _counter[22]);
            speedoMeter.Value = _roadSpeedCounter.Value;
            revMeter.Value = _engineSpeedCounter.Value/1000F;

            float supply = _potSupplyCounter.Value;
            if (supply > 0)
            {
                accelMeter.Value1 = _pot1Counter.Value/supply*100;
                accelMeter.Value2 = _pot2Counter.Value/supply*100;
                accelMeter.Value3 = _pot3Counter.Value/supply*100;
            }
            else
            {
                accelMeter.Value1 = 0;
                accelMeter.Value2 = 0;
                accelMeter.Value3 = 0;
            }
            accelMeter.ValueSupply = supply;

            voltMeter.Value = _batteryCounter.Value;
            turboMeter.Value = _manifoldCounter.Value*(100.0F/10000.0F);
            turboMeter.MarkerValue = _ambientCounter.Value * (100.0F / 10000.0F);
            thermoMeter1.Value = _coolantTempCounter.Value;
            thermoMeter2.Value = _fuelTempCounter.Value;
            balanceMeter.Value1 = _cylinder1Counter.Value;
            balanceMeter.Value2 = _cylinder2Counter.Value;
            balanceMeter.Value3 = _cylinder3Counter.Value;
            balanceMeter.Value4 = _cylinder4Counter.Value;
            balanceMeter.Value5 = _cylinder5Counter.Value;
            stdThermoMeter.Value = _airTempCounter.Value;
            percentMeter1.Value = _egrInletCounter.Value;
            percentMeter1.Value = _egrModulatorCounter.Value;
            percentMeter1.Value = _wastegateModulatorCounter.Value;
        }
        private void UpdateServiceControlButtons()
        {
             switch( _nanocomServiceController.Status )
            {
                case ServiceControllerStatus.Stopped:
                    this._buttonStartStop.Enabled = true;
                    this._buttonPauseContinue.Enabled = false;
                    this._buttonStartStop.Image = global::NanocomPanelApplication.Properties.Resources.PlayNormal;
                    this._buttonPauseContinue.Image = global::NanocomPanelApplication.Properties.Resources.PauseDisabled;
                    break;
                case ServiceControllerStatus.StartPending:
                    this._buttonStartStop.Enabled = false;
                    this._buttonPauseContinue.Enabled = false;
                    this._buttonStartStop.Image = global::NanocomPanelApplication.Properties.Resources.PlayDisabled;
                    this._buttonPauseContinue.Image = global::NanocomPanelApplication.Properties.Resources.PauseDisabled;
                    break;
                case ServiceControllerStatus.Running:
                    this._buttonStartStop.Enabled = true;
                    this._buttonPauseContinue.Enabled = true;
                    this._buttonStartStop.Image = global::NanocomPanelApplication.Properties.Resources.StopNormal;
                    this._buttonPauseContinue.Image = global::NanocomPanelApplication.Properties.Resources.PauseNormal;
                    break;
                case ServiceControllerStatus.PausePending:
                    this._buttonStartStop.Enabled = false;
                    this._buttonPauseContinue.Enabled = false;
                    this._buttonStartStop.Image = global::NanocomPanelApplication.Properties.Resources.StopDisabled;
                    this._buttonPauseContinue.Image = global::NanocomPanelApplication.Properties.Resources.PauseDisabled;
                    break;
                case ServiceControllerStatus.Paused:
                    this._buttonStartStop.Enabled = true;
                    this._buttonPauseContinue.Enabled = true;
                    this._buttonStartStop.Image = global::NanocomPanelApplication.Properties.Resources.StopNormal;
                    this._buttonPauseContinue.Image = global::NanocomPanelApplication.Properties.Resources.StepForwardNormal;
                    break;
                case ServiceControllerStatus.ContinuePending:
                    this._buttonStartStop.Enabled = false;
                    this._buttonPauseContinue.Enabled = false;
                    this._buttonStartStop.Image = global::NanocomPanelApplication.Properties.Resources.StopDisabled;
                    this._buttonPauseContinue.Image = global::NanocomPanelApplication.Properties.Resources.StepForwardDisabled;
                    break;
                case ServiceControllerStatus.StopPending:
                    this._buttonStartStop.Enabled = false;
                    this._buttonPauseContinue.Enabled = false;
                    this._buttonStartStop.Image = global::NanocomPanelApplication.Properties.Resources.StopDisabled;
                    this._buttonPauseContinue.Image = global::NanocomPanelApplication.Properties.Resources.StepForwardDisabled;
                    break;
            }
        }
        private void updatTimer_Tick(object sender, EventArgs e)
        {
            updateControls();
        }

        private void secTimer_Tick(object sender, EventArgs e)
        {
            ServiceControllerStatus lastServiceStatus = _nanocomServiceController.Status;
            _nanocomServiceController.Refresh();
            if (lastServiceStatus != _nanocomServiceController.Status)
            {
                UpdateServiceControlButtons();
            }
        }

        private void StartProcess( System.Diagnostics.ProcessStartInfo processInfo_)
        {
            try
            {
                System.Diagnostics.Process.Start(processInfo_);
            }
            catch (Exception e)
            {
                StringBuilder message = new StringBuilder();
                message.Append("Failed to Start Process\n");
                message.Append(processInfo_.FileName);
                message.Append("\n\n");
                message.Append(e.Message);
                // Show message box
                System.Windows.Forms.MessageBox.Show(this, message.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonServices_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo processInfo = new System.Diagnostics.ProcessStartInfo("mmc.exe", Environment.ExpandEnvironmentVariables("\"%SystemRoot%\\system32\\services.msc\" /s"));
            //processInfo.Verb = "runas";
            StartProcess(processInfo);
        }

        private void buttonPerfMon_Click(object sender, EventArgs e)
        {
            System.Diagnostics.ProcessStartInfo processInfo = new System.Diagnostics.ProcessStartInfo("mmc.exe", Environment.ExpandEnvironmentVariables("\"%SystemRoot%\\system32\\perfmon.msc\" /s"));
            //processInfo.Verb = "runas";
            StartProcess(processInfo);
        }

        private void buttonNanocom_Click(object sender, EventArgs e)
        {
            string program = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\NANOCOM\\NanocomNew.exe";
            System.Diagnostics.ProcessStartInfo processInfo = new System.Diagnostics.ProcessStartInfo(program);
            StartProcess(processInfo);
        }

        private void _buttonStartStop_Click(object sender, EventArgs e)
        {
            try
            {
                this._nanocomServiceController.Refresh();
                switch (_nanocomServiceController.Status)
                {
                    case ServiceControllerStatus.Stopped:
                        this._nanocomServiceController.Start();
                        break;
                    case ServiceControllerStatus.Running:
                    case ServiceControllerStatus.Paused:
                        if (this._nanocomServiceController.CanStop)
                            this._nanocomServiceController.Stop();
                        break;
                }
            }
            catch (Exception ex)
            {
                StringBuilder message = new StringBuilder();
                message.Append("Failed to Start/Stop ");
                message.Append(_nanocomServiceController.DisplayName);
                message.Append("\n\n");
                message.Append(ex.Message);
                // Show message box
                System.Windows.Forms.MessageBox.Show(this, message.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void _buttonPauseContinue_Click(object sender, EventArgs e)
        {
            try
            {
                this._nanocomServiceController.Refresh();
                switch (_nanocomServiceController.Status)
                {
                    case ServiceControllerStatus.Running:
                        if (this._nanocomServiceController.CanPauseAndContinue)
                            this._nanocomServiceController.Pause();
                        break;
                    case ServiceControllerStatus.Paused:
                        if (this._nanocomServiceController.CanPauseAndContinue)
                            this._nanocomServiceController.Continue();
                        break;
                }
            }
            catch (Exception ex)
            {
                StringBuilder message = new StringBuilder();
                message.Append("Failed to Pause/Continue ");
                message.Append(_nanocomServiceController.DisplayName);
                message.Append("\n\n");
                message.Append(ex.Message);
                // Show message box
                System.Windows.Forms.MessageBox.Show(this, message.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
