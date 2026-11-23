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
    public partial class SpeedoMeter : Gauge   
    {
        private CircularPointer _pointer;
        public SpeedoMeter()
        {
            InitializeComponent();

            CircularFrame frame = CreateCircularFrame();
            this.Frame.Add(frame);

            FrameLabel label = CreateFrameLabel(frame,"km/h");
            MoveFrameLabel(label, 0, -35);
            frame.FrameLabelCollection.Add(label);
           

            CircularScaleBar bar = CreateCircularScaleBar(frame);
            bar.StartValue = 0;
            bar.EndValue = 200;
            
            bar.StartAngle = 50;
            bar.SweepAngle = 80;
            
            bar.MajorTickNumber = 11;
            bar.MinorTicknumber = 1;
            
            frame.ScaleCollection.Add(bar);

            CircularRange range = CreateCircularRange(frame);
            range.StartValue = 160;
            range.EndValue = 200;
            range.StartWidth = 1;

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
        /*
        new void Scale( SizeF size_ )
        {
            base.Scale(size_);
        }*/
    }
}
