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
    /// provide a class to generate a triangle
    /// </summary>
    public class Triangle : BaseShape
    {
        /// <summary>
        /// the direction the triangle is pointing to
        /// </summary>
        public enum PointDirection { 
            /// <summary>
            /// Set the triangle to point upward
            /// </summary>
            up, 
            /// <summary>
            /// Set the triangle to point downward
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
        public Triangle(RectangleWrap container)
            : base(container)
        {

        }
        /// <summary>
        /// Generate a triangle
        /// </summary>
        /// <returns>region of the triangle</returns>
        public override Region RenderRegion()
        {
            return new Region(Render());
        }
        /// <summary>
        /// Generate a triangle
        /// </summary>
        /// <returns>graphicpath of the triangle</returns>
        public override GraphicsPath RenderPath()
        {
            return Render();
        }

        private GraphicsPath Render()
        {
            _path = new GraphicsPath();
            Point center = new Point(), left = new Point(), right = new Point();
            switch (_direction)
            {
                case PointDirection.up:
                     center = new Point(this.Bound.Width / 2 + this.Bound.Left,
                                             this.Bound.Top);
                     left = new Point(this.Bound.Left, this.Bound.Height + this.Bound.Top);
                     right = new Point(this.Bound.Left + this.Bound.Width, this.Bound.Height + this.Bound.Top);
                    break;
                case PointDirection.down:
                     center = new Point(this.Bound.Width / 2 + this.Bound.Left,
                                  this.Bound.Top + this.Bound.Height);
                     left = new Point(this.Bound.Left, this.Bound.Top);
                     right = new Point(this.Bound.Left + this.Bound.Width,  this.Bound.Top);
                    break;
            }

            _path.AddPolygon(new Point[] { center, left, right });
            _path.CloseAllFigures();

            return _path;
        }

    }
}
