// *****************************************************************************
// 
//  (c) NextWave Software  2007
//  All rights reserved. The software and associated documentation 
//  supplied hereunder are the proprietary information of NextWave Software 
//	Limited, Kuala Lumpur , Malaysia and are supplied subject to 
//	licence terms.
// 
//  Version 1.0 	www.nextwavesoft.com
// *****************************************************************************
using System;
using System.Drawing.Drawing2D;
using System.Drawing;
using NextUI.Common;


namespace NextUI.Component
{
    /// <summary>
    /// a class that implement the 7 segment digital panel
    /// </summary>
    public class DigitalPanel7Segment : NumericalBase
    {
        /// <summary>
        /// enumeration that set the type of 7 segment panel
        /// </summary>
        public enum Direction { 
            /// <summary>
            /// the panel is displayed straight up
            /// </summary>
            Normal,
            /// <summary>
            /// the panel is displayed with a slight slant
            /// </summary>
            Slide };
        private float _penthickness = 5;
        private int _opaque = 50;
        private int _glareWidth = 5;
        private bool _enableGlare = false;
        private Direction _direction = Direction.Slide;

        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="toplevel">the frame that owns the panel</param>
        public DigitalPanel7Segment(Frame.Frame toplevel)
            : base(toplevel)
        {
            
        }
        /// <summary>
        /// Get or set the direction of the panel
        /// </summary>
        public Direction Position
        {
            get { return _direction; }
            set
            {
                if (_direction != value)
                {
                    _direction = value;
                    if ( ! this.NoAutoRefresh)
                    this.TopLevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the opacity of the back ground
        /// </summary>
        public int BackOpacity
        {
            get { return _opaque; }
            set
            {
                if (_opaque != value)
                {
                    _opaque = value;
                    if ( ! this.NoAutoRefresh)
                    this.TopLevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the thickness of the font
        /// </summary>
        public float FontThickness
        {
            get { return _penthickness; }
            set
            {
                if (_penthickness != value)
                {
                    _penthickness = value;
                    if ( ! this.NoAutoRefresh)
                    this.TopLevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set to enable the glare effect
        /// </summary>
        public bool EnableGlare
        {
            get { return _enableGlare; }
            set
            {
                if (_enableGlare != value)
                {
                    _enableGlare = value;
                    if ( ! this.NoAutoRefresh)
                    this.TopLevel.Invalidate();
                }
            }
        }

        internal override void Render(RectangleWrap bound, Graphics e)
        {
            if (this.Visible)
            {
                Shape.SRectangle sbound = new NextUI.Shape.SRectangle(bound);
                this.Gradient.CenterColor = this.BackColor;
                this.Gradient.EndColor = this.EndColor;
                if (this.EnableGradient)
                {
                    this.Gradient.FillGradientType = this.GradientType;
                    this.Gradient.RenderFill(sbound, e);
                }
                else
                {
                    this.Gradient.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.Solid;
                    this.Gradient.RenderFill(sbound, e);
                }
                if (this.EnableBorder)
                {
                    SolidBrush brush = new SolidBrush(this.BorderColor);
                    e.DrawRectangle(new Pen(brush, this.BorderWidth), bound.Rect);
                }

                Color dimBack = Color.FromArgb(_opaque, this.MainColor);
                for (int i = 1; i <= 7; i++)
                {
                    RenderDigitSegment(bound, i, dimBack, false,false, e);
                    
                }
                RenderDot(bound, dimBack,false, e);
                if (this.DisplayOn)
                {
                    RenderDigit(this.DisplayValue, bound, e);
                    if (this.EnableDot)
                    {
                        RenderDot(bound, this.MainColor,this._enableGlare, e);
                    }
                }
            }
        }

        private void RenderDigit(char str, RectangleWrap bound, Graphics g)
        {
            char temp = Char.ToLower(str);
            int[] segment = new int[0];
            switch (temp)
            {
                case ' ':
                    segment = new int[] { };
                    break;
                case 'a':
                    segment = new int[] { 1, 2, 3, 4, 5, 7 };
                    break;
                case 'b':
                    segment = new int[] { 2,4,6,5,7 };
                    break;
                case 'c':
                    segment = new int[] { 1, 2, 4, 6 };
                    break;
                case 'd':
                    segment = new int[] { 3,5,6,4,7 };
                    break;
                case 'e':
                    segment = new int[] { 1,2,4,6,7 };
                    break;
                case 'f':
                    segment = new int[] { 1, 2, 4, 7 };
                    break;
                case 'g':
                    segment = new int[] { 1, 2, 4, 6, 5 };
                    break;
                case 'h':
                    segment = new int[] { 2,4,3,5,7 };
                    break;
                case 'i':
                    segment = new int[] { 3,5 };
                    break;
                case 'j':
                    segment = new int[] { 3, 5, 6, 4 };
                    break;
                case 'k':
                    segment = new int[] { 2, 4, 7,6};
                    break;
                case 'l':
                    segment = new int[] { 2, 4,6 };
                    break;
                case 'm':
                    segment = new int[] { 1,2,4,3,5 };
                    break;
                case 'n':
                    segment = new int[] { 4,7,5 };
                    break;
                case 'o':
                    segment = new int[] { 1, 2, 4, 6, 3, 5 };
                    break;
                case 'p':
                    segment = new int[] { 1, 2,4,7,3};
                    break;
                case 'q':
                    segment = new int[] { 1, 2, 7,3,5 };
                    break;
                case 'r':
                    segment = new int[] { 7,4 };
                    break;
                case 's':
                    segment = new int[] { 1, 2, 7, 5, 6 };
                    break;
                case 't':
                    segment = new int[] { 1, 3,5};
                    break;
                case 'u':
                    segment = new int[] { 4, 6, 5,2,3 };
                    break;
                case 'v':
                    segment = new int[] { 4,6,5};
                    break;
                case 'w':
                    segment = new int[] { 4,6,5 };
                    break;
                case 'x':
                    segment = new int[] { 4,6,5 };
                    break;
                case 'y':
                    segment = new int[] { 2,7,3,5,6 };
                    break;
                case 'z':
                    segment = new int[] { 1, 3,7,4,6 };
                    break;
                case '1':
                    segment = new int[] { 3, 5 };
                    break;
                case '2':
                    segment = new int[] { 1, 3,7,4,6 };
                    break;
                case '3':
                    segment = new int[] { 1, 3, 7,5,6 };
                    break;
                case '4':
                    segment = new int[] { 2, 7,3,5 };
                    break;
                case '5':
                    segment = new int[] { 1, 2, 7,5,6};
                    break;
                case '6':
                    segment = new int[] { 1, 2, 7,4,5,6 };
                    break;
                case '7':
                    segment = new int[] { 1, 3, 5 };
                    break;
                case '8':
                    segment = new int[] { 1, 2, 3,4,5,6,7 };
                    break;
                case '9':
                    segment = new int[] { 1, 2,3,7,5,6 };
                    break;
                case '0':
                    segment = new int[] { 1, 2, 4, 6, 3, 5 };
                    break;
                default:
                    segment = new int[] { 7 };
                    break;
            }
            foreach (int index in segment)
            {
                RenderDigitSegment(bound, index, this.MainColor, _enableGlare,true, g);
            }
        }

        private void RenderDot(RectangleWrap bound, Color col, bool glare, Graphics e)
        {
            float unitWidth = bound.Width / 10f;
            float unitHeight = bound.Height / 14f;
            RectangleF rect = new RectangleF(bound.Left + 8.5f * unitWidth,
                                            bound.Top + 12f * unitHeight,
                                            1.5f * unitWidth, 1.5f * unitHeight);
            if (glare)
            {
                int bitmapWidth = bound.Width / 5;
                int bitmapHeight = bound.Height / 5;
                if (bitmapWidth <= 0)
                    bitmapWidth = Global.SIZE;
                if (bitmapHeight <= 0)
                    bitmapHeight = Global.SIZE;
                Bitmap gmap = new Bitmap(bitmapWidth, bitmapHeight);
                Graphics gmapptr = Graphics.FromImage(gmap);
                GraphicsState state = e.Save();
                e.InterpolationMode = InterpolationMode.HighQualityBilinear;
                Matrix m = new Matrix(1.0f / 5, 0, 0, 1.0f / 5, -(1.0f / 5), -(1.0f / 5));
                gmapptr.Transform = m;
                gmapptr.SmoothingMode = SmoothingMode.AntiAlias;
                gmapptr.FillRectangle(new SolidBrush(col), 8.5f * unitWidth - _glareWidth / 2, 12f * unitHeight - _glareWidth / 2, 1.5f * unitWidth + _glareWidth / 2, 1.5f * unitHeight + _glareWidth / 2);
                gmapptr.Dispose();
                e.DrawImage(gmap, bound.Rect, new RectangleF(0, 0, gmap.Width, gmap.Height), GraphicsUnit.Pixel);
                e.Restore(state);
            }

            e.FillRectangle(new SolidBrush(col), rect);
        }

        private void RenderDigitSegment(RectangleWrap bound, int index, Color col, bool glare, bool shadow, Graphics g)
        {
            switch (_direction)
            {
                case Direction.Normal:
                    RenderNormalDigitSegment(bound, index, col, glare, shadow, g);
                    break;
                case Direction.Slide:
                    RenderSlideDigitSegment(bound, index, col, glare, shadow, g);
                    break;
            }
        }

        private void RenderSlideDigitSegment(RectangleWrap bound, int index, Color col, bool glare, bool shadow, Graphics g)
        {
            float unitWidth = bound.Width / 10f;
            float unitHeight = bound.Height / 14f;
            Pen p = new Pen(col, _penthickness);
            p.EndCap = LineCap.Triangle;
            p.StartCap = LineCap.Triangle;
            PointF s = new PointF(0, 0);
            PointF e = new PointF(0, 0);
            float _thickness = _penthickness - 1;
            int bitmapWidth = bound.Width / 5;
            int bitmapHeight = bound.Height / 5;
            if (bitmapWidth <= 0)
                bitmapWidth = Global.SIZE;
            if (bitmapHeight <= 0)
                bitmapHeight = Global.SIZE;

            Bitmap gmap = null;
            Graphics gmapptr = null;
            if (glare)
            {
                gmap = new Bitmap(bitmapWidth, bitmapHeight);
                gmapptr = Graphics.FromImage(gmap);
            }
            
            switch (index)
            {
                case 1:
                    s.X = bound.Left + 3*unitWidth + _thickness;
                    s.Y = bound.Top + unitHeight;
                    e.X = bound.Left + 9 * unitWidth - _thickness;
                    e.Y = bound.Top + unitHeight;
                    break;
                case 2:
                    s.X = bound.Left + 3*unitWidth;
                    s.Y = bound.Top + unitHeight + _thickness;
                    e.X = bound.Left + 2*unitWidth;
                    e.Y = bound.Top + 7 * unitHeight - _thickness;
                    break;
                case 3:
                    s.X = bound.Left + 9 * unitWidth;
                    s.Y = bound.Top + unitHeight + _thickness;
                    e.X = bound.Left + 8 * unitWidth;
                    e.Y = bound.Top + 7 * unitHeight - _thickness;
                    break;
                case 4:
                    s.X = bound.Left + 2*unitWidth;
                    s.Y = bound.Top + 7 * unitHeight + _thickness;
                    e.X = bound.Left + unitWidth;
                    e.Y = bound.Top + 13 * unitHeight - _thickness;
                    break;
                case 5:
                    s.X = bound.Left + 8 * unitWidth;
                    s.Y = bound.Top + 7 * unitHeight + _thickness;
                    e.X = bound.Left + 7 * unitWidth;
                    e.Y = bound.Top + 13 * unitHeight - _thickness;
                    break;
                case 6:
                    s.X = bound.Left + unitWidth + _thickness;
                    s.Y = bound.Top + 13 * unitHeight;
                    e.X = bound.Left + 7 * unitWidth - _thickness;
                    e.Y = bound.Top + 13 * unitHeight;
                    break;

                case 7:
                    s.X = bound.Left + 2* unitWidth + _thickness;
                    s.Y = bound.Top + 7 * unitHeight;
                    e.X = bound.Left + 8 * unitWidth - _thickness;
                    e.Y = bound.Top + 7 * unitHeight;
                    break;
                
            }
            if (shadow)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddLine(s, e);
                this.Shadow.RenderDraw(path, g, _penthickness);
            }
            if (glare)
            {
                GraphicsState state = g.Save();
                g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                Pen pshaw = new Pen(new SolidBrush(this.MainColor), _penthickness + _glareWidth);
                Matrix m = new Matrix(1.0f / 5, 0, 0, 1.0f / 5, -(1.0f / 5), -(1.0f / 5));
                gmapptr.Transform = m;
                gmapptr.SmoothingMode = SmoothingMode.AntiAlias;
                PointF z = e;
                z.X -= bound.Left;
                z.Y -= bound.Top;
                PointF z1 = s;
                z1.X -= bound.Left;
                z1.Y -= bound.Top;
                gmapptr.DrawLine(pshaw, z, z1);
                g.DrawImage(gmap, bound.Rect, new Rectangle(0, 0, gmap.Width, gmap.Height), GraphicsUnit.Pixel);
                g.Restore(state);
            }
            g.DrawLine(p, s, e);
        }


        private void RenderNormalDigitSegment(RectangleWrap bound, int index, Color col, bool glare, bool shadow, Graphics g)
        {
            float unitWidth = bound.Width / 10f;
            float unitHeight = bound.Height / 14f;
            Pen p = new Pen(col, _penthickness);
            p.EndCap = LineCap.Triangle;
            p.StartCap = LineCap.Triangle;
            PointF s = new PointF(0, 0);
            PointF e = new PointF(0, 0);
            float _thickness = _penthickness - 1;
            int bitmapWidth = bound.Width / 5;
            int bitmapHeight = bound.Height / 5;
            if (bitmapWidth <= 0)
                bitmapWidth = Global.SIZE;
            if (bitmapHeight <= 0)
                bitmapHeight = Global.SIZE;

            Bitmap gmap = null;
            Graphics gmapptr = null;
            if (glare)
            {
                gmap = new Bitmap(bitmapWidth, bitmapHeight);
                gmapptr = Graphics.FromImage(gmap);
            }
            switch (index)
            {
                case 1:
                    s.X = bound.Left + unitWidth  + _thickness;
                    s.Y = bound.Top + unitHeight;
                    e.X = bound.Left + 8 * unitWidth - _thickness;
                    e.Y = bound.Top + unitHeight;
                    break;
                case 2:
                    s.X = bound.Left + unitWidth;
                    s.Y = bound.Top + unitHeight + _thickness;
                    e.X = bound.Left + unitWidth;
                    e.Y = bound.Top + 7 * unitHeight - _thickness;
                    break;
                case 3:
                    s.X = bound.Left + 8 * unitWidth ;
                    s.Y = bound.Top + unitHeight + _thickness;
                    e.X = bound.Left + 8 * unitWidth;
                    e.Y = bound.Top + 7* unitHeight - _thickness;
                    break;
                case 4:
                    s.X = bound.Left + unitWidth;
                    s.Y = bound.Top + 7 * unitHeight + _thickness;
                    e.X = bound.Left + unitWidth;
                    e.Y = bound.Top + 13 * unitHeight - _thickness;
                    break;
                case 5:
                    s.X = bound.Left + 8 * unitWidth;
                    s.Y = bound.Top + 7 * unitHeight + _thickness;
                    e.X = bound.Left + 8 * unitWidth;
                    e.Y = bound.Top + 13 * unitHeight - _thickness;
                    break;
                case 6:
                    s.X = bound.Left + unitWidth + _thickness ;
                    s.Y = bound.Top + 13 * unitHeight ;
                    e.X = bound.Left + 8 * unitWidth - _thickness;
                    e.Y = bound.Top + 13 * unitHeight ;
                    break;
      
                case 7:
                    s.X = bound.Left + unitWidth + _thickness;
                    s.Y = bound.Top + 7 * unitHeight;
                    e.X = bound.Left + 8 * unitWidth - _thickness;
                    e.Y = bound.Top + 7 * unitHeight;
                    break;
            }
            if (shadow)
            {
                GraphicsPath path = new GraphicsPath();
                path.AddLine(s, e);
                this.Shadow.RenderDraw(path, g, _penthickness);
            }
            if (glare)
            {
                GraphicsState state = g.Save();
                g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                Pen pshaw = new Pen(new SolidBrush(this.MainColor), _penthickness + _glareWidth);
                Matrix m = new Matrix(1.0f / 5, 0, 0, 1.0f / 5, -(1.0f / 5), -(1.0f / 5));
                gmapptr.Transform = m;
                gmapptr.SmoothingMode = SmoothingMode.AntiAlias;
                PointF z = e;
                z.X -= bound.Left;
                z.Y -= bound.Top;
                PointF z1 = s;
                z1.X -= bound.Left;
                z1.Y -= bound.Top;
                gmapptr.DrawLine(pshaw, z, z1);
                g.DrawImage(gmap, bound.Rect, new Rectangle(0, 0, gmap.Width, gmap.Height), GraphicsUnit.Pixel);
                g.Restore(state);
            }
            g.DrawLine(p, s, e);
        }
    }
}
