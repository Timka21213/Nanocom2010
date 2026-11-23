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
    /// Provide a class to generate a quarter circle
    /// facing downward right
    /// </summary>
    public class QuarterCustom4 : BaseShape
    {
        private GraphicsPath _path;
        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="container">a rectangle wrap object that defines the bound</param>
        public QuarterCustom4(RectangleWrap container)
            : base(container)
        {
        }

        /// <summary>
        /// Generate a custom quarter circle  
        /// </summary>
        /// <returns>Region of the quarter circle</returns>
        public override Region RenderRegion()
        {
            return new Region(Render());
        }
        /// <summary>
        /// Generate a custom quarter circle
        /// </summary>
        /// <returns>Graphicpath of the quarter circle</returns>
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
            _path.AddArc(bigarc, 350f, 100f);

            int smallarcWidth = (int)(this.Radius * 0.4);
            if (smallarcWidth < Global.SIZE)
            {
                smallarcWidth = Global.SIZE;
            }
            Rectangle smallarc = new Rectangle(this.Bound.Left + this.Bound.Width / 2 - (int)(this.Radius * 0.4),
                                              this.Bound.Top + this.Bound.Height / 2 - this.Radius,
                                              2 * smallarcWidth, 2 * this.Radius);
            _path.AddArc(smallarc, 90f, 115f);
            _path.CloseAllFigures();

            return _path;
        }

    }
}
