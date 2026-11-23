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
using System.Drawing;
using System.Drawing.Drawing2D;
using NextUI.Common;

namespace NextUI.Component
{
    /// <summary>
    /// a class that render the pointer
    /// </summary>
    public class Pointerbase 
    {
        /// <summary>
        /// Enumeration for the different shape of the pointer
        /// </summary>
        public enum PointerType { 
            /// <summary>
            /// Arrow head pointer
            /// </summary>
            Type1,
            /// <summary>
            /// triangle pointer
            /// </summary>
            Type2,
            /// <summary>
            /// diamond
            /// </summary>
            Type3 ,
            /// <summary>
            /// rounded rectangle pointer
            /// </summary>
            Type4};
        private int _width = 10;
        private int _length = 40;
        private PointerType _type = PointerType.Type1;
        private Color _fillColor = Color.DarkGray;
        private Color _borderColor = Color.Black;
        private float _borderWidth = 1;
        private bool _enableBorder = true;
        private Image _image = null;
        private bool _visible = true;
        private bool _enableGradient = true;
        private Color _endColor = Color.White;
        private RectangleWrap _bound = new RectangleWrap(new Rectangle(0,0,1,1));
        private int _offsetFromCenter = 0;
        private Renderer.RenderShadow _shadow = null;
        private Frame.Frame _toplevel = null;
        private Renderer.RendererGradient _gra = null;

        internal Frame.Frame TopLevel
        {
            get { return _toplevel; }

        }
        /// <summary>
        /// Get or set the offset of the pointer from center, it can be positive or negative
        /// </summary>
        public int OffsetFromCenter
        {
            get { return _offsetFromCenter; }
            set
            {
                if (_offsetFromCenter != value)
                {
                    _offsetFromCenter = value;
                    _toplevel.Invalidate();
                }
            }
        }

        internal bool HitTest(Point hit)
        {
            if (_bound.Rect.Contains(hit))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Get or set the bound of the pointer
        /// </summary>
        protected RectangleWrap Bound
        {
            get { return _bound; }
            set
            {
                if (_bound != value)
                {
                    _bound = value;
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or Set to enable gradient color on the pointer
        /// </summary>
        public bool EnableGradient
        {
            get { return _enableGradient; }
            set
            {
                if (_enableGradient != value)
                {
                    _enableGradient = value;
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the end color of the pointer if enable gradient is set to true
        /// </summary>
        public Color EndColor
        {
            get { return _endColor; }
            set
            {
                if (_endColor != value)
                {
                    _endColor = value;
                    _toplevel.Invalidate();
                }
            }
        }


        /// <summary>
        /// Get the shadow object to configure the shadow property of the pointer
        /// </summary>
        public  NextUI.Renderer.RenderShadow Shadow
        {
            get { return _shadow; }
        }
        

        /// <summary>
        /// Get or set the width of the border
        /// </summary>
        public float BorderWidth
        {
            get { return _borderWidth; }
            set
            {
                if (_borderWidth != value && value >= 0)
                {
                    _borderWidth = value;
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the visibility of the pointer
        /// </summary>
        public bool Visible
        {
            get { return _visible; }
            set
            {
                if (_visible != value)
                {
                    _visible = value;
                    _toplevel.Invalidate();
                }
            }
        }
            

        /// <summary>
        /// Get or set the PointerImage, if PointerImage is null , remove the image
        /// </summary>
        public Image PointerImage
        {
            get { return _image; }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    _toplevel.Invalidate();
                }
            }
        }

             /// <summary>
        /// Get or set the width of the pointer.
        /// </summary>
        public int Width
        {
            get { return _width; }
            set
            {
                if (_width != value && value > 0)
                {
                    _width = value;
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the length of the Pointer.
        /// </summary>
        public int Length
        {
            get { return _length; }
            set
            {
                if (_length != value && value > 0)
                {
                    _length = value;
                    _toplevel.Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set the type of Pointer
        /// </summary>
        public PointerType PointerShapeType
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the color to be filled 
        /// </summary>
        public Color FillColor
        {
            get { return _fillColor; }
            set
            {
                if (_fillColor != value)
                {
                    _fillColor = value;
                    _toplevel.Invalidate();
                }
            }
        }
        

        /// <summary>
        /// Get or set the color of the border if enabled
        /// </summary>
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                if (_borderColor != value)
                {
                    _borderColor = value;
                    _toplevel.Invalidate();
                }
            }
        }
        
        /// <summary>
        /// Get or set to enable border
        /// </summary>
        public bool EnableBorder
        {
            get { return _enableBorder; }
            set
            {
                if (_enableBorder != value)
                {
                    _enableBorder = value;
                    _toplevel.Invalidate();
                }
            }
        }

        internal Pointerbase(Frame.Frame toplevel)
        {
            if (toplevel == null)
            {
                throw new Exception("toplevel is null");
            }
            _toplevel = toplevel;
            _shadow = new NextUI.Renderer.RenderShadow(_toplevel);
            _gra = new NextUI.Renderer.RendererGradient(_toplevel);
            _gra.NoAutoRefresh = true;
        }

        internal void Render(Point center, Graphics e)
        {
            if (_visible)
            {
                Shape.BaseShape pointer = null;
                this._bound = new RectangleWrap(new Rectangle(center.X - _width / 2, center.Y - _length - _offsetFromCenter, _width, _length));
                _gra.CenterColor = this._fillColor;
                _gra.EndColor = this._endColor;
                if (this._enableGradient)
                {
                    _gra.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.LeftRight;
                }
                else
                {
                    _gra.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.Solid;
                }


                switch (_type)
                {
                    case PointerType.Type1:
                        pointer = new NextUI.Shape.CustomTriangle(this.Bound);
                        break;
                    case PointerType.Type2:
                        pointer = new NextUI.Shape.Triangle(this.Bound);
                        break;
                    case PointerType.Type3:
                        pointer = new NextUI.Shape.Diamond(this.Bound);
                        break;
                    case PointerType.Type4:
                        pointer = new NextUI.Shape.RoundedRectangle(this.Bound);
                        break;
                    default:
                        break;
                }
                if (this.PointerImage != null)
                {
                    //we use rectangle as a shadow
                    NextUI.Shape.SRectangle pictShaw = new NextUI.Shape.SRectangle(this.Bound);
                    _shadow.Render(pictShaw, e);
                    e.DrawImage(this.PointerImage, Bound.Rect, new Rectangle(0, 0, this.PointerImage.Width, this.PointerImage.Height), GraphicsUnit.Pixel);
                }
                else
                {
                    _shadow.Render(pointer, e);
                    _gra.RenderFill(pointer, e);
                    if (_enableBorder)
                    {
                        e.DrawPath(new Pen(this._borderColor, this._borderWidth), pointer.RenderPath());
                    }
                }
                
            }
        }

    }
}
