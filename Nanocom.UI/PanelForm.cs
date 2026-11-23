using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NextUI.Component;
using NextUI.Frame;

namespace DemoSpeedoPanel
{
    public partial class PanelForm : Form
    {
        private Timer _timer = new Timer();
        private int val = 0;
        public PanelForm()
        {
            _timer.Interval = 100;
            _timer.Tick += new EventHandler(_timer_Tick);
            InitializeComponent();
            CircularFrame frame = new CircularFrame(new Point(this.baseUI1.Width/2 - 150, 20), 300);
            this.baseUI1.Frame.Add(frame);
            frame.BackRenderer.CenterColor = Color.Black;
            frame.BackRenderer.EndColor = Color.Black;
            frame.FrameRenderer.Outline = NextUI.Renderer.FrameRender.FrameOutline.None;

            CircularScaleBar bar = new CircularScaleBar(frame);
            bar.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.Solid;
            bar.ScaleBarSize = 4;
            bar.FillColor = Color.White;
            bar.StartValue = 0;
            bar.EndValue = 180;
            bar.StartAngle = 50;
            bar.SweepAngle = 80;
            bar.MajorTickNumber = 10;
            //bar.MinorTicknumber = 2;
            bar.MinorTicknumber = 3;
            bar.TickMajor.EnableGradient = false;
            bar.TickMajor.EnableBorder = false;
            bar.TickMajor.FillColor = Color.White;
            bar.TickMajor.Height = 15;
            bar.TickMajor.Width = 10;
            bar.TickMajor.Type = TickBase.TickType.RoundedRect;
            bar.TickMinor.EnableGradient = false;
            bar.TickMinor.EnableBorder = false;
            bar.TickMinor.FillColor = Color.White;
            bar.TickMajor.TickPosition = TickBase.Position.Inner;
            bar.TickMinor.TickPosition = TickBase.Position.Inner;
            bar.TickLabel.TextDirection = CircularLabel.Direction.Horizontal;
            bar.TickLabel.OffsetFromScale = 35;
            bar.TickLabel.LabelFont = new Font(FontFamily.GenericMonospace, 12, FontStyle.Bold);
            bar.TickLabel.FontColor = Color.White;


            CircularScaleBar bar2 = new CircularScaleBar(frame);
            bar2.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.Solid;
            bar2.ScaleBarSize = 2;
            bar2.OffsetFromFrame = 80;
            bar2.FillColor = Color.White;
            bar2.StartValue = 0;
            bar2.EndValue = 320;
            bar2.StartAngle = 50;
            bar2.SweepAngle = 80;
            bar2.MajorTickNumber = 11;
            bar2.MinorTicknumber = 2;
            bar2.TickMajor.EnableGradient = false;
            bar2.TickMajor.EnableBorder = false;
            bar2.TickMajor.FillColor = Color.White;
            bar2.TickMajor.Height = 8;
            bar2.TickMajor.Width = 3;
            bar2.TickMajor.Type = TickBase.TickType.RoundedRect;
            bar2.TickMinor.EnableGradient = false;
            bar2.TickMinor.EnableBorder = false;
            bar2.TickMinor.FillColor = Color.White;
            bar2.TickMinor.Width = 3;
            bar2.TickMinor.Height = 4;
            bar2.TickMajor.TickPosition = TickBase.Position.Inner;
            bar2.TickMinor.TickPosition = TickBase.Position.Inner;
            bar2.TickLabel.TextDirection = CircularLabel.Direction.Horizontal;
            bar2.TickLabel.OffsetFromScale = 17;
            bar2.TickLabel.LabelFont = new Font(FontFamily.GenericMonospace, 8, FontStyle.Bold);
            bar2.TickLabel.FontColor = Color.White;


            frame.ScaleCollection.Add(bar);
            frame.ScaleCollection.Add(bar2);

            CircularRange range = new CircularRange(frame);
            range.EnableGradient = false;
            range.StartValue = 160;
            range.EndValue = 200;
            range.StartWidth = 2;
            range.EndWidth = 20;
            range.RangePosition = RangeBase.Position.Inner;

            bar.Range.Add(range);

            CircularPointer pointer = new CircularPointer(frame);
            pointer.CapPointer.Visible = true;
            pointer.CapOnTop = false;
            pointer.BasePointer.Length = 150;
            pointer.BasePointer.FillColor = Color.Red;
            pointer.BasePointer.PointerShapeType = Pointerbase.PointerType.Type2;
            pointer.BasePointer.OffsetFromCenter = -30;

            bar.Pointer.Add(pointer);



            CircularFrame leftframe = new CircularFrame(new Point( 10 , 20), 200);
            this.baseUI1.Frame.Add(leftframe);
            leftframe.BackRenderer.CenterColor = Color.Black;
            leftframe.BackRenderer.EndColor = Color.Black;
            leftframe.FrameRenderer.Outline = NextUI.Renderer.FrameRender.FrameOutline.None;
            leftframe.Type = CircularFrame.FrameType.HalfCircle1;

            CircularScaleBar leftbar = new CircularScaleBar(leftframe);
            leftbar.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.Solid;
            leftbar.ScaleBarSize = 2;
            leftbar.TickMajor.FillColor = Color.White;
            leftbar.TickMinor.FillColor = Color.White;
            leftbar.MajorTickNumber = 5;
            leftbar.StartValue = 0;
            leftbar.EndValue = 180;
            leftbar.SweepAngle = 180;
            leftbar.StartAngle = 0;
            leftbar.CustomLabel = new string[] { "empty", "", "", "", "full" };
            leftbar.TickLabel.TextDirection = CircularLabel.Direction.Horizontal;
            leftbar.TickLabel.OffsetFromScale = 40;
            leftbar.TickLabel.LabelFont = new Font(FontFamily.GenericMonospace, 10, FontStyle.Bold);
            leftbar.TickLabel.FontColor = Color.White;
            leftframe.ScaleCollection.Add(leftbar);

            CircularMarker marker = new CircularMarker(leftframe);
            marker.BasePointer.FillColor = Color.Red;
            marker.PointerPosition = HorizontalPointer.Position.Inner;
            marker.BasePointer.Length = 20;
            marker.BasePointer.Width = 20;
            
            leftbar.Marker.Add(marker);
            Image m =  Image.FromFile(@"../../label.png");
            FrameLabel fbimage = new FrameLabel(new Point(leftframe.Rect.Width / 2 - m.Width / 2, leftframe.Rect.Height / 2 - 30), leftframe);
            fbimage.BackGrdImage = m;

            leftframe.FrameLabelCollection.Add(fbimage);



            CircularFrame leftdownframe = new CircularFrame(new Point(10, 180), 200);
            this.baseUI1.Frame.Add(leftdownframe);
            leftdownframe.BackRenderer.CenterColor = Color.Black;
            leftdownframe.BackRenderer.EndColor = Color.Black;
            leftdownframe.FrameRenderer.Outline = NextUI.Renderer.FrameRender.FrameOutline.None;
            leftdownframe.Type = CircularFrame.FrameType.HalfCircle1;
            CircularScaleBar leftdownbar = new CircularScaleBar(leftframe);
            leftdownbar.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.Solid;
            leftdownbar.ScaleBarSize = 2;
            leftdownbar.TickMajor.FillColor = Color.White;
            leftdownbar.TickMinor.FillColor = Color.White;
            leftdownbar.StartValue = 0;
            leftdownbar.EndValue = 200;
            leftdownbar.MajorTickNumber = 5;
            leftdownbar.SweepAngle = 180;
            leftdownbar.StartAngle = 0;
            leftdownbar.CustomLabel = new string[] { "cold", "", "", "", "hot" };
            leftdownbar.TickLabel.TextDirection = CircularLabel.Direction.Horizontal;
            leftdownbar.TickLabel.OffsetFromScale = 40;
            leftdownbar.TickLabel.LabelFont = new Font(FontFamily.GenericMonospace, 10, FontStyle.Bold);
            leftdownbar.TickLabel.FontColor = Color.White;
            leftdownframe.ScaleCollection.Add(leftdownbar);


            CircularRange leftdownrange = new CircularRange(leftdownframe);
            leftdownrange.RangePosition = RangeBase.Position.Inner;
            leftdownrange.StartWidth = 20;
            leftdownrange.EndWidth = 20;
            leftdownrange.StartValue = 1;
            leftdownrange.EndValue = 100;
            leftdownrange.FillColor = Color.Red;
            leftdownrange.EndColor = Color.LightSkyBlue;
            leftdownrange.EnableBorder = true;
            leftdownrange.BorderColor = Color.White;
            leftdownrange.Opaque = 255;

            leftdownbar.Range.Add(leftdownrange);


            CircularFrame righframe = new CircularFrame(new Point(this.baseUI1.Width - 260, 20), 250);
            this.baseUI1.Frame.Add(righframe);
            righframe.BackRenderer.CenterColor = Color.Black;
            righframe.BackRenderer.EndColor = Color.Black;
            righframe.FrameRenderer.Outline = NextUI.Renderer.FrameRender.FrameOutline.None;
            righframe.Type = CircularFrame.FrameType.HalfCircle3;

            CircularScaleBar rightbar = new CircularScaleBar(righframe);
            rightbar.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.Solid;
            rightbar.FillColor = Color.White;
            rightbar.ScaleBarSize = 2;
            rightbar.TickMajor.FillColor = Color.White;
            rightbar.TickMajor.TickPosition = TickBase.Position.Inner;
            rightbar.TickMajor.Width = 10;
            rightbar.TickMajor.Height = 15;
            rightbar.TickMinor.FillColor = Color.White;
            rightbar.TickMinor.TickPosition = TickBase.Position.Inner;
            //rightbar.MinorTicknumber = 5;
            //rightbar.MajorTickNumber = 8;
            rightbar.MinorTicknumber = 4;
            rightbar.MajorTickNumber = 5;
            rightbar.StartValue = 0;
            rightbar.EndValue = 5000;
            //rightbar.EndValue = 200;
            //rightbar.CustomLabel = new string[] { "1", "2", "3", "4", "5", "6", "7", "8" };
            rightbar.CustomLabel = new string[] { "1", "2", "3", "4", "5" };
            rightbar.SweepAngle = 180;
            rightbar.StartAngle = 90;
            rightbar.TickLabel.TextDirection = CircularLabel.Direction.Horizontal;
            rightbar.TickLabel.OffsetFromScale = 30;
            rightbar.TickLabel.LabelFont = new Font(FontFamily.GenericMonospace, 13, FontStyle.Bold);
            rightbar.TickLabel.FontColor = Color.White;
            righframe.ScaleCollection.Add(rightbar);

            CircularPointer rightpointer = new CircularPointer(righframe);
            rightpointer.BasePointer.Width = 10;
            rightpointer.BasePointer.Length = 100;
            rightpointer.BasePointer.FillColor = Color.Red;
            rightpointer.BasePointer.PointerShapeType = Pointerbase.PointerType.Type2;
            rightpointer.CapOnTop = false;
            rightpointer.BasePointer.OffsetFromCenter = -20;
            rightbar.Pointer.Add(rightpointer);

            FrameLabel rightlabel = new FrameLabel(new Point(righframe.Rect.Width / 2, righframe.Rect.Height / 2 - 30), righframe);
            rightlabel.LabelText = "1000 rpm";
            rightlabel.LabelFont = new Font(FontFamily.GenericMonospace, 13, FontStyle.Bold);
            rightlabel.FontColor = Color.White;

            righframe.FrameLabelCollection.Add(rightlabel);

            NumericalFrame nframe = new NumericalFrame(new Rectangle(frame.Rect.Width / 2 - 50, frame.Rect.Height - 60, 100, 30));
            nframe.FrameRenderer.Outline = NextUI.Renderer.FrameRender.FrameOutline.Type1;
            nframe.FrameRenderer.FrameWidth = 1;

            for (int i = 0; i < 3; i++)
            {
                DigitalPanel7Segment seg = new DigitalPanel7Segment(nframe);
                //seg.BackColor = Color.DarkBlue;
                seg.BackColor = Color.Black;
                //seg.FontThickness = 3;
                seg.FontThickness = 4;
                seg.MainColor = Color.White;
                nframe.Indicator.Panels.Add(seg);
            }
            frame.FrameCollection.Add(nframe);

            _timer.Start();
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            if ( val == 180 )
            {
                val = 80;
            }
            ((CircularFrame)this.baseUI1.Frame[0]).ScaleCollection[0].Pointer[0].Value = val;
            ((NumericalFrame)this.baseUI1.Frame[0].FrameCollection[0]).Indicator.DisplayValue = Convert.ToString(val);
            ((CircularFrame)this.baseUI1.Frame[1]).ScaleCollection[0].Marker[0].Value = (float)val;
            ((CircularFrame)this.baseUI1.Frame[2]).ScaleCollection[0].Range[0].EndValue = (float)val/2;
            // drehzahl
            ((CircularFrame)this.baseUI1.Frame[3]).ScaleCollection[0].Pointer[0].Value = val*25;
            val++;
    
        }
    }
}