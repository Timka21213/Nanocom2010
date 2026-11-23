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
    /// A class that helps to render the shadow , by default shadow is always black
    /// </summary>
    public class RenderShadow
    {
        /// <summary>
        /// Set the direction of the shadow that will be cast
        /// </summary>
 
        public enum Direction { 
            /// <summary>
            /// Set the shadow casting direction to be backward
            /// </summary>
            Backward, 
            /// <summary>
            /// Set the shadow casting direction to be forward
            /// </summary>
            Forward
        };
        private int _opacity = 100;
        private int _offset = 0;
        private Color _shadowColor = Color.Black;
        private Direction _direction = Direction.Backward;
        private bool _visible = true;
        private Frame.Frame _toplevel = null;

        internal Frame.Frame TopLevel
        {
            get { return _toplevel; }
            set
            {
                _toplevel = value;
            }

        }

        internal RenderShadow(Frame.Frame parent)
        {
            _toplevel = parent;
        }

        /// <summary>
        /// get or set the visibility of the shadow, set to false to disable it 
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
        /// Get or set the direction of casting 
        /// </summary>
        public Direction CastDirection
        {
            get { return _direction; }
            set
            {
                if (_direction != value)
                {
                    _direction = value;
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get of set the offset of the shadow , offset can be positive or negative
        /// </summary>
        public int Offset
        {
            get { return _offset; }
            set
            {
                if (_offset != value)
                {
                    _offset = value;
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// The opacity of the shadow, the higher the opacity , the less translucent it is
        /// </summary>
        public int Opacity
        {
            get { return _opacity; }
            set
            {
                if (_opacity >= 0 && _opacity <= 255)
                {
                    _opacity = value;
                    _toplevel.Invalidate();
                }
            }
        }
        internal void Render(Shape.BaseShape shape,Graphics e)
        {
            if (_visible)
            {
                Matrix m = new Matrix();
                m = e.Transform;
                SolidBrush brush = new SolidBrush(Color.FromArgb(Opacity, _shadowColor));
                GraphicsState state = e.Save();
                if (_direction == Direction.Backward)
                {
                    m.Translate(-_offset, _offset );
                }
                else
                {
                    m.Translate(_offset, _offset );
                }
                e.Transform = m;
                e.FillPath(brush, shape.RenderPath());
                e.Restore(state);
            }
            
        }

        internal void RenderFillPath(GraphicsPath shape, Graphics e)
        {
            if (_visible)
            {
                Matrix m = new Matrix();
                m = e.Transform;
                SolidBrush brush = new SolidBrush(Color.FromArgb(Opacity, _shadowColor));
                GraphicsState state = e.Save();
                if (_direction == Direction.Backward)
                {
                    m.Translate(-_offset, _offset);
                }
                else
                {
                    m.Translate(_offset, _offset);
                }
                e.Transform = m;
                e.FillPath(brush, shape);
                e.Restore(state);
            }

        }

        internal void RenderDraw(GraphicsPath shape, Graphics e, float penThickness)
        {
            if (_visible)
            {
                Matrix m = new Matrix();
                m = e.Transform;
                SolidBrush brush = new SolidBrush(Color.FromArgb(Opacity, _shadowColor));
                GraphicsState state = e.Save();
                if (_direction == Direction.Backward)
                {
                    m.Translate(-_offset, _offset );
                }
                else
                {
                    m.Translate(_offset, _offset );
                }
                e.Transform = m;
                e.DrawPath(new Pen(brush, penThickness), shape);
                e.Restore(state);
            }

        }
    }
}
