using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NextUI.Component;
using NextUI.Frame;

namespace DemoClock
{
    public partial class Form1 : Form
    {
        private Timer _timer = new Timer();
        public Form1()
        {
            InitializeComponent();
            _timer.Interval = 1000;
            _timer.Tick += new EventHandler(_timer_Tick);
            CircularFrame frame = new CircularFrame(new Point(20, 20), 200);
            this.baseUI1.Frame.Add(frame);
            frame.BackRenderer.CenterColor = Color.Black;
            frame.BackRenderer.EndColor = Color.LightSkyBlue;
            frame.FrameRenderer.FrameWidth = 10;

            CircularScaleBar bar = new CircularScaleBar(frame);
            bar.ScaleBarSize = 1;
            bar.MajorTickNumber = 12;
            bar.MinorTicknumber = 5;
            bar.SweepAngle = 0f;
            bar.StartAngle = 270f;
            bar.Visible = false;
            bar.TickMajor.Width = 2;
            bar.TickMajor.Height = 10;
            bar.TickMajor.EnableBorder = false;
            bar.TickMajor.EnableGradient = false;
            bar.TickMajor.FillColor = Color.White;
            bar.TickMinor.Width = 2;
            bar.TickMinor.Height = 5;
            bar.TickMinor.EnableBorder = false;
            bar.TickMinor.EnableGradient = false;
            bar.TickMinor.FillColor = Color.White;
            bar.TickMajor.TickPosition = TickBase.Position.Inner;
            bar.TickMinor.TickPosition = TickBase.Position.Inner;
            bar.StartValue = 0;
            bar.EndValue = 60;
            bar.TickLabel.LabelFont = new Font(FontFamily.GenericSerif,13, FontStyle.Bold | FontStyle.Italic);
            bar.TickLabel.Shadow.Offset = 3;
            bar.TickLabel.TextDirection = CircularLabel.Direction.Horizontal;
            bar.TickLabel.OffsetFromScale = 20;
            bar.OffsetFromFrame = -4;
            bar.CustomLabel = new string[] { "12", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" };

            frame.ScaleCollection.Add(bar);

            CircularPointer hourpointer = new CircularPointer(frame);
            CircularPointer minutepointer = new CircularPointer(frame);
            CircularPointer secondpointer = new CircularPointer(frame);

            hourpointer.BasePointer.Length = 50;
            hourpointer.BasePointer.Width = 8;
            hourpointer.BasePointer.Shadow.Offset = 3;

            minutepointer.BasePointer.Length = 80;
            minutepointer.BasePointer.Width = 5;
            minutepointer.BasePointer.Shadow.Offset = 3;

            secondpointer.BasePointer.Width = 3;
            secondpointer.BasePointer.Length = 70;
            secondpointer.BasePointer.Shadow.Offset = 3;
            secondpointer.BasePointer.PointerShapeType = Pointerbase.PointerType.Type2;
            secondpointer.BasePointer.EnableGradient = false;
            secondpointer.BasePointer.FillColor = Color.Red;

            bar.Pointer.Add(hourpointer);
            bar.Pointer.Add(minutepointer);
            bar.Pointer.Add(secondpointer);

            CircularFrame seconds = new CircularFrame(new Point(frame.Rect.Width / 2 - 25, frame.Rect.Height / 2 - 60), 50);
            frame.FrameCollection.Add(seconds);
            seconds.FrameRenderer.FrameWidth = 1;
            seconds.FrameRenderer.Outline = NextUI.Renderer.FrameRender.FrameOutline.Type1;

            CircularScaleBar ibar = new CircularScaleBar(seconds);
            ibar.ScaleBarSize = 3;
            ibar.BorderStyle = ScaleBase.Style.NotSet;
            ibar.MajorTickNumber = 6;
            ibar.MinorTicknumber = 2;
            ibar.SweepAngle = 0f;
            ibar.TickMajor.Width = 2;
            ibar.TickMajor.Height = 10;
            ibar.TickMajor.EnableBorder = false;
            ibar.TickMajor.FillColor = Color.Black;
            ibar.TickMajor.EnableGradient = false;
            ibar.TickMinor.Width = 2;
            ibar.TickMinor.Height = 5;
            ibar.TickMinor.EnableBorder = false;
            ibar.TickMinor.FillColor = Color.Black;
            ibar.TickMinor.EnableGradient = false;
            ibar.StartValue = 1;
            ibar.EndValue = 61;
            ibar.OffsetFromFrame = -2;
            ibar.TickLabel.LabelFont = new Font(FontFamily.GenericMonospace, 5,FontStyle.Italic|FontStyle.Bold);
            ibar.TickLabel.TextDirection = CircularLabel.Direction.Horizontal;
            seconds.ScaleCollection.Add(ibar);

            CircularPointer inner = new CircularPointer(seconds);
            inner.BasePointer.Length = 15;
            inner.BasePointer.Width = 2;
            inner.BasePointer.Shadow.Offset = 1;
            inner.CapOnTop = false;

            ibar.Pointer.Add(inner);

            string fb = "nextwavesoft.com";
            Font fbf =  new Font(FontFamily.GenericMonospace, 8,FontStyle.Italic|FontStyle.Bold);
            Size z = TextRenderer.MeasureText(fb,fbf);
            FrameLabel fl = new FrameLabel(new Point(frame.Rect.Width / 2 - z.Width/3, frame.Rect.Height / 2+ 30),frame);
            fl.LabelFont = fbf;
            fl.LabelText = fb;
  
            
            frame.FrameLabelCollection.Add(fl);



            NumericalFrame nframe2 = new NumericalFrame(new Rectangle(20, 250, 400, 50));
            nframe2.FrameRenderer.Outline = NextUI.Renderer.FrameRender.FrameOutline.Type1;
            nframe2.FrameRenderer.FrameWidth = 1;
            

            for (int i = 0; i < 22; i++)
            {
                DigitalPanel14Segment seg = new DigitalPanel14Segment(nframe2);
                seg.BackColor = Color.DarkBlue;
                seg.FontThickness = 2;
                seg.MainColor = Color.White;
                seg.FontThickness = 2;
                seg.EnableBorder = false;
              //  seg.EnableGlare = true;
                nframe2.Indicator.Panels.Add(seg);
            }
            this.baseUI1.Frame.Add(nframe2);

            _timer.Start();
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            int hour = 0;
            NumericalFrame fr = ((NumericalFrame)this.baseUI1.Frame[1]);
            fr.Indicator.DisplayValue = dt.ToString();
            ((CircularFrame)this.baseUI1.Frame[0]).ScaleCollection[0].Pointer[2].Value = (int)dt.Second;
            ((CircularFrame)((CircularFrame)this.baseUI1.Frame[0]).FrameCollection[0]).ScaleCollection[0].Pointer[0].Value = (int)dt.Second;
            if (dt.Hour <= 12)
            {
                hour = dt.Hour * 5;
            }
            else
            {
                hour = (dt.Hour - 12) * 5;

            }
            ((CircularFrame)this.baseUI1.Frame[0]).ScaleCollection[0].Pointer[0].Value = (int)hour;
            ((CircularFrame)this.baseUI1.Frame[0]).ScaleCollection[0].Pointer[1].Value = (int)dt.Minute;
  
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }


    }
}