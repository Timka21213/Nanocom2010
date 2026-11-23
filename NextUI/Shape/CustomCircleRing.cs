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
    /// provide a class to generate a circle ring
    /// The Circle will use the smaller length of the rectangleWrap
    /// as the radius.
    /// </summary>
    public class CustomCircleRing : BaseShape
    {
        private GraphicsPath _path;
        private float _startGapAngle = 35;
        private float _sweepAngle = 30;
        private int _scaleBarSize = 10;

        /// <summary>
        /// Get or set the thickness of the shape
        /// </summary>
        public int ScaleBarSize
        {
            get { return _scaleBarSize; }
            set
            {
                if (_scaleBarSize != value)
                {
                    _scaleBarSize = value;
                }
            }
        }

        /// <summary>
        /// Get or set starting Angle of the ring , measure from x axis
        /// </summary>

        public float StartAngle
        {
            get { return _startGapAngle; }
            set
            {
                if (_startGapAngle != value && value < 360f)
                {
                   // if (_sweepAngle + _startGapAngle < 350f)
                    //{
                        _startGapAngle = value;
                    //}
                }
            }
        }

        /// <summary>
        /// Get or set the sweep Angle of the scale bar , starting from StartAngle
        /// </summary>
        public float SweepAngle
        {
            get { return _sweepAngle; }
            set
            {
                if (_sweepAngle != value && value < 360f)
                {
                 //   if (_sweepAngle + _startGapAngle < 350f)
                   // {
                        _sweepAngle = value;
                    //}
                }
            }
        }
 
        /// <summary>
        /// basic constructor
        /// </summary>
        /// <param name="container">a rectangle wrap object that defines the bound</param>
        public CustomCircleRing(RectangleWrap container)
            : base(container)
        {

        }
        /// <summary>
        /// Generate a ring
        /// </summary>
        /// <returns>region of the ring</returns>
        public override Region RenderRegion()
        {
            return new Region(Render());
        }
        /// <summary>
        /// Generate a ring
        /// </summary>
        /// <returns>graphicpath of the ring</returns>
        public override GraphicsPath RenderPath()
        {
            return Render();
        }

        private GraphicsPath Render()
        {
            _path = new GraphicsPath();
            //Get the center of the RectangleWrap .
            //The bound of the ring depends on the center and the radius.
            RectangleWrap bound = new RectangleWrap(
                new Rectangle(this.Center.X - this.Radius, this.Center.Y - this.Radius,
                              this.Radius * 2, this.Radius * 2));
            //Get the radius of the Circle , we use the smaller of the side
            _path.AddArc(bound.Rect, _startGapAngle + _sweepAngle, 360 - _sweepAngle);
            _path.Reverse();
            RectangleWrap inner = bound.Shrink(this._scaleBarSize);
            PointF out1 = Helper.AlgorithmHelper.LocationToCenter(this.Center, bound.Width / 2, _startGapAngle);
            PointF in1 = Helper.AlgorithmHelper.LocationToCenter(this.Center, inner.Width / 2, _startGapAngle);
            PointF out2 = Helper.AlgorithmHelper.LocationToCenter(this.Center, bound.Width / 2, _startGapAngle + _sweepAngle);
            PointF in2 = Helper.AlgorithmHelper.LocationToCenter(this.Center, inner.Width / 2, _startGapAngle + _sweepAngle);
            _path.AddLine(out2, in2);
            _path.AddArc(inner.Rect, _startGapAngle + _sweepAngle, 360 - _sweepAngle);
            _path.AddLine(in1, out1);
            _path.CloseAllFigures();
            return _path;
        }
    }
}
