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

namespace NextUI.Shape
{
    /// <summary>
    /// provide a class to generate a custom triangle
    /// </summary>
    public class CustomTriangle : BaseShape
    {
        /// <summary>
        /// the direction the triangle is pointing to
        /// </summary>
        public enum PointDirection { 
            /// <summary>
            /// triangle is pointing upward
            /// </summary>
            up,
            /// <summary>
            /// triangle is pointing downward
            /// </summary>
            down };
        private GraphicsPath _path;
        private PointDirection _direction = PointDirection.up;

        /// <summary>
        /// Get or set the direction the triangle is pointing to 
        /// </summary>
        public PointDirection Direction
        {
            get { return _direction; }
            set
            {
                if (_direction != value)
                {
                    _direction = value;
                }
            }
        }

        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="container">a rectangle wrap object that defines the bound</param>
        public CustomTriangle(RectangleWrap container)
            : base(container)
        {

        }
        /// <summary>
        /// Generate a custom triangle
        /// </summary>
        /// <returns>region of the triangle</returns>
        public override Region RenderRegion()
        {
            return new Region(Render());
        }
        /// <summary>
        /// Generate a custom triangle
        /// </summary>
        /// <returns>graphicpath of the triangle</returns>
        public override GraphicsPath RenderPath()
        {
            return Render();
        }

        private GraphicsPath Render()
        {
            _path = new GraphicsPath();
            Point center = new Point(), left = new Point(), bleft = new Point(), bright = new Point(), right = new Point();
            //triangle is 20 % of the Height
            int triangleLen = (int)(0.2 * this.Bound.Height);
            switch (_direction)
            {
                case PointDirection.up:
                    center = new Point(this.Bound.Width / 2 + this.Bound.Left,
                                            this.Bound.Top);
                    left = new Point(this.Bound.Left, triangleLen + this.Bound.Top);
                    bleft = new Point(this.Bound.Left, this.Bound.Top + this.Bound.Height);
                    bright = new Point(this.Bound.Left + this.Bound.Width, this.Bound.Top + this.Bound.Height);
                    right = new Point(this.Bound.Left + this.Bound.Width, triangleLen + this.Bound.Top);
                    break;
                case PointDirection.down:
                    center = new Point(this.Bound.Width / 2 + this.Bound.Left,
                        this.Bound.Top + this.Bound.Height);
                    left = new Point(this.Bound.Left,  this.Bound.Top + this.Bound.Height - triangleLen);
                    bleft = new Point(this.Bound.Left, this.Bound.Top );
                    bright = new Point(this.Bound.Left + this.Bound.Width, this.Bound.Top);
                    right = new Point(this.Bound.Left + this.Bound.Width,   this.Bound.Top + this.Bound.Height - triangleLen);
                    break;
            }

            _path.AddPolygon(new Point[] { center, left, bleft, bright, right });
            _path.CloseAllFigures();

            return _path;
        }

    }
}
