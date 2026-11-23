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
    public partial class ManoMeter : Gauge   
    {
        private CircularPointer _pointer;
        private NextUI.Component.CircularMarker _marker;
    
        public ManoMeter()
        {
            InitializeComponent();

            CircularFrame frame = CreateCircularFrame();
            this.Frame.Add(frame);

            FrameLabel label = CreateFrameLabel(frame, "bar");
            MoveFrameLabel(label, 0, -35);
            frame.FrameLabelCollection.Add(label);

            CircularScaleBar bar = CreateCircularScaleBar(frame);
         
            bar.StartValue = 0;
            bar.EndValue = 3;
            
            bar.StartAngle = 0;
            bar.SweepAngle = 90;
            
            bar.MajorTickNumber = 7;
            bar.MinorTicknumber = 1;

            bar.TickLabel.LabelFont = CreateTickLabelFont(1.2F);
            
            frame.ScaleCollection.Add(bar);

            CircularRange range2 = CreateCircularRange(frame);
            range2.StartValue = 2.5F;
            range2.EndValue = 3;

            bar.Range.Add(range2);
            
            _marker = CreateCircularMarker(frame);
            bar.Marker.Add(_marker);
            _pointer = CreateCircularPointer(frame);
            bar.Pointer.Add(_pointer);
        }

        public override FrameLabel AddBaseFrameLabel(string text, Font labelFont)
        {
            FrameLabel label = base.AddBaseFrameLabel(text, labelFont);
            MoveFrameLabel(label, 40, -30);
            return label;
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

        public float MarkerValue
        {
            get
            {
                return _marker.Value;
            }
            set
            {
                _marker.Value = value;
            }
        }
        /*
        new void Scale( SizeF size_ )
        {
            base.Scale(size_);
        }*/
    }
}
