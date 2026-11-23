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

namespace NextUI.Common
{
    /// <summary>
    /// A Common rectangle class that is used throughout the library
    /// This class will ensure the reactangle will not have size
    /// lesser or equal to 0.
    /// </summary>
    public class RectangleWrap
    {
        private Rectangle _rect;
        /// <summary>
        /// The Left Coordinate
        /// </summary>
        public int Left
        {
            get { return _rect.Left; }
        }

        /// <summary>
        /// The uppper  Coordinate
        /// </summary>
        public int Top
        {
            get { return _rect.Top; }
        }

        /// <summary>
        /// The Width of the Rectangle , you cannot set the 
        /// width to be lesser than Global.SIZE.
        /// </summary>
        public int Width
        {
            get { return _rect.Width; }
            set
            {
                if (_rect.Width != value && _rect.Width > Global.SIZE)
                {
                    _rect.Width = value;
                }
            }
        }

        /// <summary>
        /// The Height of the Rectangle , you cannot set the 
        /// height to be lesser than Global.SIZE.
        /// </summary>
        public int Height
        {
            get { return _rect.Height; }
            set
            {
                if (_rect.Height != value && _rect.Height > Global.SIZE)
                {
                    _rect.Height = value;
                }
            }
        }

        /// <summary>
        /// A convenient property that returns the readonly rectangle.
        /// </summary>
        public Rectangle Rect
        {
            get { return _rect; }
        }
        /// <summary>
        /// Contruct a RectangleWrap with a rectangle
        /// </summary>
        /// <param name="rect"></param>

        public RectangleWrap(Rectangle rect)
        {
            if (rect.Width <= Global.SIZE || rect.Height <= Global.SIZE)
            {
                _rect = rect;
                _rect.Height = Global.SIZE;
                _rect.Width = Global.SIZE;
            }
            else
            {
                _rect = rect;
            }
        }
        /// <summary>
        /// The Shrink method will help to reduce the size the bound
        /// and return a new RectangleWrap object
        /// so long as the reduce size is not smaller than Global.SIZE
        /// </summary>
        /// <param name="pixel"> the size to be reduced</param>
        public RectangleWrap Shrink(int pixel)
        {
            if (_rect.Width - 2 * pixel <= Global.SIZE ||
                 _rect.Height - 2 * pixel <= Global.SIZE)
            {
                return this;
            }
            Rectangle rect= new Rectangle(_rect.Left  + pixel,
                                  _rect.Top  + pixel,
                                  _rect.Width - 2 * pixel,
                                  _rect.Height - 2 * pixel);
            return new RectangleWrap(rect);

        }

        /// <summary>
        ///  To expand the size of the rectangle and return 
        /// a new RectangleWrap
        /// </summary>
        /// <param name="pixel"></param>

        public RectangleWrap Expand(int pixel)
        {
            if (pixel > 0)
            {
                Rectangle rect = new Rectangle(_rect.Left - pixel,
                                    _rect.Top - pixel,
                                    _rect.Width + 2 * pixel,
                                    _rect.Height + 2 * pixel);
                return new RectangleWrap(rect);
            }
            return this;
        }

    }
}
