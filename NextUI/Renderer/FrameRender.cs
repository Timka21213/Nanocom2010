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
using NextUI.Shape;
using NextUI.Common;

namespace NextUI.Renderer
{
    /// <summary>
    /// A class that help to render the outer frame of the gauge
    /// </summary>
    public class FrameRender
    {
        /// <summary>
        /// Type of frame that is currently supported
        /// </summary>
        public enum FrameOutline {
            /// <summary>
            /// Specifies no outer frame
            /// </summary>
            None,
            /// <summary>
            /// Specifies a solid color frame
            /// </summary>
            Type1 , 
            /// <summary>
            /// Type 2 metallic frame
            /// </summary>
            Type2, 
            /// <summary>
            /// Type 3 metallic frame
            /// </summary>
            Type3 ,
            /// <summary>
            /// Type 4 frame
            /// </summary>
            Type4, 
            /// <summary>
            /// Type 5 frame
            /// </summary>
            Type5,
            /// <summary>
            /// Type 6 frame
            /// </summary>
            Type6
        };
        private FrameOutline _outline = FrameOutline.Type2;
        private int _frameWidth = 5;
        private Color _mainColor = Color.Black;
        private Frame.Frame _toplevel = null;
        private RendererGradient _gra = null; 

        internal Frame.Frame TopLevel
        {
            get { return _toplevel; }
            set { _toplevel = value; }
        }

        internal FrameRender(Frame.Frame toplevel)
        {
            _toplevel = toplevel;
            _gra = new RendererGradient(_toplevel);
            _gra.NoAutoRefresh = true;
        }
  
        /// <summary>
        /// Get or set the outline to be rendered .
        /// </summary>
        public FrameOutline Outline
        {
            get { return _outline; }
            set
            {
                if (_outline != value)
                {
                    _outline = value;
                    _toplevel.Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set the main color of the frame
        /// </summary>
        public Color MainColor
        {
            get { return _mainColor; }
            set
            {
                if (_mainColor != value)
                {
                    _mainColor = value;
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the thickness of the frame
        /// </summary>
        public int FrameWidth
        {
            get { return _frameWidth;}
            set { if ( _frameWidth != value )
            {
                _frameWidth = value;
                _toplevel.Invalidate();
            }
            }
        }

        internal void Render(BaseShape shape, Graphics e)
        {
            RectangleWrap shrinkWrap;
            switch (_outline)
            {
                case FrameOutline.None:
                    break;
                case FrameOutline.Type1:
                    _gra.CenterColor = this.MainColor;
                    _gra.FillGradientType = RendererGradient.GradientType.Solid;
                    _gra.RenderDraw(shape, this.FrameWidth,e);
                    break;
                case FrameOutline.Type2:
                    _gra.CenterColor = Color.White;
                    _gra.EndColor = this.MainColor;
                    _gra.FillGradientType = RendererGradient.GradientType.VerticalCenter; 
                    _gra.RenderDraw(shape,this._frameWidth, e);
                    _gra.FillGradientType = RendererGradient.GradientType.HorizontalCenter;
                    _gra.CenterColor = Color.White;
                    _gra.EndColor = this.MainColor;
                    shrinkWrap = shape.Bound.Shrink((int)(this.FrameWidth * 0.5f));
                    shape.Bound = shrinkWrap;
                    _gra.RenderDraw(shape, this.FrameWidth * 0.5f,e);
                    break;
                case FrameOutline.Type3:
                    _gra.CenterColor = Color.White;
                    _gra.EndColor = this.MainColor;
                    _gra.FillGradientType = RendererGradient.GradientType.HorizontalCenter;
                    _gra.RenderDraw(shape, this._frameWidth, e);
                    _gra.FillGradientType = RendererGradient.GradientType.VerticalCenter;
                    _gra.CenterColor = Color.White;
                    _gra.EndColor = this.MainColor;
                    shrinkWrap = shape.Bound.Shrink((int)(this.FrameWidth * 0.5f));
                    shape.Bound = shrinkWrap;
                    _gra.RenderDraw(shape, this.FrameWidth * 0.5f, e);
                    break;
                case FrameOutline.Type4:
                    _gra.CenterColor = Color.FromArgb(100, this.MainColor);
                    _gra.FillGradientType = RendererGradient.GradientType.Solid;
                    _gra.RenderDraw(shape, 0.6f*this.FrameWidth, e);
                    _gra.CenterColor = this.MainColor;
                    _gra.EndColor = Color.FromArgb(150, this.MainColor);
                    _gra.FillGradientType = RendererGradient.GradientType.HorizontalCenter;
                    _gra.RenderDraw(shape,this._frameWidth, e);
                    _gra.FillGradientType = RendererGradient.GradientType.VerticalCenter;
                    _gra.CenterColor = this.MainColor;
                    _gra.EndColor = Color.FromArgb(150, this.MainColor);
                    shrinkWrap = shape.Bound.Shrink((int)(this.FrameWidth * 0.6f));
                    shape.Bound = shrinkWrap;
                    _gra.RenderDraw(shape, this.FrameWidth * 0.6f, e);
                    break;
                case FrameOutline.Type5:
                    _gra.CenterColor = Color.FromArgb(100, this.MainColor);
                    _gra.FillGradientType = RendererGradient.GradientType.Solid;
                    _gra.RenderDraw(shape, 0.6f*this.FrameWidth, e);
                    _gra.CenterColor = this.MainColor;
                    _gra.EndColor = Color.FromArgb(150, this.MainColor);
                    _gra.FillGradientType = RendererGradient.GradientType.VerticalCenter;
                    _gra.RenderDraw(shape, this._frameWidth, e);
                    _gra.FillGradientType = RendererGradient.GradientType.VerticalCenter;
                    _gra.CenterColor = this.MainColor;
                    _gra.EndColor = Color.White;
                    shrinkWrap = shape.Bound.Shrink((int)(this.FrameWidth * 0.6f));
                    shape.Bound = shrinkWrap;
                    _gra.RenderDraw(shape, this.FrameWidth * 0.6f, e);
                    break;
                case FrameOutline.Type6:

                    _gra.CenterColor = Color.FromArgb(150, this.MainColor);
                    _gra.EndColor = this.MainColor;
                    _gra.FillGradientType = RendererGradient.GradientType.HorizontalCenter;
                    _gra.RenderDraw(shape, this._frameWidth, e);
                    _gra.FillGradientType = RendererGradient.GradientType.HorizontalCenter;
                    _gra.CenterColor = this.MainColor;
                    _gra.EndColor = Color.White;
                    shrinkWrap = shape.Bound.Shrink((int)(this.FrameWidth * 0.6f));
                    shape.Bound = shrinkWrap;
                    _gra.RenderDraw(shape, this.FrameWidth * 0.6f, e);
                    break;
            }
        }

    }
}
