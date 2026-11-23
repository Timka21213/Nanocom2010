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
    /// provide a class to generate a half circle
    /// facing downward
    /// </summary>
    public class HalfCircleCustom4 : BaseShape
    {
        private GraphicsPath _path;
        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="container">a rectangle wrap object that defines the bound</param>
        public HalfCircleCustom4(RectangleWrap container)
            : base(container)
        {

        }
        /// <summary>
        /// Generate a half circle facing downward
        /// </summary>
        /// <returns>the region of the circle</returns>
        public override Region RenderRegion()
        {
            return new Region(Render());
        }
        /// <summary>
        /// Generate a half circle facing downward
        /// </summary>
        /// <returns>the graphic path of the half circle</returns>
        public override GraphicsPath RenderPath()
        {
            return Render();
        }

        private GraphicsPath Render()
        {
            _path = new GraphicsPath();
            Rectangle bigarc = new Rectangle(this.Bound.Left + (this.Bound.Width / 2) - this.Radius,
                                             this.Bound.Top + this.Bound.Height / 2 - this.Radius,
                                             2 * this.Radius, 2 * this.Radius);
            _path.AddArc(bigarc, 0f, 180f);

            int smallarcWidth = (int)(this.Radius * 0.4);
            if (smallarcWidth < Global.SIZE)
            {
                smallarcWidth = Global.SIZE;
            }
            Rectangle smallarc = new Rectangle(this.Bound.Left + this.Bound.Width / 2 - this.Radius ,
                                              this.Bound.Top + this.Bound.Height /2 - (int)(this.Radius * 0.4), 
                                              2 * this.Radius, 2*smallarcWidth);
            _path.AddArc(smallarc, 180f, 180f);
            //     Rectangle midarc = new Rectangle(
            return _path;

        }
    }
}
