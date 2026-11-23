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
using NextUI.Shape;
using NextUI.Helper;
namespace NextUI.Component
{
    /// <summary>
    /// The base class of major tick and minor tick
    /// </summary>
    public class TickBase
    {
        /// <summary>
        /// enumeration for the shape of the tick
        /// </summary>
        public enum TickType {
            /// <summary>
            /// Set the tick with a circle shape
            /// </summary>
            Circle,
            /// <summary>
            /// Set the tick with a triangle shape
            /// </summary>
            Triangle,
            /// <summary>
            /// Set the tick with a triangle shape , but pointing downward
            /// </summary>
            DownTriangle,
            /// <summary>
            /// Set the tick with a rectangle shape
            /// </summary>
            Rectangle,
            /// <summary>
            /// Set the tick with a rounded rectangle shape
            /// </summary>
            RoundedRect,
            /// <summary>
            /// Set the tick with a arrow head shape 
            /// </summary>
            CustomTriangle1,
            /// <summary>
            /// Set the tick with a arrow head shape , pointing downward
            /// </summary>
            DownCustomTriangle1, 
            /// <summary>
            /// Set the tick with a diamond shape
            /// </summary>
            Diamond 
        };
        /// <summary>
        /// Enumeration for the position of the tick , the position is relative to
        /// the scale bar 
        /// </summary>
        public enum Position {
            /// <summary>
            /// Set the position of the tick on the inner side of the scale
            /// </summary>
            Inner, 
            /// <summary>
            /// Set the position of the tick on the middle of the scale
            /// </summary>
            Outer,
            /// <summary>
            /// Set the position of the tick on the outward side of the scale
            /// </summary>
            Cross
        };
        private ScaleBase _parent = null;
        private Position _tickPosition = Position.Cross;
        private TickType _ticktype = TickType.Rectangle;
        private bool _enableBorder = true;
        private Color _borderColor = Color.Black;
        private bool _enableGradient = true;
        private Color _fillColor = Color.Red;
        private Color _endColor = Color.White;
        private int _width = 3;
        private int _height = 10;
        private float _borderWidth = 1;
        private Image _backImage = null;
        private bool _visible = true;
        private int _offsetFromScale = 1;
        private Renderer.RenderShadow _shadow = null;
        private Frame.Frame _toplevel = null;
        private Renderer.RendererGradient _gra = null;
        private bool _noAutoUpdate = false;

        internal bool NoAutoRefresh
        {
            get { return _noAutoUpdate; }
            set { _noAutoUpdate = value; }
        }

        internal Frame.Frame TopLevel
        {
            get { return _toplevel; }

        }

        /// <summary>
        /// Get the shadow renderer
        /// object to configure the shadow property of the tick
        /// </summary>
        public Renderer.RenderShadow Shadow
        {
            get { return _shadow; }
        }


        /// <summary>
        /// Get or set the distance from the scale, this has no effect if position is set to cross
        /// </summary>
        public int OffsetFromScale
        {
            get { return _offsetFromScale; }
            set
            {
                if (_offsetFromScale != value)
                {
                    _offsetFromScale = value;
                    if ( !_noAutoUpdate)
                    _toplevel.Invalidate();
                    
                    
                }
            }
        }
       

        /// <summary>
        /// Get or set the position of the tick, can be inner , cross or outer
        /// </summary>
        public Position TickPosition
        {
            get { return _tickPosition; }
            set
            {
                if (_tickPosition != value)
                {
                    _tickPosition = value;
                    if ( !_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }


        /// <summary>
        /// Get or set the width of the border
        /// </summary>
        public float BorderWidth
        {
            get { return _borderWidth; }
            set
            {
                if (_borderWidth != value)
                {
                    _borderWidth = value;
                    if (!_noAutoUpdate)
                        _toplevel.Invalidate();
                }
            }
        }
        

        /// <summary>
        /// Get or set the tick visibility
        /// </summary>
        public bool Visible
        {
            get { return _visible; }
            set
            {
                if (_visible != value)
                {
                    _visible = value;
                    if ( !_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the shape of the tick
        /// </summary>
        public TickType Type
        {
            get { return _ticktype; }
            set
            {
                if (_ticktype != value)
                {
                    _ticktype = value;
                    if ( !_noAutoUpdate)
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
                    if ( !_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the color of the border
        /// </summary>
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                if (_borderColor != value)
                {
                    _borderColor = value;
                    if ( !_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }
        /// <summary>
        /// Set to enable gradient color on the tick
        /// </summary>
        public bool EnableGradient
        {
            get { return _enableGradient; }
            set
            {
                if (_enableGradient != value)
                {
                    _enableGradient = value;
                    if ( !_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the Color of the tick
        /// </summary>
        public Color FillColor
        {
            get { return _fillColor; }
            set
            {
                if (_fillColor != value)
                {
                    _fillColor = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set the end color of the tick if enable gradient is set to true
        /// </summary>
        public Color EndColor
        {
            get { return _endColor; }
            set
            {
                if (_endColor != value)
                {
                    _endColor = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the height of the tick
        /// </summary>
        public int Height
        {
            get { return _height; }
            set
            {
                if (_height != value)
                {
                    _height = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set the width of the tick
        /// </summary>
        public int Width
        {
            get { return _width; }
            set
            {
                if (_width != value)
                {
                    _width = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set the image to be displayed
        /// </summary>

        public Image BackImage
        {
            get { return _backImage; }
            set
            {
                if (_backImage != value)
                {
                    _backImage = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }
        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="parent">the scale who owns the tick</param>
        /// <param name="toplevel">the frame who owns the scale</param>
      
        public TickBase(ScaleBase parent,Frame.Frame toplevel)
        {
            if (toplevel == null)
            {
                throw new Exception("toplevel object is null ");
            }
            _parent = parent;
            _shadow = new NextUI.Renderer.RenderShadow(toplevel);
            _gra = new NextUI.Renderer.RendererGradient(toplevel);
            _gra.NoAutoRefresh = true;
            _toplevel = toplevel;
        }

        internal void Render(Point f,   Graphics e)
        {
            RectangleWrap wrap = null;
            BaseShape shape = null;
            Point startPt = new Point(0, 0);
            switch (_tickPosition)
            {
                case Position.Cross:
                    wrap = new RectangleWrap(new Rectangle(f.X - this.Width /2, f.Y + _parent.ScaleBarSize / 2 - this.Height / 2,
                                             this.Width, this.Height));
                    break;
                case Position.Inner:
                    wrap = new RectangleWrap(new Rectangle(f.X - this.Width / 2, f.Y + _parent.ScaleBarSize + _offsetFromScale,
                                             this.Width, this.Height));
                    break;
                case Position.Outer:
                    wrap = new RectangleWrap(new Rectangle(f.X - this.Width / 2, f.Y - this.Height - _offsetFromScale,
                                             this.Width, this.Height));
                    break;
            }
            switch (_ticktype)
            {
                case TickType.Circle:
                    shape = new Circle(wrap);
                    break;
                case TickType.Rectangle:
                    shape = new SRectangle(wrap);
                    break;
                case TickType.RoundedRect:
                    shape = new RoundedRectangle(wrap);
                    break;
                case TickType.Triangle:
                    shape = new Triangle(wrap);
                    break;
                case TickType.DownTriangle:
                    shape = new Triangle(wrap);
                    ((Triangle)shape).Direction = Triangle.PointDirection.down;
                    break;
                case TickType.CustomTriangle1:
                    shape = new CustomTriangle(wrap);
                    break;
                case TickType.DownCustomTriangle1:
                    shape = new CustomTriangle(wrap);
                    ((CustomTriangle)shape).Direction = CustomTriangle.PointDirection.down;
                    break;
                case TickType.Diamond:
                    shape = new Diamond(wrap);
                    break;
            }

            if (_visible)
            {
                _shadow.Render(shape, e);
                if (_backImage == null)
                {
                    if (_enableGradient)
                    {
                        
                        _gra.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.LeftRight;
                        _gra.CenterColor = this._fillColor;
                        _gra.EndColor = this._endColor;
                        _gra.RenderFill(shape, e);
                    }
                    else
                    {
                        e.FillPath(new SolidBrush(this._fillColor), shape.RenderPath());
                    }
                    if (_enableBorder)
                    {
                        e.DrawPath(new Pen(this._borderColor, this._borderWidth), shape.RenderPath());
                    }
                }
                else
                {

                    e.DrawImage(_backImage, wrap.Rect, new Rectangle(0, 0, _backImage.Width, _backImage.Height), GraphicsUnit.Pixel);
                }

            }

        }

    }
}
