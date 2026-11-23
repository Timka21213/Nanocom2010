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
    /// 
    /// </summary>
    public class CustomTriangle1 : BaseShape
    {
        private GraphicsPath _path;
        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="container">a rectangle wrap object that defines the bound</param>
        public CustomTriangle1(RectangleWrap container)
            : base(container)
        {

        }
        /// <summary>
        /// Generate a custom triangle
        /// </summary>
        /// <returns>region of the custom triangle</returns>
        public override Region RenderRegion()
        {
            return new Region(Render());
        }
        /// <summary>
        /// Generate the graphic path of the triangle
        /// </summary>
        /// <returns>graphic path of the triangle</returns>
        public override GraphicsPath RenderPath()
        {
            return Render();
        }

        private GraphicsPath Render()
        {
            _path = new GraphicsPath();
            //triangle is 20 % of the Height
            int triangleHeight = (int)(0.2 * this.Bound.Height);
            int triangleWidth  = (int)(0.5 * this.Bound.Height);
            Point center = new Point(this.Bound.Width / 2 + this.Bound.Left - triangleWidth/2,
                                     this.Bound.Top);
            Point left = new Point(this.Bound.Left + triangleWidth / 2, triangleHeight + this.Bound.Top);
            Point bleft = new Point(this.Bound.Left, this.Bound.Top + this.Bound.Height);
            Point bright = new Point(this.Bound.Left + this.Bound.Width, this.Bound.Top + this.Bound.Height);
            Point right = new Point(this.Bound.Left + this.Bound.Width - triangleWidth / 2, triangleHeight + this.Bound.Top);

            _path.AddPolygon(new Point[] { center, left, bleft, bright, right });
            _path.CloseAllFigures();

            return _path;
        }

    }
}
