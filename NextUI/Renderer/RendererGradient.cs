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

namespace NextUI.Renderer
{
    /// <summary>
    /// This class is a helper class to render any gradient shade.
    /// </summary>
    public class RendererGradient
    {
        /// <summary>
        /// Provides a different type of gradient rendering
        /// </summary>

        public enum GradientType
        {
            /// <summary>
            /// Disable any rendering
            /// </summary>
            None, 
            /// <summary>
            /// Specifies a gradient from Left to Right. 
            /// </summary>
            LeftRight,
            /// <summary>
            /// Specifies a gradient from Top to Bottom.
            /// </summary>
            TopBottom,
            /// <summary>
            /// Specifies a gradient from Center.
            /// </summary>
            Center,
            /// <summary>
            /// Specifies a gradient from Top Left to Bottom Right
            /// </summary>
            DiagonalLeft,
            /// <summary>
            /// Specifies a gradient from Top Right to Bottom Left.  
            /// </summary>
            DiagonalRight, 
            /// <summary>
            /// Specifies a gradient from Center to Left and Right. 
            /// </summary>
            HorizontalCenter,
            /// <summary>
            /// Specifies a gradient from Center to Top and Bottom. 
            /// </summary>
            VerticalCenter,
            /// <summary>
            /// Specifies a non gradient solid color
            /// </summary>
            Solid
        };

        private Color _endColor = Color.White;
        private GradientType _fillGradientType = GradientType.Center;
        private Color _centerColor = Color.White;
        private Frame.Frame _toplevel = null;
        
        private bool _noAutoUpdate = false;

        internal bool NoAutoRefresh
        {
            get { return _noAutoUpdate; }
            set { _noAutoUpdate = value; }
        }

        internal Frame.Frame TopLevel
        {
            get { return _toplevel; }
            set { _toplevel = value; }
        }

        internal RendererGradient(Frame.Frame toplevel)
        {
            _toplevel = toplevel;
        }

        /// <summary>
        /// Get or set the Main Color of the gradient to be rendered 
        /// </summary>
        public Color CenterColor
        {
            get { return _centerColor; }
            set
            {
                if (_centerColor != value)
                {
                    _centerColor = value;
                    if ( ! _noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the type of gradient to be rendered
        /// </summary>

        public GradientType FillGradientType
        {
            get { return _fillGradientType; }
            set
            {
                if (_fillGradientType != value)
                {
                    _fillGradientType = value;
                    if ( !_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }
        /// <summary>
        /// Gets or sets the end color of gradient
        /// </summary>
        public Color EndColor
        {
            get { return _endColor; }
            set
            {
                if (_endColor != value)
                {
                    _endColor = value;
                    if ( !_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }


        internal void RenderFill(BaseShape shape, Graphics e)
        {
            Brush br = null;
            switch (_fillGradientType)
            {
                case GradientType.None:
                    return;
                    
                case GradientType.Solid:
                    br = new SolidBrush(this.CenterColor);
                    break;
                case GradientType.DiagonalLeft:
                    br = new LinearGradientBrush(shape.Bound.Rect, this._endColor, this.CenterColor, LinearGradientMode.ForwardDiagonal);
                    break;
                case GradientType.DiagonalRight:
                    br = new LinearGradientBrush(shape.Bound.Rect, this._endColor, this.CenterColor, LinearGradientMode.BackwardDiagonal);
                    break;
                case GradientType.Center:
                    br = new PathGradientBrush(shape.RenderPath());
                    ((PathGradientBrush)br).CenterColor = this._endColor;
                    ((PathGradientBrush)br).SurroundColors = new Color[] { this.CenterColor };
                    ((PathGradientBrush)br).FocusScales = new PointF(0.8f, 0.8f);
                    break;
                case GradientType.LeftRight:
                    br = new LinearGradientBrush(shape.Bound.Rect, this.CenterColor, this._endColor, LinearGradientMode.Horizontal);
                    break;
                case GradientType.HorizontalCenter:
                    {
                        br = new LinearGradientBrush(shape.Bound.Rect, this.CenterColor, this._endColor, 0, false);
                        Blend bl = new Blend();
                        bl.Factors = new float[] { 0.9f, 0.8f, 0.7f, 0.6f, 0.1f, 0f, 0.1f, 0.6f, 0.7f, 0.8f, 0.9f };
                        bl.Positions = new float[] { 0, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1.0f };
                        ((LinearGradientBrush)br).Blend = bl;
                    }
                    break;
                case GradientType.TopBottom:
                    br = new LinearGradientBrush(shape.Bound.Rect, this.CenterColor, this._endColor, LinearGradientMode.Vertical);
                    break;
                case GradientType.VerticalCenter:
                    {
                        br = new LinearGradientBrush(shape.Bound.Rect, this.CenterColor, _endColor, 0, false);
                        Blend bl = new Blend();
                        ((LinearGradientBrush)br).RotateTransform(90);
                        bl.Factors = new float[] { 0f, 0.1f, 0.6f, 0.7f, 0.8f, 0.9f, 0.8f, 0.7f, 0.6f, 0.1f, 0 };
                        bl.Positions = new float[] { 0, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1.0f };
                        ((LinearGradientBrush)br).Blend = bl;
                    }
                    break;
                default:
                    break;
            }
            e.FillPath(br, shape.RenderPath());
            br.Dispose();
        }

        internal void RenderDraw(BaseShape shape,float Thickness, Graphics e)
        {
            Brush br = null;
            switch (_fillGradientType)
            {
                case GradientType.None:
                    return;
                    
                case GradientType.Solid:
                    br = new SolidBrush(this.CenterColor);
                    break;
                case GradientType.DiagonalLeft:
                    br = new LinearGradientBrush(shape.Bound.Rect, this._endColor, this.CenterColor, LinearGradientMode.ForwardDiagonal);
                    break;
                case GradientType.DiagonalRight:
                    br = new LinearGradientBrush(shape.Bound.Rect, this._endColor, this.CenterColor, LinearGradientMode.BackwardDiagonal);
                    break;
                case GradientType.Center:
                    br = new PathGradientBrush(shape.RenderPath());
                    ((PathGradientBrush)br).CenterColor = this._endColor;
                    ((PathGradientBrush)br).SurroundColors = new Color[] { this.CenterColor };
                    ((PathGradientBrush)br).FocusScales = new PointF(0.8f, 0.8f);
                    break;
                case GradientType.LeftRight:
                    br = new LinearGradientBrush(shape.Bound.Rect, this.CenterColor, this._endColor, LinearGradientMode.Horizontal);
                    break;
                case GradientType.HorizontalCenter:
                    {
                        br = new LinearGradientBrush(shape.Bound.Rect, this.CenterColor, this._endColor, 0, false);
                        Blend bl = new Blend();
                        bl.Factors = new float[] { 0.9f, 0.8f, 0.7f, 0.6f, 0.1f, 0f, 0.1f, 0.6f, 0.7f, 0.8f, 0.9f };
                        bl.Positions = new float[] { 0, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1.0f };
                        ((LinearGradientBrush)br).Blend = bl;
                    }
                    break;
                case GradientType.TopBottom:
                    br = new LinearGradientBrush(shape.Bound.Rect, this.CenterColor, this._endColor, LinearGradientMode.Vertical);
                    break;
                case GradientType.VerticalCenter:
                    {
                        br = new LinearGradientBrush(shape.Bound.Rect, this.CenterColor, _endColor, 0, false);
                        ((LinearGradientBrush)br).RotateTransform(90);
                        Blend bl = new Blend();
                        bl.Factors = new float[] { 0f, 0.1f, 0.6f, 0.7f, 0.8f, 0.9f, 0.8f, 0.7f, 0.6f, 0.1f, 0 };
                        bl.Positions = new float[] { 0, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1.0f };
                        ((LinearGradientBrush)br).Blend = bl;
                    }
                    break;
                default:
                    break;
            }
            
            e.DrawPath(new Pen(br, Thickness), shape.RenderPath());
            br.Dispose();
        }



    }
}
