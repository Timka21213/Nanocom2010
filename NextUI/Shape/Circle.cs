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
    /// provide a class to generate a circle 
    /// The Circle will use the smaller length of the rectangleWrap
    /// as the radius.
    /// It is meant to be internal used only
    /// </summary>
    public class Circle : BaseShape
    {
        private GraphicsPath _path;
        private Rectangle _rect;

        /// <summary>
        /// A circle contructor 
        /// </summary>
        /// <param name="container">a rectangle wrap object that defines the bound</param>
        public Circle(RectangleWrap container): base(container)
        {
            
        }
        /// <summary>
        /// Generate a Circle
        /// </summary>
        /// <returns>return region</returns>
        public override Region RenderRegion()
        {
            return new Region(Render());
        }
        /// <summary>
        /// Generate a graphic path of circle
        /// </summary>
        /// <returns>return graphicpath</returns>
        public override GraphicsPath RenderPath()
        {
            return Render();
        }

        private GraphicsPath Render()
        {
            _path = new GraphicsPath();

            if (this.Radius > Global.SIZE)
            {
                _rect = new Rectangle(this.Center.X - this.Radius, this.Center.Y - this.Radius, 2 * this.Radius, 2 * this.Radius);
            }
            else
            {
                _rect = new Rectangle(this.Center.X - this.Radius, this.Center.Y - this.Radius, Global.SIZE, Global.SIZE);
            }
            _path.AddEllipse(_rect);
            return _path;
        }
    }
}
