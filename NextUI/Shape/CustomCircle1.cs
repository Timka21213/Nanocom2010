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
    /// provide a class to generate a gear like  circle .
    /// Internal used only
    /// </summary>
    public class CustomCircle1 : BaseShape
    {
        private GraphicsPath _path;
        private int _numberOfFace = 12;

        /// <summary>
        /// Get or set the number of face for this circle, the number of face must be multiple of 2
        /// </summary>
        public int NumberOfFace
        {
            get { return _numberOfFace; }
            set
            {
                if (_numberOfFace != value && (_numberOfFace % 2) == 0)
                {
                    _numberOfFace = value;
                }
            }
        }

        /// <summary>
        /// Basic contructor 
        /// </summary>
        /// <param name="container">a rectangle wrap object that defines the bound</param>
        public CustomCircle1(RectangleWrap container)
            : base(container)
        {
          
        }
        /// <summary>
        /// Generate a custom  circle  
        /// </summary>
        /// <returns>region of the circle</returns>
        public override Region RenderRegion()
        {
            return new Region(Render());
        }
        /// <summary>
        /// Generate a graphicpath of the circle
        /// </summary>
        /// <returns>graphicpath of the circle</returns>
        public override GraphicsPath RenderPath()
        {
            return Render();
        }

        private GraphicsPath Render()
        {
             _path = new GraphicsPath();
             Rectangle innerRect;
            Rectangle rect;
            if (this.Radius > Global.SIZE)
            {
                rect = new Rectangle(this.Center.X - this.Radius, this.Center.Y - this.Radius, 2 * this.Radius, 2 * this.Radius);
            }
            else
            {
                rect = new Rectangle(this.Center.X - this.Radius, this.Center.Y - this.Radius, Global.SIZE, Global.SIZE);
            }
            //Inner rect is always 10 % lesser
            innerRect = new Rectangle(rect.Left + (int)(this.Radius * 0.1),
                                       rect.Top + (int)(this.Radius * 0.1),
                                       rect.Width - (int)(2 * (this.Radius * 0.1)),
                                       rect.Height - (int)(2 * (this.Radius * 0.1)));
            float angle = 360 / _numberOfFace;
            float startAngle = 270 - (angle/2);
            for (int i = 0; i < _numberOfFace; i+=2)
            {
                _path.AddArc(rect, startAngle + i*angle, angle);
                _path.AddArc(innerRect,startAngle +(i+1)* angle, angle); 
            }
            _path.CloseAllFigures();
            return _path;
        }
    }
}
