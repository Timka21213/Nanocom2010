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
    /// provide a class to generate a arc. It is meant
    /// to be internal used only
    /// </summary>
    public class CustomArc : BaseShape
    {
        /// <summary>
        /// The position of the Arc , diffeent position will provide different Arc
        /// </summary>
        public enum Position { 
            /// <summary>
            /// Render an inner arc
            /// </summary>
            Inner, 
            /// <summary>
            /// Render a cross arc
            /// </summary>
            Cross, 
            /// <summary>
            /// Render an outer arc
            /// </summary>
            Outer };
        private GraphicsPath _path;
        private float _startGapAngle = 35;
        private float _sweepAngle = 30;
        private int _startWidth = 10;
        private int _endWidth = 10;
        private Position _position;

        /// <summary>
        /// Get or set the position of the arc , different position will produce different arc
        /// </summary>
        public Position Direction
        {
            get { return _position; }
            set
            {
                if (_position != value)
                {
                    _position = value;
                }
            }
        }

        /// <summary>
        /// Get or set the start width of the Arc
        /// </summary>
        public int StartWidth
        {
            get { return _startWidth; }
            set
            {
                if (_startWidth != value)
                {
                    _startWidth = value;
                }
            }
        }

        /// <summary>
        /// Get or set the end width of the Arc
        /// </summary>
        public int EndWidth
        {
            get { return _endWidth; }
            set
            {
                if (_endWidth != value)
                {
                    _endWidth = value;
                }
            }
        }

        /// <summary>
        /// Get or set the starting Angle of the arc , measure from x axis
        /// </summary>

        public float StartAngle
        {
            get { return _startGapAngle; }
            set
            {
                if (_startGapAngle != value && _startGapAngle < 360f)
                {

                    _startGapAngle = value;
                   
                }
            }
        }

        /// <summary>
        /// Get or set the sweep Angle of the arc , starting from StartAngle
        /// </summary>
        public float SweepAngle
        {
            get { return _sweepAngle; }
            set
            {
                if (_sweepAngle != value && _sweepAngle < 360f)
                {
                   
                        _sweepAngle = value;
                    
                }
            }
        }

        /// <summary>
        /// Basic contructor of Arc
        /// </summary>
        /// <param name="container">a rectangle wrap object that defines the bound</param>
        public CustomArc(RectangleWrap container)
            : base(container)
        {

        }
        /// <summary>
        /// Generate an arc region
        /// </summary>
        /// <returns>region of arc</returns>
        public override Region RenderRegion()
        {
            return new Region(Render());
        }
        /// <summary>
        /// Generate an arc graphic path 
        /// </summary>
        /// <returns>return graphic path</returns>
        public override GraphicsPath RenderPath()
        {
            return Render();
        }

        private GraphicsPath Render()
        {
            _path = new GraphicsPath();
            RectangleWrap bound = null;
            float diff = 0;
            bool start2End = false;
            PointF[] pt;
            switch (_position)
            {

                case Position.Inner:
                    {
                        if (this.EndWidth > this.StartWidth)
                        {
                            diff = (float)(this.EndWidth - this.StartWidth);
                        }
                        else
                        {
                            diff = (float)(this.StartWidth - this.EndWidth);
                            start2End = true;
                        }
                        pt = new PointF[(int)(_sweepAngle)];
                        diff = diff / (float)(_sweepAngle);
                        bound = new RectangleWrap(
                     new Rectangle(this.Center.X - this.Radius, this.Center.Y - this.Radius,
                                   this.Radius * 2, this.Radius * 2));
                        _path.AddArc(bound.Rect, _startGapAngle, _sweepAngle);
                        _path.Reverse();

                        for (int i = 0; i < pt.Length; i++)
                        {
                            if (start2End)
                            {
                                pt[i] = Helper.AlgorithmHelper.LocationToCenter(
                                                           this.Center, (float)this.Radius - this.StartWidth + (i * diff),
                                                           Helper.AlgorithmHelper.NormalizeDegreeFromX(_startGapAngle + i));
                            }
                            else
                            {
                                pt[i] = Helper.AlgorithmHelper.LocationToCenter(
                                                           this.Center, (float)this.Radius - this.StartWidth - (i * diff),
                                                           Helper.AlgorithmHelper.NormalizeDegreeFromX(_startGapAngle + i));
                            }
                        }
                        if (pt.Length > 1)
                        {
                            _path.AddCurve(pt);
                        }
                        _path.CloseAllFigures();
                    }
                    break;
                case Position.Outer:
                    {
                        if (this.EndWidth > this.StartWidth)
                        {
                            diff = (float)(this.EndWidth - this.StartWidth);
                        }
                        else
                        {
                            diff = (float)(this.StartWidth - this.EndWidth);
                            start2End = true;
                        }
                        pt = new PointF[(int)(_sweepAngle)];
                        diff = diff / (float)(_sweepAngle);
                        bound = new RectangleWrap(
                             new Rectangle(this.Center.X - this.Radius, this.Center.Y - this.Radius,
                             this.Radius * 2, this.Radius * 2));
                        _path.AddArc(bound.Rect, _startGapAngle, _sweepAngle);
                        _path.Reverse();
                        for (int i = 0; i < pt.Length; i++)
                        {
                            if (start2End)
                            {
                                pt[i] = Helper.AlgorithmHelper.LocationToCenter(
                                                           this.Center, (float)this.Radius + this.StartWidth - (i * diff),
                                                           Helper.AlgorithmHelper.NormalizeDegreeFromX(_startGapAngle + i));
                            }
                            else
                            {
                                pt[i] = Helper.AlgorithmHelper.LocationToCenter(
                                                           this.Center, (float)this.Radius + this.StartWidth +  (i * diff),
                                                           Helper.AlgorithmHelper.NormalizeDegreeFromX(_startGapAngle + i));
                            }
                        }
                    }
                    if (pt.Length > 1)
                    {
                        _path.AddCurve(pt);
                    }
                    _path.CloseAllFigures();
                    break;
                case Position.Cross:
                    {
                        if (this.EndWidth /2 > this.StartWidth/2)
                        {
                            diff = (float)(this.EndWidth/2 - this.StartWidth/2);
                        }
                        else
                        {
                            diff = (float)(this.StartWidth/2 - this.EndWidth/2);
                            start2End = true;
                        }
                        pt = new PointF[(int)(_sweepAngle)];
                        diff = diff / (float)(_sweepAngle);
                        for (int i = 0; i < pt.Length; i++)
                        {
                            if (start2End)
                            {
                                pt[i] = Helper.AlgorithmHelper.LocationToCenter(
                                                           this.Center, (float)this.Radius + this.StartWidth / 2 - (i * diff),
                                                           Helper.AlgorithmHelper.NormalizeDegreeFromX(_startGapAngle + i));
                            }
                            else
                            {
                                pt[i] = Helper.AlgorithmHelper.LocationToCenter(
                                                           this.Center, (float)this.Radius + this.StartWidth / 2 + (i * diff),
                                                           Helper.AlgorithmHelper.NormalizeDegreeFromX(_startGapAngle + i));
                            }
                        }
                        if (pt.Length > 1)
                        {
                            _path.AddCurve(pt);
                        }
                        _path.Reverse();
                        pt = new PointF[(int)(_sweepAngle)];
                        for (int i = 0; i < pt.Length; i++)
                        {
                            if (start2End)
                            {
                                pt[i] = Helper.AlgorithmHelper.LocationToCenter(
                                                           this.Center, (float)this.Radius - this.StartWidth / 2 + (i * diff),
                                                           Helper.AlgorithmHelper.NormalizeDegreeFromX(_startGapAngle + i));
                            }
                            else
                            {
                                pt[i] = Helper.AlgorithmHelper.LocationToCenter(
                                                           this.Center, (float)this.Radius - this.StartWidth / 2 - (i * diff),
                                                           Helper.AlgorithmHelper.NormalizeDegreeFromX(_startGapAngle + i));
                            }
                        }
                        if (pt.Length > 1)
                        {
                            _path.AddCurve(pt);
                        }
                        _path.CloseAllFigures();
                    }

                    break;
            }

            return _path;
        }
        
        
    }
}
