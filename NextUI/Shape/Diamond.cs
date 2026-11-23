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
    /// provide a class to generate a diamond shape
    /// </summary>
    public class Diamond : BaseShape
    {
        private GraphicsPath _path;

        /// <summary>
        /// basic constructor
        /// </summary>
        /// <param name="container">a rectangle wrap object that defines the bound</param>
        public Diamond(RectangleWrap container)
            : base(container)
        {

        }
        /// <summary>
        /// Generate a diamond
        /// </summary>
        /// <returns>the region of the diamond</returns>
        public override Region RenderRegion()
        {
            return new Region(Render());
        }
        /// <summary>
        /// generate a diamond
        /// </summary>
        /// <returns>the graphicpath of the diamond</returns>
        public override GraphicsPath RenderPath()
        {
            return Render();
        }

        private GraphicsPath Render()
        {
            _path = new GraphicsPath();

            Point top = new Point(this.Bound.Width / 2 + this.Bound.Left,
                                this.Bound.Top);
            Point side1 = new Point(this.Bound.Left, this.Bound.Top + this.Bound.Height / 2);
            Point side2 = new Point(this.Bound.Left + this.Bound.Width,
                                    this.Bound.Top + this.Bound.Height / 2);
            Point bottom = new Point(this.Bound.Left + this.Bound.Width / 2,
                                     this.Bound.Top + this.Bound.Height);
            _path.AddLine(top, side2);
            _path.AddLine(side2, bottom);
            _path.AddLine(bottom, side1);
            _path.AddLine(side1, top);
            return _path;
        }
    }
}
