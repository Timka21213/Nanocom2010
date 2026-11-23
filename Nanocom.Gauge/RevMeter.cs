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
    public partial class RevMeter : Gauge
    {
        private CircularPointer _pointer;
        public RevMeter()
        {
            InitializeComponent();

            CircularFrame frame = CreateCircularFrame();
            this.Frame.Add(frame);

            FrameLabel label = CreateFrameLabel( frame, "rpm \x00D7 1000", CreateFrameLabelFont(0.66F) );
            MoveFrameLabel(label, 0, -35);
            frame.FrameLabelCollection.Add(label);
           

            CircularScaleBar bar = CreateCircularScaleBar(frame);

            
            bar.StartValue = 0.000F;
            bar.EndValue = 5.000F;
            
            bar.StartAngle = 50;
            bar.SweepAngle = 80;
            
            bar.MajorTickNumber = 6;
            bar.MinorTicknumber = 1;
            bar.TickLabel.LabelFont = CreateTickLabelFont(1.5F);
            
            frame.ScaleCollection.Add(bar);

            CircularRange range = CreateCircularRange(frame);
            range.StartValue = 4.500F;
            range.EndValue = 5.000F;

            bar.Range.Add(range);

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
