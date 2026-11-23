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


namespace NextUI.Shape
{
    /// <summary>
    /// Parent class for all shapes in the library, this is meant to be an
    /// internal used class
    /// </summary>
    public abstract class BaseShape
    {
        private RectangleWrap _container;
        private Point _center = new Point(0, 0);
        private int _radius = 10;

        /// <summary>
        /// Get or set  the radius of the shape , this parameter is used if the
        /// frame type is a circular frame
        /// </summary>
        internal virtual int Radius
        {
            get { return _radius; }
           set
            {
                if (_radius != value)
                {
                    _radius = value;
                }
            }
        }

        /// <summary>
        /// Get or Set  the center of the circular shape.
        /// </summary>
        internal virtual Point Center
        {
            get { return _center; }
            set
            {
                if (_center != value)
                {
                    _center = value;
                }
            }
        }
       

        /// <summary>
        /// Return the Bound that is used internally.
        /// The Bound is a ractangleWrap that tells the 
        /// boundary which the shape should be rendered.
        /// </summary>
        public virtual RectangleWrap Bound
        {
            get { return _container; }
            set
            {
                if (value != null && _container != value)
                {
                    RectangleWrap wrap = (RectangleWrap)value;
                    _container = new RectangleWrap(wrap.Rect);
                    UpdateParameter(_container);
                }
            }
        }
        
        /// <summary>
        /// The basic contructor of a shape
        /// </summary>
        /// <param name="bound">A rectangle wrapper object that defines the bound</param>
        public BaseShape(RectangleWrap bound)
        {
            _container = bound;
            //Get the radius of the Circle , we use the smaller of the side
            UpdateParameter(bound);
        }

        /// <summary>
        /// update the bound , the radius and the center , internal used only
        /// </summary>
        /// <param name="bound">a rectangle wrap object that defines the bound</param>
        protected virtual void UpdateParameter(RectangleWrap bound)
        {
            if (bound.Height < bound.Width)
            {
                _radius = bound.Height;
            }
            else
            {
                _radius = bound.Width;
            }
            _radius = _radius / 2;
            //Get the center of the RectangleWrap .
            _center = new Point(bound.Left + bound.Width / 2,
                              bound.Top + bound.Height / 2);
        }
        
        /// <summary>
        /// Return a Region of shape , to be implemented by child class
        /// </summary>
        /// <returns>Region of the shape</returns>
        public abstract Region RenderRegion();
        /// <summary>
        /// Return a GraphicPath of the shape , to be implemted by child class
        /// </summary>
        /// <returns>GraphicPath of the shape</returns>
        public abstract GraphicsPath RenderPath();
    }
}
