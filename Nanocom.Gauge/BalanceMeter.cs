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
    public partial class BalanceMeter : Gauge
    {
    
        HorizontalFrame frame; 
        private const int NumCylinder = 5;
        HorizontalPointer [] _pointer = new HorizontalPointer[NumCylinder];

        public BalanceMeter()
        {
            InitializeComponent();

            frame = this.CreateHorizontalFrame();
            this.Frame.Add(frame);

            FrameLabel label = AddBaseFrameLabel("Cylinder Balance");
            MoveFrameLabel(label, 0, 5);


            HorizontalScaleBar[] bar = new HorizontalScaleBar[NumCylinder];
            for( int i=0; i < bar.Length; i++ )
            {
                bar[i] = CreateHorizontalScaleBar(frame);

                HorizontalScaleBar b = bar[i];
                b.OffsetFromFrame = 15+i*25;
                
                b.StartValue = -20;
                b.EndValue = +20;
                
                b.MajorTickNumber = 5;
                b.MinorTicknumber = 1;

                b.TickLabel.Visible = ((i + 1) < bar.Length) ? false : true;
                
                frame.ScaleCollection.Add(b);

                LinearRange range1 = CreateLinearRange(frame);
                range1.StartValue = -20;
                range1.EndValue = -10;
                b.Range.Add(range1);

                LinearRange range2 = CreateLinearRange(frame);
                range2.StartValue = 10;
                range2.EndValue = 20;
                b.Range.Add(range2);

                _pointer[i] = CreateHorizontalPointer(frame);
                b.Pointer.Add(_pointer[i]);
            }

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
        public float Value4
        {
            get
            {
                return _pointer[3].Value;
            }
            set
            {
                _pointer[3].Value = value;
            }
        }

        /// <summary>
        /// Cylinder 5 Balance [-20..+20]
        /// </summary>
        public float Value5
        {
            get
            {
                return _pointer[4].Value;
            }
            set
            {
                _pointer[4].Value = value;
            }
        }
        /*
        new void Scale( SizeF size_ )
        {
            base.Scale(size_);
        }*/
    }
}
