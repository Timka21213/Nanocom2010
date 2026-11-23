using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NextUI.Frame;
using NextUI.Component;

namespace CircularFrameGallery
{
    public partial class Form1 : Form
    {
        private Timer _timer = new Timer();
        private int value = 0;
        public Form1()
        {
            InitializeComponent();
            _timer.Interval = 250;
            //CircularFrame 1:
            CircularFrame f1 = new CircularFrame(new Point(20, 20), 180);
            this.baseUI1.Frame.Add(f1);
            f1.FrameImage = Image.FromFile(@"../../sample.png");
            f1.BackRenderer.CenterColor = Color.Black;
            CircularScaleBar bar1 = new CircularScaleBar(f1);
            bar1.OffsetFromFrame = 15;
            bar1.ScaleBarSize = 3;
            bar1.BorderStyle = ScaleBase.Style.NotSet;
            bar1.TickMajor.Width = 3;
            bar1.TickMajor.Height = 8;
            bar1.TickMajor.FillColor = Color.DarkBlue;
            bar1.TickMinor.Width = 2;
            bar1.TickMinor.Height = 4;
            bar1.TickMinor.FillColor = Color.DarkBlue;

            bar1.TickLabel.LabelFont = new Font("Elephant", 10,FontStyle.Bold);
            bar1.TickLabel.TextDirection = CircularLabel.Direction.Horizontal;
            bar1.TickLabel.OffsetFromScale = 15;
       
            f1.ScaleCollection.Add(bar1);

            CircularPointer pointer = new CircularPointer(f1);
            pointer.BasePointer.PointerImage = Image.FromFile(@"../../pointer.png");
            pointer.BasePointer.Shadow.Visible = false;
            bar1.Pointer.Add(pointer);
            pointer.BasePointer.OffsetFromCenter = -10;
            pointer.BasePointer.Length = 70;

            //CircularFrame 2:
            CircularFrame f2 = new CircularFrame(new Point(20, 20), 180);
            f2.FrameRenderer.MainColor = Color.DarkSlateBlue;
            f2.FrameRenderer.Outline = NextUI.Renderer.FrameRender.FrameOutline.Type4;
            f2.FrameRenderer.FrameWidth = 10;
            f2.BackRenderer.CenterColor = Color.White;
            f2.BackRenderer.EndColor = Color.DeepSkyBlue;
            f2.BackRenderer.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.DiagonalLeft;
            this.baseUI2.Frame.Add(f2);

            CircularScaleBar bar2 = new CircularScaleBar(f2);
            bar2.ScaleBarSize = 3;
            bar2.BorderStyle = ScaleBase.Style.NotSet;
            bar2.TickMajor.Width = 3;
            bar2.TickMajor.Height = 8;
            bar2.TickMajor.FillColor = Color.DarkBlue;
            bar2.TickMajor.TickPosition = TickBase.Position.Inner;

            bar2.TickMinor.Width = 2;
            bar2.TickMinor.Height = 4;
            bar2.TickMinor.FillColor = Color.DarkBlue;
            bar2.TickMinor.TickPosition = TickBase.Position.Inner;

            bar2.TickLabel.LabelPostion = ScaleLabel.Position.Outer;
            bar2.TickLabel.TextDirection = CircularLabel.Direction.Horizontal;
            bar2.TickLabel.OffsetFromScale = 6;
            bar2.TickLabel.FontColor = Color.DarkViolet;

            bar2.Shadow.Offset = 3;

            f2.ScaleCollection.Add(bar2);

            CircularRange range = new CircularRange(f2);
            range.RangePosition = RangeBase.Position.Inner;
            range.StartValue = 60;
            range.EndValue = 100;
            range.StartWidth = 10;
            range.EndWidth = 10;
            range.FillColor = Color.DarkRed;
            bar2.Range.Add(range);

            CircularPointer pointer2 = new CircularPointer(f2);
            pointer2.BasePointer.PointerShapeType = Pointerbase.PointerType.Type2;
            pointer2.BasePointer.Width = 7;
            pointer2.BasePointer.Length = 70;
            pointer2.BasePointer.Shadow.Offset = 3;
            pointer2.CapPointer.FillColor = Color.DarkSlateBlue;
            pointer2.BasePointer.OffsetFromCenter = -20;
            pointer2.BasePointer.FillColor = Color.DarkRed;

            bar2.Pointer.Add(pointer2);

            //CircularFrame 3:
            CircularFrame f3 = new CircularFrame(new Point(20, 20), 180);
            this.baseUI3.Frame.Add(f3);
            f3.BackRenderer.CenterColor = Color.White;
            f3.BackRenderer.EndColor = Color.Black;

            CircularScaleBar bar3 = new CircularScaleBar(f2);
            bar3.ScaleBarSize = 3;
            bar3.BorderStyle = ScaleBase.Style.NotSet;
            bar3.TickMajor.Width = 3;
            bar3.TickMajor.Height = 8;
            bar3.TickMajor.FillColor = Color.DarkBlue;
            bar3.TickMinor.Width = 2;
            bar3.TickMinor.Height = 4;
            bar3.TickMinor.FillColor = Color.DarkBlue;
            bar3.TickLabel.FontColor = Color.White;

            CircularScaleBar bar4 = new CircularScaleBar(f2);
            bar4.OffsetFromFrame = 40;
            bar4.ScaleBarSize = 3;
            bar4.BorderStyle = ScaleBase.Style.NotSet;
            bar4.TickMajor.Width = 3;
            bar4.TickMajor.Height = 8;
            bar4.TickMinor.Width = 2;
            bar4.TickMinor.Height = 4;
            bar4.TickMajor.FillColor = Color.Yellow;
            bar4.TickMinor.FillColor = Color.Yellow;
            bar4.TickLabel.FontColor = Color.White;

            f3.ScaleCollection.Add(bar3);
            f3.ScaleCollection.Add(bar4);

            CircularMarker m1 = new CircularMarker(f3);
            m1.BasePointer.FillColor = Color.Firebrick;
            m1.BasePointer.Shadow.Offset = 3;
            m1.PointerPosition = HorizontalPointer.Position.Inner;
            bar3.Marker.Add(m1);
            CircularMarker m2 = new CircularMarker(f3);
            m2.BasePointer.FillColor = Color.Firebrick;
            m2.BasePointer.Shadow.Offset = 3;
            m2.PointerPosition = HorizontalPointer.Position.Inner;
            bar4.Marker.Add(m2);

            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Start();
            
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            value++;
            if (value == 100)
            {
                value = 0;
            }
            ((CircularFrame)(this.baseUI1.Frame[0])).ScaleCollection[0].Pointer[0].Value = value;
            ((CircularFrame)(this.baseUI2.Frame[0])).ScaleCollection[0].Pointer[0].Value = value;
            ((CircularFrame)(this.baseUI3.Frame[0])).ScaleCollection[0].Marker[0].Value = value;
            ((CircularFrame)(this.baseUI3.Frame[0])).ScaleCollection[1].Marker[0].Value = value;
        }


    }
}