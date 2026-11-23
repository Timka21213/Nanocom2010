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
    public class CustomTriangle2 : BaseShape
    {
        /// <summary>
        /// The direction at which the slope is facing
        /// </summary>
        public enum Direction { 
            /// <summary>
            /// The slope is facing downward
            /// </summary>
            Downward, 
            /// <summary>
            /// The slope if facing upward
            /// </summary>
            Upward, 
            /// <summary>
            /// the slope is facing bothway
            /// </summary>
            Both };
        private GraphicsPath _path;
        private int _startWidth = 10;
        private int _endWidth = 10;
        private Direction _direction = Direction.Upward;

        /// <summary>
        /// get or set the facing direction of the slope
        /// </summary>
        public Direction FacingDirection
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
        /// Get or set the start width of the triangle
        /// </summary>
        public int StartWidth
        {
            get { return _startWidth; }
            set
            {
                if (_startWidth != value)
                {
                    _startWidth = value;
                }
            }
        }

        /// <summary>
        /// Get or set the end width of the triangle
        /// </summary>
        public int EndWidth
        {
            get { return _endWidth; }
            set
            {
                if (_endWidth != value)
                {
                    _endWidth = value;
                }
            }
        }


        /// <summary>
        /// Basic constructor of the custom triangle
        /// </summary>
        /// <param name="container">a rectangle wrap object that defines the bound</param>
        public CustomTriangle2(RectangleWrap container)
            : base(container)
        {

        }
        /// <summary>
        /// Generate a custom triangle
        /// </summary>
        /// <returns>the region of the triangle</returns>
        public override Region RenderRegion()
        {
            return new Region(Render());
        }
        /// <summary>
        /// Generate a custom triangle
        /// </summary>
        /// <returns>the graphicpath of the triangle</returns>
        public override GraphicsPath RenderPath()
        {
            return Render();
        }

        private GraphicsPath Render()
        {
            _path = new GraphicsPath();
            switch (_direction)
            {
                case Direction.Both:
                    _path.AddLine(new Point(this.Bound.Left, this.Bound.Top + this.Bound.Height / 2 - this.StartWidth / 2),
                                  new Point(this.Bound.Left + this.Bound.Width, this.Bound.Top + this.Bound.Height / 2 - this.EndWidth / 2));
                    _path.AddLine(new Point(this.Bound.Left + this.Bound.Width, this.Bound.Top + this.Bound.Height / 2 + this.EndWidth / 2),
                                  new Point(this.Bound.Left, this.Bound.Top + this.Bound.Height / 2 + this.StartWidth / 2));
                    _path.CloseAllFigures();
                    break;

                case Direction.Downward:
                    _path.AddLine(new Point(this.Bound.Left, this.Bound.Top),
                                  new Point(this.Bound.Left + this.Bound.Width, this.Bound.Top));
                    _path.AddLine(new Point(this.Bound.Left + this.Bound.Width, this.Bound.Top + this.EndWidth),
                                  new Point(this.Bound.Left, this.Bound.Top + this.StartWidth));
                    _path.CloseAllFigures();
                    break;

                case Direction.Upward:
                    _path.AddLine(new Point(this.Bound.Left, this.Bound.Top + this.Bound.Height),
                                  new Point(this.Bound.Left + this.Bound.Width, this.Bound.Top + this.Bound.Height));
                    _path.AddLine(new Point(this.Bound.Left + this.Bound.Width, this.Bound.Top + this.Bound.Height - this.EndWidth),
                                  new Point(this.Bound.Left, this.Bound.Top + this.Bound.Height - this.StartWidth));
                    _path.CloseAllFigures();
                    break;
            }
            return _path;
        }
         
        

    }
}
