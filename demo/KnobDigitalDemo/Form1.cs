using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NextUI.Component;
using NextUI.Frame;

namespace KnobDigitalDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.baseUI1.Interact = true;
            NumericalFrame nframe = new NumericalFrame(new Rectangle(30 , 10 , 100, 40));
            nframe.FrameRenderer.Outline = NextUI.Renderer.FrameRender.FrameOutline.Type1;
            nframe.FrameRenderer.FrameWidth = 1;

            for (int i = 0; i < 6; i++)
            {
                DigitalPanel7Segment seg = new DigitalPanel7Segment(nframe);
                seg.BackColor = Color.DarkBlue;
                seg.FontThickness = 2;
                seg.MainColor = Color.White;
                nframe.Indicator.Panels.Add(seg);
            }
            nframe.Indicator.RoundedOff = true;
            nframe.Indicator.RoundedValue = 1;
            this.baseUI1.Frame.Add(nframe);


            CircularFrame knob1 = new CircularFrame(new Point(20, 90), 150);
            knob1.FrameRenderer.Outline = NextUI.Renderer.FrameRender.FrameOutline.None;
            knob1.BackRenderer.EndColor = Color.LightSkyBlue;
            this.baseUI1.Frame.Add(knob1);
            
            CircularScaleBar bar = new CircularScaleBar(knob1);
            bar.TickMajor.TickPosition = TickBase.Position.Outer;
            bar.FillColor = Color.DarkSlateBlue;
            bar.SweepAngle = 0;
            bar.OffsetFromFrame = -5;
            bar.TickMajor.Height = 10;
            bar.TickMajor.Width = 5;
            bar.TickMajor.FillColor = Color.Black;
            bar.TickMinor.TickPosition = TickBase.Position.Outer;
            bar.TickMinor.Width = 2;
            bar.TickMinor.Height = 5;
            bar.TickMinor.FillColor = Color.Black;
            bar.TickLabel.LabelPostion = ScaleLabel.Position.Outer;
            bar.TickLabel.OffsetFromScale = 20;
            bar.TickLabel.LabelFont = new Font(FontFamily.GenericSansSerif,8, FontStyle.Bold);
            bar.MinorTicknumber = 5;

            knob1.ScaleCollection.Add(bar);
            bar.Rotate += new CircularScaleBar.OnRotate(bar_Rotate);

            CircularPointer pointer = new CircularPointer(knob1);
            pointer.CapPointer.CapType = PointerCapBase.PointerCapType.Type6;
            pointer.CapPointer.FillColor = Color.DarkBlue;
            pointer.CapPointer.Diameter = 120;
            pointer.CapOnTop = false;
            pointer.BasePointer.PointerShapeType = Pointerbase.PointerType.Type4;
            pointer.BasePointer.Length = 10;
            pointer.BasePointer.OffsetFromCenter = 50;
            pointer.BasePointer.FillColor = Color.DeepPink;
            pointer.BasePointer.Shadow.Offset = 3;
            pointer.CapPointer.Shadow.Offset = 3;

            bar.Pointer.Add(pointer);

            //middle frame
            NumericalFrame nmidframe = new NumericalFrame(new Rectangle(230, 10, 100, 40));
            nmidframe.FrameRenderer.Outline = NextUI.Renderer.FrameRender.FrameOutline.Type1;
            nmidframe.FrameRenderer.FrameWidth = 1;

            for (int i = 0; i < 6; i++)
            {
                DigitalPanel14Segment seg = new DigitalPanel14Segment(nframe);
                seg.BackColor = Color.DarkBlue;
                seg.FontThickness = 2;
                seg.MainColor = Color.White;
                nmidframe.Indicator.Panels.Add(seg);
            }
            nmidframe.Indicator.RoundedOff = true;
            nmidframe.Indicator.RoundedValue = 1;
            this.baseUI1.Frame.Add(nmidframe);

            CircularFrame knob2 = new CircularFrame(new Point(220, 90), 150);
            knob2.FrameRenderer.Outline = NextUI.Renderer.FrameRender.FrameOutline.None;
            knob2.BackRenderer.EndColor = this.BackColor;
            CircularScaleBar bar2 = new CircularScaleBar(knob2);
            bar2.SweepAngle = 0;
            bar2.TickMajor.TickPosition = TickBase.Position.Cross;
            bar2.FillColor = Color.DarkSlateBlue;
            bar2.OffsetFromFrame = -5;
            bar2.TickMajor.Height = 15;
            bar2.TickMajor.Width = 2;
            bar2.TickMajor.FillColor = Color.Black;
            bar2.TickMinor.TickPosition = TickBase.Position.Cross;
            bar2.TickMinor.Width = 2;
            bar2.TickMinor.Height = 5;
            bar2.TickMinor.FillColor = Color.Black;
            bar2.TickLabel.LabelPostion = ScaleLabel.Position.Outer;
            bar2.TickLabel.OffsetFromScale = 20;
            bar2.TickLabel.LabelFont = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
            bar2.MinorTicknumber = 5;

            CircularPointer pointer2 = new CircularPointer(knob2);
            pointer2.CapPointer.Visible = false;
            pointer2.BasePointer.PointerShapeType = Pointerbase.PointerType.Type3;
            pointer2.BasePointer.Length = 10;
            pointer2.BasePointer.OffsetFromCenter = 70;
            pointer2.BasePointer.FillColor = Color.DeepPink;
            pointer2.BasePointer.Shadow.Offset = 3;
            pointer2.CapPointer.Shadow.Offset = 3;

            bar2.Pointer.Add(pointer2);

            CircularRange range = new CircularRange(knob2);
            range.StartWidth = 15;
            range.EndWidth = 15;
            range.StartValue = 1;
            range.EndValue = 1;
            range.RangePosition = RangeBase.Position.Inner;
            bar2.Range.Add(range);

            bar2.Rotate += new CircularScaleBar.OnRotate(bar2_Rotate);
            knob2.ScaleCollection.Add(bar2);
            
            this.baseUI1.Frame.Add(knob2);


            //RightFrame
            CircularFrame knob3 = new CircularFrame(new Point(450, 90), 150);
            knob3.FrameRenderer.Outline = NextUI.Renderer.FrameRender.FrameOutline.None;
            knob3.BackRenderer.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.None;
            CircularScaleBar bar3 = new CircularScaleBar(knob3);
            bar3.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.None;
            bar3.Shadow.Visible = false;
            bar3.SweepAngle = 0;
            bar3.TickMajor.TickPosition = TickBase.Position.Cross;
            bar3.OffsetFromFrame = -5;
            bar3.TickMajor.Height = 15;
            bar3.TickMajor.Width = 2;
            bar3.TickMajor.FillColor = Color.Black;
            bar3.TickLabel.LabelPostion = ScaleLabel.Position.Outer;
            bar3.TickLabel.OffsetFromScale = 20;
            bar3.TickLabel.LabelFont = new Font(FontFamily.GenericSansSerif, 8, FontStyle.Bold);
            bar3.MinorTicknumber = 0;
            bar3.Rotate += new CircularScaleBar.OnRotate(bar3_Rotate);

            NumericalFrame innerframe = new NumericalFrame(new Rectangle(knob3.Rect.Width/2 - 25, knob3.Rect.Height/2 - 20, 50, 40));
            innerframe.FrameRenderer.Outline = NextUI.Renderer.FrameRender.FrameOutline.None;
            innerframe.BackRenderer.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.None;


            for (int i = 0; i < 3; i++)
            {
                DigitalPanel14Segment seg = new DigitalPanel14Segment(nframe);
                seg.BackColor = this.BackColor;
                seg.FontThickness = 2;
                seg.MainColor = Color.Black;
                seg.EnableBorder = false;
                innerframe.Indicator.Panels.Add(seg);
            }
            innerframe.Indicator.RoundedOff = true;
            innerframe.Indicator.RoundedValue = 1;

            knob3.ScaleCollection.Add(bar3);
            knob3.FrameCollection.Add(innerframe);

            CircularPointer pointer3 = new CircularPointer(knob3);
            pointer3.CapPointer.Visible = false;
            pointer3.BasePointer.PointerShapeType = Pointerbase.PointerType.Type3;
            pointer3.BasePointer.Length = 10;
            pointer3.BasePointer.OffsetFromCenter = 70;
            pointer3.BasePointer.FillColor = this.BackColor ;
            pointer3.BasePointer.Shadow.Visible = false;

            bar3.Pointer.Add(pointer3);
            this.baseUI1.Frame.Add(knob3);
        }

        void bar3_Rotate(object sender, float value)
        {
            ((NumericalFrame)((CircularFrame)(this.baseUI1.Frame[4])).FrameCollection[0]).Indicator.DisplayValue = Convert.ToString(value);
        }

        void bar2_Rotate(object sender, float value)
        {
            ((NumericalFrame)(this.baseUI1.Frame[2])).Indicator.DisplayValue = Convert.ToString(value);
            ((CircularFrame)(this.baseUI1.Frame[3])).ScaleCollection[0].Range[0].EndValue = value;
        }

        void bar_Rotate(object sender, float value)
        {
            ((NumericalFrame)(this.baseUI1.Frame[0])).Indicator.DisplayValue = Convert.ToString(value);
           // this.baseUI1.Invalidate();
        }
    }
}