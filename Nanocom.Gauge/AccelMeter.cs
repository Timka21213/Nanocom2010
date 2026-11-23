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
    public partial class AccelMeter : Gauge
    {
    
        HorizontalFrame frame; 
        private const int NumAccel = 3;
        HorizontalPointer [] _pointer = new HorizontalPointer[NumAccel];
        HorizontalPointer _pointerSupply = null;

        public AccelMeter()
        {
            InitializeComponent();

            frame = this.CreateHorizontalFrame();
            this.Frame.Add(frame);

            FrameLabel label = AddBaseFrameLabel("Accelerator");
            MoveFrameLabel(label, 0, 5);


            HorizontalScaleBar[] bar = new HorizontalScaleBar[NumAccel];
            for( int i=0; i < bar.Length; i++ )
            {
                bar[i] = CreateHorizontalScaleBar(frame);

                HorizontalScaleBar b = bar[i];
                b.OffsetFromFrame = 15+i*30;
                
                b.StartValue = 0;
                b.EndValue = 100;
                
                b.MajorTickNumber = 3;
                b.MinorTicknumber = 4;

                b.TickLabel.Visible = ((i + 1) < bar.Length) ? false : true;
                
                frame.ScaleCollection.Add(b);

                _pointer[i] = CreateHorizontalPointer(frame);
                b.Pointer.Add(_pointer[i]);
            }

            HorizontalScaleBar sBar = CreateHorizontalScaleBar(frame);
            sBar.OffsetFromFrame = 120;

            sBar.StartValue = 4;
            sBar.EndValue = 6;

            sBar.MajorTickNumber = 3;
            sBar.MinorTicknumber = 9;

            frame.ScaleCollection.Add(sBar);

            LinearRange r1 = CreateLinearRange(frame);
            r1.StartValue = 4;
            r1.EndValue = 4.5F;
            sBar.Range.Add(r1);

            LinearRange r2 = CreateLinearRange(frame);
            r2.StartValue = 5.5F;
            r2.EndValue = 6;
            sBar.Range.Add(r2);

            _pointerSupply = CreateHorizontalPointer(frame);
            sBar.Pointer.Add(_pointerSupply);

        }

        /// <summary>
        /// Cylinder 1 Balance [-20..+20]
        /// </summary>
        public float Value1
        {
            get
            {
                return _pointer[0].Value;
            }
            set
            {
                _pointer[0].Value = value;
            }
        }

        /// <summary>
        /// Cylinder 2 Balance [-20..+20]
        /// </summary>
        public float Value2
        {
            get
            {
                return _pointer[1].Value;
            }
            set
            {
                _pointer[1].Value = value;
            }
        }

        /// <summary>
        /// Cylinder 3 Balance [-20..+20]
        /// </summary>
        public float Value3
        {
            get
            {
                return _pointer[2].Value;
            }
            set
            {
                _pointer[2].Value = value;
            }
        }

        /// <summary>
        /// Cylinder 4 Balance [-20..+20]
        /// </summary>
        public float ValueSupply
        {
            get
            {
                return _pointerSupply.Value;
            }
            set
            {
                _pointerSupply.Value = value;
            }
        }
        /*
        new void Scale( SizeF size_ )
        {
            base.Scale(size_);
        }*/
    }
}
