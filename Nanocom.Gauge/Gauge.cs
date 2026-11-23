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
    public partial class Gauge : NextUI.BaseUI.BaseUI   
    {
        private int _frameWidth=6;
        private int _frameSize=200;
        private Frame _baseFrame=null;

        public Gauge()
        {
            InitializeComponent();
            this.BackColor = System.Drawing.Color.Black;
        }

        public int FrameWidth
        {
            get
            {
                return _frameWidth;
            }
            set
            {
                _frameWidth = value;
            }
        }

        public int FrameSize
        {
            get
            {
                return _frameSize;
            }
            set
            {
                _frameSize = value;
            }
        }

        public Frame BaseFrame
        {
            get
            {
                return _baseFrame;
            }
            set
            {
                _baseFrame = value;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public Color LightColor = Color.FromArgb(230, 255, 230);
        public Color RangeRedColor = Color.FromArgb(255, 64, 64);
        public Color RangeGreenColor = Color.FromArgb(64, 255, 64);
        public Color RangeBlueColor = Color.FromArgb(64, 64, 255);

        public CircularFrame CreateCircularFrame()
        {
            //CircularFrame frame = new CircularFrame(new Point(0, 0), this.FrameSize);
            int ofs = this.FrameWidth==0 ? 0 : this.FrameWidth / 2;
            CircularFrame frame = new CircularFrame(new Point(ofs, ofs), this.FrameSize);
            frame.BackRenderer.CenterColor = Color.Black;
            frame.BackRenderer.EndColor = Color.Black;
            frame.FrameRenderer.Outline = NextUI.Renderer.FrameRender.FrameOutline.Type3;
            if( _baseFrame == null ) _baseFrame = frame;
            return frame;
        }
        public HorizontalFrame CreateHorizontalFrame()
        {
            int ofs = this.FrameWidth / 2;
            HorizontalFrame frame = new HorizontalFrame(new Rectangle(ofs, ofs, this.FrameSize, this.FrameSize));
            frame.BackRenderer.CenterColor = Color.Black;
            frame.BackRenderer.EndColor = Color.Black;
            frame.FrameRenderer.Outline = NextUI.Renderer.FrameRender.FrameOutline.Type3;
            if (_baseFrame == null) _baseFrame = frame;
            return frame;
        }

        public CircularScaleBar CreateCircularScaleBar(Frame frame)
        {
            CircularScaleBar bar = new CircularScaleBar(frame);
            bar.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.Solid;
            bar.OffsetFromFrame = this.FrameWidth;
            bar.ScaleBarSize = 3;
            bar.FillColor = LightColor;
            bar.TickMajor.EnableGradient = false;
            bar.TickMajor.EnableBorder = false;
            bar.TickMajor.FillColor = LightColor;
            bar.TickMajor.Height = 10;
            bar.TickMajor.Width = 5;
            bar.TickMajor.Type = TickBase.TickType.RoundedRect;
            bar.TickMinor.Height = 6;
            bar.TickMinor.Width = 3;
            bar.TickMinor.EnableGradient = false;
            bar.TickMinor.EnableBorder = false;
            bar.TickMinor.FillColor = LightColor;
            bar.TickMajor.TickPosition = TickBase.Position.Inner;
            bar.TickMinor.TickPosition = TickBase.Position.Inner;
            bar.TickLabel.TextDirection = CircularLabel.Direction.Horizontal;
            bar.TickLabel.OffsetFromScale = 25;
            bar.TickLabel.LabelFont = CreateTickLabelFont();
            bar.TickLabel.FontColor = LightColor;

            return bar;
        }
        public HorizontalScaleBar CreateHorizontalScaleBar(Frame frame)
        {
            HorizontalScaleBar bar = new HorizontalScaleBar(frame);
            bar.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.Solid;
            bar.OffsetFromFrame = this.FrameWidth;
            bar.ScaleBarSize = 3;
            bar.Visible = false;
            bar.FillColor = LightColor;
            bar.TickMajor.EnableGradient = false;
            bar.TickMajor.EnableBorder = false;
            bar.TickMajor.FillColor = LightColor;
            bar.TickMajor.Height = 10;
            bar.TickMajor.Width = 5;
            bar.TickMajor.Type = TickBase.TickType.RoundedRect;
            bar.TickMinor.Height = 6;
            bar.TickMinor.Width = 3;
            bar.TickMinor.EnableGradient = false;
            bar.TickMinor.EnableBorder = false;
            bar.TickMinor.FillColor = LightColor;
            bar.TickMajor.TickPosition = TickBase.Position.Cross;
            bar.TickMinor.TickPosition = TickBase.Position.Cross;
            //bar1.TickLabel.TextDirection = CircularLabel.Direction.Horizontal;
            bar.TickLabel.OffsetFromScale = 15;
            
            bar.TickLabel.LabelFont = CreateTickLabelFont();
            bar.TickLabel.FontColor = LightColor;

            return bar;
        }

        public CircularRange CreateCircularRange(Frame frame)
        {
            CircularRange range = new CircularRange(frame);
            range.EnableGradient = false;
            range.StartWidth = 10;
            range.EndWidth = 10;
            range.RangePosition = RangeBase.Position.Inner;
            range.FillColor = RangeRedColor;
            return range;
        }

        public LinearRange CreateLinearRange(Frame frame)
        {
            LinearRange range = new LinearRange(frame);
            range.EnableGradient = false;
            range.StartWidth = 10;
            range.EndWidth = 10;
            range.RangePosition = RangeBase.Position.Cross;
            range.FillColor = RangeRedColor;
            return range;
        }

        public CircularPointer CreateCircularPointer(Frame frame)
        {
            CircularPointer pointer = new CircularPointer(frame);
            pointer.CapPointer.Visible = true;
            //pointer.CapOnTop = false;
            pointer.CapOnTop = true;
            pointer.BasePointer.Length = 100;
            pointer.BasePointer.FillColor = Color.Red;
            pointer.BasePointer.PointerShapeType = Pointerbase.PointerType.Type2;
            pointer.BasePointer.OffsetFromCenter = -20;
            return pointer;
        }

        public HorizontalPointer CreateHorizontalPointer(Frame frame)
        {
            HorizontalPointer pointer = new HorizontalPointer(frame);
            //pointer.CapPointer.Visible = true;
            //pointer.CapOnTop = false;
            pointer.BasePointer.Length = 10;
            pointer.BasePointer.FillColor = Color.Red;
            pointer.BasePointer.PointerShapeType = Pointerbase.PointerType.Type3;
            //pointer.BasePointer.OffsetFromCenter = -20;
            return pointer;
        }

        public CircularMarker CreateCircularMarker(Frame frame)
        {
            CircularMarker marker = new CircularMarker(frame);
            marker.BasePointer.FillColor = Color.Red;
            return marker;
        }

        public FrameLabel AddBaseFrameLabel(string text)
        {
            return AddBaseFrameLabel(text, CreateFrameLabelFont());
        }

        public virtual FrameLabel AddBaseFrameLabel(string text, Font labelFont)
        {
            FrameLabel label = CreateFrameLabel(_baseFrame, text, labelFont );
            MoveFrameLabel(label, 0, 65);
            _baseFrame.FrameLabelCollection.Add(label);
            return label;
        }

        public FrameLabel CreateFrameLabel(Frame frame, string text)
        {
            return CreateFrameLabel( frame,  text, CreateFrameLabelFont() );
        }

        public Size MeasureText(string text, Font labelFont)
        {
#if true
            Graphics g = Graphics.FromHwnd(this.Handle);
            Size proposedSize = new Size(int.MaxValue, int.MaxValue);
            Size textSize = TextRenderer.MeasureText(g, text, labelFont, proposedSize, TextFormatFlags.NoPadding|TextFormatFlags.HorizontalCenter);

#else
            Size textSize = TextRenderer.MeasureText(text, labelFont);
            textSize.Width = (int)(textSize.Width * (1.0-text.Length*0.03));
#endif
            return textSize;
        }
        public FrameLabel CreateFrameLabel(Frame frame, string text, Font labelFont )
        {
            Size textSize = this.MeasureText(text, labelFont);
            FrameLabel label = new FrameLabel(CenterAtFrame(textSize), frame);
            label.LabelText = text;
            label.LabelFont = labelFont;
            label.FontColor = Color.White;
            return label;
        }
        public Point CenterAtFrame(Size textSize)
        {
//            int x = (this.FrameSize - textSize.Width + 1) / 2 + this.FrameWidth;
//            int y = (this.FrameSize - textSize.Height + 1) / 2 + this.FrameWidth;
//            int x = (this.FrameWidth + this.FrameSize - textSize.Width + 1) / 2;
//            int y = (this.FrameWidth + this.FrameSize - textSize.Height + 1) / 2;
//            int x = (this.FrameWidth + this.FrameSize) / 2 - this.FrameWidth;
//            int y = (this.FrameWidth + this.FrameSize) / 2 + textSize.Height;
            int x = (this.FrameSize - textSize.Width) / 2 + this.FrameWidth;
            int y = (this.FrameSize - textSize.Height) / 2 + this.FrameWidth;
            return new Point(x, y);
        }
        public void CenterFrameLabel(FrameLabel label )
        {
            Size textSize = this.MeasureText(label.LabelText, label.LabelFont);
            label.Location = CenterAtFrame( textSize );
        }

        public void MoveFrameLabel(FrameLabel label, int x, int y)
        {
            Point l = label.Location;
            l.X += x;
            l.Y += y;
            label.Location = l;
        }

        public Font CreateFrameLabelFont()
        {
            return CreateFrameLabelFont(1.0F);
        }
        public Font CreateFrameLabelFont(float scale_)
        {
            return new Font(FontFamily.GenericSansSerif, 18*scale_, FontStyle.Regular);
        }

        public Font CreateTickLabelFont()
        {
            return CreateTickLabelFont(1.0F);
        }
        public Font CreateTickLabelFont(float scale_)
        {
           return new Font(FontFamily.GenericSansSerif, 10*scale_, FontStyle.Bold);
        }
    }
}
