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
    /// provide a class to generate a RoundedRectangle 
    /// </summary>
    public class RoundedRectangle : BaseShape
    {
        private GraphicsPath _path;
        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="container">a rectangle wrap object that defines the bound</param>
        public RoundedRectangle(RectangleWrap container)
            : base(container)
        {

        }
        /// <summary>
        /// Generate a RoundedRectangle Region
        /// </summary>
        /// <returns>the region of the rectangle</returns>
        public override Region RenderRegion()
        {
            return new Region(Render());
        }
        /// <summary>
        /// Generate a RoundedRectangle Path
        /// </summary>
        /// <returns>the graphic path of the rectangle</returns>
        public override GraphicsPath RenderPath()
        {
            return Render();
        }

        private GraphicsPath Render()
        {
            _path = new GraphicsPath();
            int radius = 10;
            if (Bound.Height < Bound.Width)
            {
                radius = Bound.Height;
            }
            else
            {
                radius = Bound.Width;
            }
            if (radius < Global.SIZE) radius = Global.SIZE;

            //The size the the Corner is always 20 % of the smaller side.
            radius = (int)(radius * 0.4);
            if (radius < Global.SIZE) radius = Global.SIZE;

            //Now we calculate the Path.
            int xr = (this.Bound.Width + this.Bound.Left - radius);
            int yr = (this.Bound.Height + this.Bound.Top - radius);
            int xts = (this.Bound.Left + radius);
            int xte = (xts + (this.Bound.Width - (2 * radius)));
            int yls = (this.Bound.Top + radius);
            int yle = (yls + (this.Bound.Height - (2 * radius)));
            //Lets create the 4 corner
            Rectangle tl = new Rectangle(this.Bound.Left, this.Bound.Top, radius, radius);
            Rectangle tr = new Rectangle(xr, this.Bound.Top, radius, radius);
            Rectangle bl = new Rectangle(this.Bound.Left, yr, radius, radius);
            Rectangle br = new Rectangle(xr, yr, radius, radius);
            //Now we create the Graphic Parh
            _path.AddArc(tl, 180f, 90f);
            _path.AddLine(xts, this.Bound.Top, xte, this.Bound.Top);
            _path.AddArc(tr, 270f, 90f);
            _path.AddLine(this.Bound.Left + this.Bound.Width, yls, this.Bound.Left + this.Bound.Width, yle);
            _path.AddArc(br, 0f, 90f);
            _path.AddLine(xte, this.Bound.Top + this.Bound.Height, xts, this.Bound.Top + this.Bound.Height);
            _path.AddArc(bl, 90f, 90f);
            _path.AddLine(this.Bound.Left, yle, this.Bound.Left, yls);
            _path.CloseAllFigures();
            return _path;
            
        }
    }
}
