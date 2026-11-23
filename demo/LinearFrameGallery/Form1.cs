using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NextUI.Frame;
using NextUI.Component;

namespace LinearFrameGallery
{
    public partial class Form1 : Form
    {
        private Timer _timer = new Timer();
        private int val = 0;
        public Form1()
        {
            _timer.Interval = 250;
            InitializeComponent();
            //Horizontal Frame 1
            HorizontalFrame f1 = new HorizontalFrame(new Rectangle(10,10,500,80));
            this.baseUI1.Frame.Add(f1);
            f1.FrameRenderer.Outline = NextUI.Renderer.FrameRender.FrameOutline.None;
            f1.BackImage = Image.FromFile(@"../../sample.png");

            HorizontalScaleBar bar1 = new HorizontalScaleBar(f1);
            bar1.BorderStyle = ScaleBase.Style.NotSet;
            bar1.StartValue = 0;
            bar1.EndValue = 100;
            bar1.ScaleBarSize = 2;
            bar1.EndColor = Color.White;
            bar1.OffsetFromFrame = 30;
            bar1.MinorTicknumber = 5;
            bar1.MajorTickNumber = 11;
            bar1.TickMajor.Width = 5;
            bar1.TickMajor.FillColor = Color.DarkRed;
            bar1.TickMinor.FillColor = Color.DarkOrange;
            bar1.TickMajor.Height = 15;
            bar1.TickMinor.Width = 2;
            bar1.TickMinor.Height = 5;
            bar1.TickMajor.Shadow.Offset = 3;
            bar1.TickLabel.FontColor = Color.Black;

            HorizontalPointer ptr = new HorizontalPointer(f1);
            ptr.BasePointer.Shadow.Offset = 3;
            ptr.BasePointer.PointerShapeType = Pointerbase.PointerType.Type4;

            bar1.Pointer.Add(ptr);
            f1.ScaleCollection.Add(bar1);

            //Horizontal Frame 2
            HorizontalFrame f2 = new HorizontalFrame(new Rectangle(10,10,500,80));
            this.baseUI2.Frame.Add(f2);
            f2.Type = HorizontalFrame.FrameType.RoundedRectangle;
            f2.BackRenderer.CenterColor = Color.Black;

            HorizontalScaleBar bar2 = new HorizontalScaleBar(f2);
            bar2.BorderStyle = ScaleBase.Style.NotSet;
            bar2.FillColor = Color.White;
            bar2.OffsetFromFrame = 20;
            bar2.MinorTicknumber = 5;
            bar2.TickMajor.Width = 3;
            bar2.TickMajor.Height = 8;
            bar2.TickMinor.Width = 2;
            bar2.TickMinor.Height = 5;

            f2.ScaleCollection.Add(bar2);


            LinearRange r2 = new LinearRange(f2);
            r2.Opaque = 255;
            r2.StartValue = 0;
            r2.EndValue = 20;
            r2.StartWidth = 10;
            r2.EndWidth = 10;
            r2.FillColor = Color.DodgerBlue;
            r2.EndColor = Color.DarkBlue;
            r2.BorderColor = Color.DarkOrange;
            bar2.Range.Add(r2);

            LinearRange r3 = new LinearRange(f2);
            r3.Opaque = 255;
            r3.StartValue = 70;
            r3.EndValue = 100;
            r3.StartWidth = 3;
            r3.EndWidth = 15;
            r3.RangePosition = RangeBase.Position.Outer;
            r3.OffsetFromScale = 5;
            bar2.Range.Add(r3);

            f2.ScaleCollection.Add(bar2);

            //Horizontal Frame 3
            HorizontalFrame f3 = new HorizontalFrame(new Rectangle(10,10,500,80));
            this.baseUI3.Frame.Add(f3);
            f3.Type = HorizontalFrame.FrameType.RoundedRectangle;
            f3.FrameRenderer.Outline = NextUI.Renderer.FrameRender.FrameOutline.Type4;
            f3.FrameRenderer.MainColor = Color.DarkBlue;
            f3.FrameRenderer.FrameWidth = 7;
            f3.BackRenderer.EndColor = Color.Black;

            HorizontalScaleBar bar3 = new HorizontalScaleBar(f3);
            bar3.BorderStyle = ScaleBase.Style.NotSet;
            bar3.ScaleBarSize = 2;
            bar3.EndColor = Color.White;
            bar3.OffsetFromFrame = 30;
            bar3.MinorTicknumber = 5;
            bar3.TickMajor.Width = 3;
            bar3.TickMajor.FillColor = Color.DarkBlue;
            bar3.TickMinor.FillColor = Color.DarkBlue;
            bar3.TickMajor.Height = 8;
            bar3.TickMinor.Width = 2;
            bar3.TickMinor.Height = 5;
            bar3.TickLabel.FontColor = Color.White;

            HorizontalScaleBar bar4 = new HorizontalScaleBar(f3);
            bar4.ScaleBarSize = 2;
            bar4.BorderStyle = ScaleBase.Style.NotSet;
            bar4.EndColor = Color.White;
            bar4.OffsetFromFrame = 20;
            bar4.MinorTicknumber = 5;
            bar4.TickMajor.Width = 3;
            bar4.TickMajor.FillColor = Color.DarkBlue;
            bar4.TickMinor.FillColor = Color.DarkBlue;
            bar4.TickMajor.Height = 8;
            bar4.TickMinor.Width = 2;
            bar4.TickMinor.Height = 5;
            bar4.TickLabel.FontColor = Color.White;
            bar4.TickLabel.LabelPostion = ScaleLabel.Position.Outer;
            bar4.TickLabel.OffsetFromScale = 1;

            LinearRange r4 = new LinearRange(f3);
            r4.Opaque = 255;
            r4.StartValue = 0;
            r4.EndValue = 20;
            r4.StartWidth = 8;
            r4.EndWidth = 8;
            r4.FillColor = Color.Yellow;
            r4.EndColor = Color.DarkBlue;
            r4.BorderColor = Color.DarkOrange;
            r4.RangePosition = RangeBase.Position.Inner;
            bar4.Range.Add(r4);

            f3.ScaleCollection.Add(bar3);
            f3.ScaleCollection.Add(bar4);

            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Start();
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            val++;
            if (val == 100)
            {
                val = 0;
            }
            ((HorizontalFrame)this.baseUI1.Frame[0]).ScaleCollection[0].Pointer[0].Value = val;
            ((HorizontalFrame)this.baseUI2.Frame[0]).ScaleCollection[0].Range[0].EndValue = val;
            ((HorizontalFrame)this.baseUI3.Frame[0]).ScaleCollection[1].Range[0].EndValue = val;
        }
    }
}