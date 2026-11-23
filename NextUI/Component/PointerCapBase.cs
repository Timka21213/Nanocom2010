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
    /// A class that render the pointer cap
    /// </summary>
    public  class PointerCapBase
    {
        /// <summary>
        /// enumeration for the type of the cap
        /// </summary>
        public enum PointerCapType { 
            /// <summary>
            /// Plain circular shape cap
            /// </summary>
            Type1, 
            /// <summary>
            /// Plain gear shape circular shape cap
            /// </summary>
            Type2,
            /// <summary>
            /// Circular shape with gradient
            /// </summary>
            Type3,
            /// <summary>
            /// Gear circular shape with gradient
            /// </summary>
            Type4,
            /// <summary>
            /// circular ring cap
            /// </summary>
            Type5,
            /// <summary>
            /// Gear circular shape with gradient with more face
            /// </summary>
            Type6 
        };
        private int _diameter = 20;
        private PointerCapType _type = PointerCapType.Type1;
        private Color _fillColor = Color.DarkGray;
        private Color _borderColor = Color.Black;

        private float _borderWidth = 1;
        private bool _enableBorder = true;
        private Image _image = null;
        private bool _visible = true;
        private NextUI.Renderer.RenderShadow _shadow = null;
        private RectangleWrap _bound = new RectangleWrap(new Rectangle(0, 0, 1, 1));
        private Frame.Frame _toplevel = null;
        private Renderer.RendererGradient _gra = null;

        internal Frame.Frame TopLvel
        {
            get { return _toplevel; }

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
        /// Get or set the bound of the cap
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
        /// Get the shadow object to configure shadow for the cap
        /// </summary>
        public NextUI.Renderer.RenderShadow Shadow
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
                if (_borderWidth != value)
                {
                    _borderWidth = value;
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the visibility of the caps
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
        /// Get or set the CapImage, set to null to remove the image. 
        /// </summary>
        public Image CapImage
        {
            get { return _image; }
            set
            {
                if (_image != value )
                {
                    _image = value;
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the diameter of the caps.
        /// </summary>
        public int Diameter
        {
            get { return _diameter; }
            set
            {
                if (_diameter != value && value > 0)
                {
                    _diameter = value;
                    _toplevel.Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set the type of cap
        /// </summary>
        public PointerCapType CapType
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

        internal PointerCapBase(Frame.Frame toplevel)
        {
            if (toplevel == null)
            {
                throw new Exception("toplevel is null");
            }
            _toplevel = toplevel;
            _shadow = new NextUI.Renderer.RenderShadow(toplevel);
            _gra = new NextUI.Renderer.RendererGradient(toplevel);
            _gra.NoAutoRefresh = true;
        }

        internal void Render(Point center, Graphics e)
        {
            if (_visible)
            {
                this._bound = new RectangleWrap(
                    new Rectangle(
                    center.X - _diameter / 2,
                    center.Y - _diameter / 2,
                    _diameter,
                    _diameter));
                Shape.BaseShape cap = null;
             
                _gra.CenterColor = this._fillColor;
                _gra.EndColor = Color.White;
                _gra.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.Center;


                switch (_type)
                {
                    case PointerCapType.Type1:
                        cap = new NextUI.Shape.Circle(this.Bound);
                        _shadow.Render(cap, e);
                        _gra.RenderFill(cap, e);
                        break;
                    case PointerCapType.Type2:
                        cap = new NextUI.Shape.CustomCircle1(this.Bound);
                        _shadow.Render(cap, e);
                        _gra.RenderFill(cap, e);
                        break;
                    case PointerCapType.Type3:
                        {
                            cap = new NextUI.Shape.Circle(this.Bound);
                            _shadow.Render(cap, e);
                            int shrinkSize = (int)((_diameter / 2) * 0.4);
                            RectangleWrap smallWrap = this.Bound.Shrink(shrinkSize);
                            _gra.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.DiagonalLeft;
                            _gra.RenderFill(cap, e);
                            _gra.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.DiagonalRight;
                            _gra.RenderFill(new NextUI.Shape.Circle(smallWrap), e);
                        }
                        break;
                    case PointerCapType.Type4:
                        {
                            cap = new NextUI.Shape.CustomCircle1(this.Bound);
                            _shadow.Render(cap, e);
                            int shrinkSize = (int)((_diameter / 2) * 0.4);
                            RectangleWrap smallWrap = this.Bound.Shrink(shrinkSize);
                            _gra.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.DiagonalLeft;
                            _gra.RenderFill(cap, e);
                            _gra.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.DiagonalRight;
                            _gra.RenderFill(new NextUI.Shape.CustomCircle1(smallWrap), e);
                        }
                        break;
                    case PointerCapType.Type5:
                        cap = new NextUI.Shape.CustomCircleRing(this.Bound);
                        ((NextUI.Shape.CustomCircleRing)cap).ScaleBarSize = (int)((_diameter / 2)* 0.5);
                        ((NextUI.Shape.CustomCircleRing)cap).SweepAngle = 20;
                        ((NextUI.Shape.CustomCircleRing)cap).StartAngle = 260;
                        _shadow.Render(cap, e);
                        _gra.RenderFill(cap,e);
                        break;
                    case PointerCapType.Type6:
                        {
                            cap = new NextUI.Shape.CustomCircle1(this.Bound);
                            ((NextUI.Shape.CustomCircle1)cap).NumberOfFace = 18;
                            _shadow.Render(cap, e);
                            int shrinkSize = (int)((_diameter / 2) * 0.4);
                            RectangleWrap smallWrap = this.Bound.Shrink(shrinkSize);
                            _gra.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.DiagonalLeft;
                            _gra.RenderFill(cap, e);
                            _gra.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.HorizontalCenter;
                            _gra.RenderFill(new NextUI.Shape.Circle(smallWrap), e);
                            shrinkSize = (int)((_diameter / 2) * 0.1);
                            smallWrap = smallWrap.Shrink(shrinkSize);
                            _gra.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.Solid;
                            _gra.RenderFill(new NextUI.Shape.Circle(smallWrap), e);
                        }
                        break;
                    default:
                        break;
                }
                if (_image != null)
                {
                    e.DrawImage(_image, this.Bound.Rect, new Rectangle(0, 0, _image.Width, _image.Height), GraphicsUnit.Pixel);
                }
                if (_enableBorder)
                {
                    e.DrawPath(new Pen(this._borderColor, this._borderWidth), cap.RenderPath());
                }
            }
        }

    }
}
