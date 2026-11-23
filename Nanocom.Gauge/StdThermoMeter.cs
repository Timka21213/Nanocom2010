using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NextUI.Frame;
using NextUI.Collection;
using NextUI.Component;
using NextUI.Renderer;

namespace Nanocom.Gauge
{
    public partial class StdThermoMeter : Gauge
    {
        private CircularPointer _pointer;
        public StdThermoMeter()
        {
            InitializeComponent();

            CircularFrame frame = CreateCircularFrame();
            this.Frame.Add(frame);

            FrameLabel label = CreateFrameLabel(frame, "°C");
            MoveFrameLabel(label, 0, -35);
            frame.FrameLabelCollection.Add(label);
           

            CircularScaleBar bar = CreateCircularScaleBar(frame);

            bar.StartValue = -20;
            bar.EndValue = 60;
            
            bar.StartAngle = 50;
            bar.SweepAngle = 80;
            
            bar.MajorTickNumber = 9;
            bar.MinorTicknumber = 1;
                       
            frame.ScaleCollection.Add(bar);

            CircularRange range1 = CreateCircularRange(frame);
            range1.FillColor= RangeBlueColor;
            range1.StartValue = -20;
            range1.EndValue = 0;

            bar.Range.Add(range1);

            CircularRange range2 = CreateCircularRange(frame);
            range2.StartValue = 40;
            range2.EndValue = 60;
            range2.StartWidth = 10;
            range2.EndWidth = 10;
            bar.Range.Add(range2);

            _pointer = CreateCircularPointer(frame);
            bar.Pointer.Add(_pointer);
            


        }

        public float Value
        {
            get
            {
                return _pointer.Value;
            }
            set
            {
                _pointer.Value = value;
            }
        }
    }
}
