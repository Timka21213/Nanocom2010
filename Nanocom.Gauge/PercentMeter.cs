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
    public partial class PercentMeter : Gauge   
    {
        private CircularPointer _pointer;
        FrameLabel _percentLabel;
        public PercentMeter()
        {
            InitializeComponent();

            CircularFrame frame = CreateCircularFrame();
            this.Frame.Add(frame);

            CircularScaleBar bar = CreateCircularScaleBar(frame);
         
            bar.StartValue = 0;
            bar.EndValue = 100;
            
            bar.StartAngle = 0;
            bar.SweepAngle = 180;
            
            bar.MajorTickNumber = 6;
            bar.MinorTicknumber = 1;
            
            bar.TickLabel.LabelFont = CreateTickLabelFont(1.2F);

            frame.ScaleCollection.Add(bar);

            _pointer = CreateCircularPointer(frame);
            bar.Pointer.Add(_pointer);

            _percentLabel = CreateFrameLabel(frame, " 0 %");
            MoveFrameLabel(_percentLabel, 0, 35);
            frame.FrameLabelCollection.Add(_percentLabel);
            SetPercentLabel();


        }
        internal void SetPercentLabel()
        {
            _percentLabel.LabelText = String.Format("{0} %", Value.ToString("0"));
        }

        public float Value
        {
            get
            {
                return _pointer.Value;
            }
            set
            {
                if( value != _pointer.Value )
                {
                    _pointer.Value = value;
                    SetPercentLabel();
                }
            }
        }
        /*
        new void Scale( SizeF size_ )
        {
            base.Scale(size_);
        }*/
    }
}
