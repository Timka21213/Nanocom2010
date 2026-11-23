using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NextUI.Component;
using NextUI.Frame;

namespace LinearDigitalDemo
{
    public partial class Form1 : Form
    {
        private Timer _timer = new Timer();
        private Timer _timer2 = new Timer();
        private string _msg = "nextwavesoft cool    ";
        private int count = 0;
        public Form1()
        {
            InitializeComponent();
            _timer.Interval = 500;
            _timer2.Interval = 1000;
            HorizontalFrame frame = new HorizontalFrame(new Rectangle(10, 10, 500, 200));
            
            this.baseUI1.Frame.Add(frame);
            this.baseUI1.Interact = true;
            frame.FrameRenderer.Outline = NextUI.Renderer.FrameRender.FrameOutline.Type5;
            frame.BackRenderer.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.Solid;
            frame.BackRenderer.CenterColor = Color.Black;
            frame.BackRenderer.EndColor = Color.Black;

            HorizontalScaleBar bar = new HorizontalScaleBar(frame);
            frame.ScaleCollection.Add(bar);
            bar.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.Solid;
            bar.ScaleBarSize = 4;
            bar.OffsetFromFrame = 40;
            bar.FillColor = Color.White;
            bar.StartValue = 0;
            bar.EndValue = 200;
            bar.MinorTicknumber = 5;
            bar.MajorTickNumber = 11;
            bar.TickMinor.Width = 2;
            bar.TickMinor.EnableGradient = false;
            bar.TickMinor.EnableBorder = false;
            bar.TickMinor.FillColor = Color.White;
            bar.TickMinor.TickPosition = TickBase.Position.Outer;
            bar.TickMajor.Width = 6;
            bar.TickMajor.TickPosition = TickBase.Position.Outer;
            bar.TickMajor.EnableGradient = false;
            bar.TickMajor.EnableBorder = false;
            bar.TickMajor.FillColor = Color.White;
            bar.TickLabel.OffsetFromScale = 20;
            bar.TickLabel.LabelPostion = ScaleLabel.Position.Outer;
            bar.TickLabel.LabelFont = new Font(FontFamily.GenericMonospace, 13,FontStyle.Bold);
            bar.TickLabel.FontColor = Color.White;


            LinearRange range = new LinearRange(frame);
            range.StartWidth = 15;
            range.EndWidth = 15;
            range.StartValue = 0;
            range.EndValue = 0;
            range.RangePosition = RangeBase.Position.Outer;
            range.EnableGradient = false;
            range.Opaque = 255;
            range.FillColor = Color.Silver;

            bar.Range.Add(range);

            HorizontalPointer pointer = new HorizontalPointer(frame);
            pointer.PointerPosition = HorizontalPointer.Position.Cross;
            pointer.BasePointer.FillColor = Color.Red;

            bar.Pointer.Add(pointer);
            bar.Drag += new HorizontalScaleBar.OnDrag(bar_Drag);

            NumericalFrame innerframe = new NumericalFrame(new Rectangle( 25, frame.Rect.Height / 2 - 20, 100, 80));
            innerframe.FrameRenderer.Outline = NextUI.Renderer.FrameRender.FrameOutline.None;
            innerframe.BackRenderer.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.None;
            for (int i = 0; i < 4; i++)
            {
                DigitalPanel14Segment seg = new DigitalPanel14Segment(innerframe);
                seg.BackColor = Color.Black;
                seg.FontThickness = 2;
                seg.MainColor = Color.White;
                seg.EnableBorder = false;
                innerframe.Indicator.Panels.Add(seg);
            }
            innerframe.Indicator.RoundedOff = true;
            innerframe.Indicator.RoundedValue = 1;
            frame.FrameCollection.Add(innerframe);


            NumericalFrame innerframe2 = new NumericalFrame(new Rectangle(150, frame.Rect.Height / 2 - 20, 350, 80));
            innerframe2.FrameRenderer.Outline = NextUI.Renderer.FrameRender.FrameOutline.None;
            innerframe2.BackRenderer.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.None;
            for (int i = 0; i < 15; i++)
            {
                DigitalPanel14Segment seg = new DigitalPanel14Segment(innerframe2);
                seg.BackColor = Color.Black;
                seg.FontThickness = 2;
                seg.MainColor = Color.Yellow;
                seg.EnableBorder = false;
                seg.EnableGlare = true;
                innerframe2.Indicator.Panels.Add(seg);
            }
            innerframe2.Indicator.RoundedOff = true;
            innerframe2.Indicator.RoundedValue = 1;
            frame.FrameCollection.Add(innerframe2);


            //Bottom 

            HorizontalFrame bframe = new HorizontalFrame(new Rectangle(10, 10, 500, 200));
            this.baseUI2.Frame.Add(bframe);
            bframe.FrameRenderer.Outline = NextUI.Renderer.FrameRender.FrameOutline.Type5;

            HorizontalScaleBar bbar1 = new HorizontalScaleBar(bframe);
            bframe.ScaleCollection.Add(bbar1);
            bbar1.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.Solid;
            bbar1.Visible = false;
            bbar1.OffsetFromFrame = 40;
            bbar1.StartValue = 60;
            bbar1.EndValue = 0;
            bbar1.MinorTicknumber = 4;
            
            bbar1.MajorTickNumber = 13;
            bbar1.TickMinor.Width = 2;
            bbar1.TickMajor.Width = 6;
            bbar1.TickLabel.OffsetFromScale = 20;
            bbar1.TickLabel.LabelPostion = ScaleLabel.Position.Outer;
            bbar1.TickLabel.LabelFont = new Font(FontFamily.GenericMonospace, 13, FontStyle.Bold);
            bbar1.TickLabel.FontColor = Color.Black;


            HorizontalScaleBar bbar2 = new HorizontalScaleBar(bframe);
            bframe.ScaleCollection.Add(bbar2);
            bbar2.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.Solid;
        //    bbar2.ScaleBarSize = 4;
            bbar2.OffsetFromFrame = 100;
            bbar2.FillColor = Color.White;
            bbar2.Visible = false;
            bbar2.StartValue = 0;
            bbar2.EndValue = 60;
            bbar2.MinorTicknumber = 4;
            bbar2.MajorTickNumber = 13;
            bbar2.TickMinor.Width = 2;
            bbar2.TickMajor.Width = 6;
            bbar2.TickMajor.FillColor = Color.DarkBlue;
            bbar2.TickLabel.OffsetFromScale = 20;
            bbar2.TickLabel.LabelPostion = ScaleLabel.Position.Outer;
            bbar2.TickLabel.LabelFont = new Font(FontFamily.GenericMonospace, 13, FontStyle.Bold);
            bbar2.TickLabel.FontColor = Color.Black;


            HorizontalScaleBar bbar3 = new HorizontalScaleBar(bframe);
            bframe.ScaleCollection.Add(bbar3);
            bbar3.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.Solid;
            bbar3.ScaleBarSize = 4;
            bbar3.OffsetFromFrame = 160;
            bbar3.FillColor = Color.White;
            bbar3.StartValue = 1;
            bbar3.EndValue = 23;
            bbar3.MinorTicknumber = 4;
            bbar3.MajorTickNumber = 12;
            bbar3.TickMinor.Width = 2;
            bbar3.Visible = false;
            bbar3.TickMajor.FillColor = Color.DarkGreen;
            bbar3.TickMajor.Width = 6;
            bbar3.TickLabel.OffsetFromScale = 20;
            bbar3.TickLabel.LabelPostion = ScaleLabel.Position.Outer;
            bbar3.TickLabel.LabelFont = new Font(FontFamily.GenericMonospace, 13, FontStyle.Bold);
            bbar3.TickLabel.FontColor = Color.Black;

            HorizontalPointer pointerb1 = new HorizontalPointer(bframe);
            pointerb1.PointerPosition = HorizontalPointer.Position.Outer;
            pointerb1.BasePointer.Length = 15;
            pointerb1.BasePointer.FillColor = Color.Red;
            pointerb1.BasePointer.Shadow.Offset = 3;
            bbar1.Pointer.Add(pointerb1);

            HorizontalPointer pointerb2 = new HorizontalPointer(bframe);
            pointerb2.PointerPosition = HorizontalPointer.Position.Outer;
            pointerb2.BasePointer.Length = 15;
            pointerb2.BasePointer.FillColor = Color.DarkBlue;
            pointerb2.BasePointer.Shadow.Offset = 3;
            bbar2.Pointer.Add(pointerb2);

            HorizontalPointer pointerb3 = new HorizontalPointer(bframe);
            pointerb3.PointerPosition = HorizontalPointer.Position.Outer;
            pointerb3.BasePointer.Length = 15;
            pointerb3.BasePointer.FillColor = Color.DarkGreen;
            pointerb3.BasePointer.Shadow.Offset = 3;
            bbar3.Pointer.Add(pointerb3);

            FrameLabel lb1 = new FrameLabel(new Point(10, 20),bframe);
            lb1.FontColor = Color.DarkBlue;
            lb1.LabelFont = new Font(FontFamily.GenericMonospace, 13, FontStyle.Bold | FontStyle.Italic);
            lb1.Shadow.Offset = 2;
            lb1.LabelText = "Seconds";
            FrameLabel lb2 = new FrameLabel(new Point(10, 80),bframe);
            lb2.FontColor = Color.DarkBlue;
            lb2.LabelFont = new Font(FontFamily.GenericMonospace, 13, FontStyle.Bold | FontStyle.Italic);
            lb2.Shadow.Offset = 2;
            lb2.LabelText = "Minutes";
            FrameLabel lb3 = new FrameLabel(new Point(10, 140),bframe);
            lb3.FontColor = Color.DarkBlue;
            lb3.LabelFont = new Font(FontFamily.GenericMonospace, 13, FontStyle.Bold | FontStyle.Italic);
            lb3.Shadow.Offset = 2;
            lb3.LabelText = "Hours";

            bframe.FrameLabelCollection.Add(lb1);
            bframe.FrameLabelCollection.Add(lb2);
            bframe.FrameLabelCollection.Add(lb3);


            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Start();

            _timer2.Tick += new EventHandler(_timer2_Tick);
            _timer2.Start();
            
        }

        void _timer2_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            ((HorizontalFrame)(this.baseUI2.Frame[0])).ScaleCollection[0].Pointer[0].Value = (float)dt.Second;
            ((HorizontalFrame)(this.baseUI2.Frame[0])).FrameLabelCollection[0].LabelText = dt.Second +  " Seconds";
            ((HorizontalFrame)(this.baseUI2.Frame[0])).ScaleCollection[1].Pointer[0].Value = (float)dt.Minute;
            ((HorizontalFrame)(this.baseUI2.Frame[0])).FrameLabelCollection[1].LabelText = dt.Minute + " Minutes";
            ((HorizontalFrame)(this.baseUI2.Frame[0])).ScaleCollection[2].Pointer[0].Value = (float)dt.Hour;
            ((HorizontalFrame)(this.baseUI2.Frame[0])).FrameLabelCollection[2].LabelText = dt.Hour + " Hours";
        }



        void _timer_Tick(object sender, EventArgs e)
        {
            if (count >= _msg.Length)
            {
                count = 0;
            }

            string str1 = _msg.Substring(count);
      
            ((NumericalFrame)((HorizontalFrame)this.baseUI1.Frame[0]).FrameCollection[1]).Indicator.DisplayValue = str1;
 
            count++;
        }

        void bar_Drag(object sender, float value)
        {
            ((HorizontalFrame)this.baseUI1.Frame[0]).ScaleCollection[0].Range[0].EndValue = value;

            ((NumericalFrame)((HorizontalFrame)this.baseUI1.Frame[0]).FrameCollection[0]).Indicator.DisplayValue = Convert.ToString(value);
        }
    }
}