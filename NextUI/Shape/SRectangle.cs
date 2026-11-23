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
    /// provide a class to generate a rectangle
    /// </summary>
    public class SRectangle : BaseShape
    {
        private GraphicsPath _path;
        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="container">a rectangle wrap object that defines the bound</param>
        public SRectangle(RectangleWrap container)
            : base(container)
        {

        }
        /// <summary>
        /// Generate a rectangle
        /// </summary>
        /// <returns>region of the rectangle</returns>
        public override Region RenderRegion()
        {
            return new Region(Render());
        }
        /// <summary>
        /// Generate a rectangle
        /// </summary>
        /// <returns>Graphicpath of the rectangle</returns>
        public override GraphicsPath RenderPath()
        {
            return Render();
        }

        private GraphicsPath Render()
        {
            _path = new GraphicsPath();
            int width = this.Bound.Width;
            int height = this.Bound.Height;
            if (this.Bound.Height < Global.SIZE)
            {
                height = Global.SIZE;
            }
            if (this.Bound.Width < Global.SIZE)
            {
                width = Global.SIZE;
            }
            Rectangle temp = new Rectangle(this.Bound.Left, this.Bound.Top, width, height);
            _path.AddRectangle(temp);
            return _path;
        }
    }
}
