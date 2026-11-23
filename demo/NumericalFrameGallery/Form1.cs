using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NextUI.Frame;
using NextUI.Component;

namespace NumericalFrameGallery
{
    public partial class Form1 : Form
    {
        private Timer _timer = new Timer();
        private int val = 0;
        public Form1()
        {
            _timer.Interval = 150;
            InitializeComponent();
            // Numerical frame 1
            NumericalFrame f1 = new NumericalFrame(new Rectangle(10, 10, 500, 100));
            f1.BackRenderer.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.VerticalCenter;
            f1.BackRenderer.EndColor = Color.DarkBlue;
            f1.BackRenderer.CenterColor = Color.SlateBlue;
            this.baseUI1.Frame.Add(f1);
            for (int i = 0; i < 8; i++)
            {
                DigitalPanel14Segment seg = new DigitalPanel14Segment(f1);
                f1.Indicator.Panels.Add(seg);
                seg.EnableGradient = true;
                seg.GradientType = NextUI.Renderer.RendererGradient.GradientType.VerticalCenter;
                seg.EndColor = Color.DarkBlue;
                seg.BackColor = Color.SlateBlue;
                seg.MainColor = Color.White;
                seg.Position = DigitalPanel14Segment.Direction.Normal;
                seg.FontThickness = 5;
                seg.EnableBorder = false;
                seg.BackOpacity = 0;
            }
            

            //Numerical frame  2
            NumericalFrame f2 = new NumericalFrame(new Rectangle(10, 10, 500, 100));
            this.baseUI2.Frame.Add(f2);
            for (int i = 0; i < 8; i++)
            {
                DigitalPanel14Segment seg = new DigitalPanel14Segment(f2);
                f2.Indicator.Panels.Add(seg);
                seg.BackColor = Color.Black;
                seg.MainColor = Color.LightGreen;
                seg.EnableGlare = true;
            }

            //Numerical frame 3
            NumericalFrame f3 = new NumericalFrame(new Rectangle(10, 10, 500, 100));
            this.baseUI3.Frame.Add(f3);
            f3.BackRenderer.CenterColor = Color.Black;
            f3.BackRenderer.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.Solid;
            for (int i = 0; i < 8; i++)
            {
                DigitalPanel7Segment seg = new DigitalPanel7Segment(f3);
                f3.Indicator.Panels.Add(seg);
                seg.BackColor = Color.Black;
                seg.MainColor = Color.Red;
                seg.EnableBorder = false;
            }

            f3.Indicator.Panels[5].MainColor = Color.Yellow;
            f3.Indicator.Panels[6].MainColor = Color.Yellow;
            f3.Indicator.Panels[7].MainColor = Color.Yellow;

            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Start();
        }

        void _timer_Tick(object sender, EventArgs e)
        {
            val += 45556;
            if (val > 1000000)
            {
                val = 0;
            }
            ((NumericalFrame)(this.baseUI1.Frame[0])).Indicator.DisplayValue = Convert.ToString(val);
            ((NumericalFrame)(this.baseUI2.Frame[0])).Indicator.DisplayValue = Convert.ToString(val);
            ((NumericalFrame)(this.baseUI3.Frame[0])).Indicator.DisplayValue = Convert.ToString(val);
        }
    }
}