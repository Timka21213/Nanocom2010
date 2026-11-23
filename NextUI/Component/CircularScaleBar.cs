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
using NextUI.Helper;
using NextUI.Collection;


namespace NextUI.Component
{
    /// <summary>
    /// The baseclass that render a scale bar, Scale bar is basically where 
    /// Mark is being rendered . It can be made invisible
    /// </summary>
    public class CircularScaleBar : ScaleBase
    {
        /// <summary>
        /// The event is generated if interact is set to true for the baseUI and when someone click on 
        /// the pointer
        /// </summary>
        /// <param name="sender">the pointer that was click</param>
        /// <param name="value">the value that pointer is pointing to </param>
        public delegate void OnRotate(object sender, float value);
        /// <summary>
        /// To receive rotate event whenever a mouse is use to move the knob
        /// </summary>
        public event OnRotate Rotate;
        private float _startGapAngle = 35;
        private float _sweepAngle = 30;

        private PointF _center = new PointF(0,0);
        private int _radius = 10;
        private CircularPointerCollection _pointer = null;
        private CircularRangeBaseCollection _range = null;
        private CircularMarkerCollection _marker = null;
        private CircularPointer _hitPointer = null;
        
        /// <summary>
        /// Get or set the radius of the bar to the center
        /// </summary>
        internal int Radius
        {
            get { return _radius; }
            set
            {
                if (_radius != value)
                {
                    _radius = value;
                    if ( ! this.NoAutoRefresh)
                    this.TopLevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the center of the circular scale bar.
        /// </summary>
        internal PointF Center
        {
            get { return _center; }
            set
            {
                if (_center != null && _center != value)
                {
                    _center = value;
                    if (!this.NoAutoRefresh)
                    this.TopLevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get the collection object to add a marker.
        /// </summary>
        public CircularMarkerCollection Marker
        {
            get { return _marker; }
        }

        /// <summary>
        /// Get the collection object to add a pointer.
        /// </summary>
        public CircularPointerCollection Pointer
        {
            get { return _pointer; }
        }

        /// <summary>
        /// Get the collection object to add a range.
        /// </summary>
        public CircularRangeBaseCollection Range
        {
            get { return _range; }
        }

        /// <summary>
        /// Get the label object to configure the tick label.
        /// </summary>
        public CircularLabel TickLabel
        {
            get { return (CircularLabel)this.BaseLabel; }
        }
       

        /// <summary>
        /// Starting Angle of the Scale Bar , measure from x axis
        /// </summary>

        public float StartAngle
        {
            get { return _startGapAngle; }
            set
            {
                if (_startGapAngle != value && value < 360f)
                {
                    _startGapAngle = value;
                    this.TopLevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// The sweep Angle of the scale bar , starting from StartAngle
        /// </summary>
        public float SweepAngle
        {
            get { return _sweepAngle; }
            set
            {
                if (_sweepAngle != value && value < 360f)
                {
                    _sweepAngle = value;
                    this.TopLevel.Invalidate();

                }
            }
        }

        /// <summary>
        /// basic constructor
        /// </summary>
        /// <param name="toplevel">the frame that owns the scale bar</param>
        public CircularScaleBar(Frame.Frame toplevel)
            :base(toplevel)
            
        {
            this.BaseLabel = new CircularLabel(this,toplevel);
            _pointer = new CircularPointerCollection();
            _pointer.Insert += new OnInsert(_pointer_Insert);
            _range = new CircularRangeBaseCollection();
            _range.Insert += new OnInsert(_range_Insert);
            _marker = new CircularMarkerCollection();
            _marker.Insert += new OnInsert(_marker_Insert);
        }

        

        void _marker_Insert(object sender, int index)
        {
            Component.CircularMarker marker = (Component.CircularMarker)sender;
            marker.Parent = this;
            marker.Center = this._center;
        }

        void _range_Insert(object sender, int index)
        {
            Component.CircularRange range = (Component.CircularRange)sender;
            range.Parent = this;
        }

        void _pointer_Insert(object sender, int index)
        {
            Component.CircularPointer pointer = (Component.CircularPointer)sender;
            pointer.Parent = this;
        }
 


        internal override void RenderScale(RectangleWrap frameBound, Graphics e)
        {

            RectangleWrap Bound = frameBound.Shrink(this.OffsetFromFrame);
            CustomCircleRing ring = new CustomCircleRing(Bound);
            ring.ScaleBarSize = this.ScaleBarSize;
            ring.StartAngle = this.StartAngle;
            ring.SweepAngle = this.SweepAngle;
            this._center = ring.Center;
            if (this.Visible)
            {
                this.Shadow.Render(ring, e);
                this.Gradient.FillGradientType = this.FillGradientType;
                this.Gradient.CenterColor = this.FillColor;
                this.Gradient.EndColor = this.EndColor;
                this.Gradient.RenderFill(ring, e);
                Pen _pen = new Pen(this.BorderColor);

                if (this.BorderStyle != Style.NotSet)
                {
                    switch (this.BorderStyle)
                    {
                        case Style.Dash:
                            _pen.DashStyle = DashStyle.Dash;
                            break;
                        case Style.DashDot:
                            _pen.DashStyle = DashStyle.DashDot;
                            break;
                        case Style.DashDotDot:
                            _pen.DashStyle = DashStyle.DashDotDot;
                            break;
                        case Style.Dot:
                            _pen.DashStyle = DashStyle.Dot;
                            break;
                        case Style.Solid:
                            _pen.DashStyle = DashStyle.Solid;
                            break;
                        default:
                            break;
                    }
                    e.DrawPath(_pen, ring.RenderPath());
                }
            }
          
            foreach (Component.CircularRange range in _range)
            {
                range.Render(Bound, e);
            }

        }


        internal override void RenderMarking(RectangleWrap frameBound, Graphics e)
        {
            RectangleWrap Bound = frameBound.Shrink(this.OffsetFromFrame);
            /*Draw the tick*/
            /*First we calculate the range of the angle and then devide by _majorTickNumber*/
            Matrix m = new Matrix();
            float majorInterval = 0;
            float minorInterval = 0;
            float rotateAngle = 0;
            float startAngle = 0;
            startAngle = _sweepAngle + _startGapAngle;
            startAngle = Helper.AlgorithmHelper.NormalizeDegree(-90f, startAngle);
            if (this.MajorTickNumber > 0)
            {
                float diff = 0;
                if (this.MajorTickNumber > 1)
                {
                    if (_sweepAngle > 0)
                    {
                        majorInterval = (360f - _sweepAngle) / (this.MajorTickNumber - 1);
                        diff = (this.EndValue - this.StartValue) / (this.MajorTickNumber - 1);
                    }
                    else
                    {
                        majorInterval = 360f  / this.MajorTickNumber ;
                        diff = (this.EndValue - this.StartValue) / this.MajorTickNumber ;
                    }
                }
                else
                {
                    majorInterval = (360 - _sweepAngle) / this.MajorTickNumber;
                    diff = 0;
                }
                rotateAngle = startAngle;
                GraphicsState state = e.Save();
                for (int i = 0; i < this.MajorTickNumber; i++)
                {
                    m.RotateAt(rotateAngle, _center);
                    e.Transform = m;
                    this.TickMajor.Render(new Point(Bound.Left + Bound.Width / 2 ,
                                                Bound.Top), e);
                    rotateAngle = majorInterval;
                }
                e.Restore(state);
     
                for (int i = 0; i < this.MajorTickNumber; i++)
                {
                    //label always accept angle with reference to x , clockwise
                    this.TickLabel.NoAutoRefresh = true;
                    this.TickLabel.Center = _center;
                    if (this.CustomLabel != null && this.CustomLabel.Length > i)
                    {
                        this.TickLabel.Text = this.CustomLabel[i];
                    }
                    else
                    {
                        if (this.CastLabelToInteger)
                        {
                            this.TickLabel.Text = Convert.ToString((int)(this.StartValue + (i * diff)));
                        }
                        else
                        {
                            this.TickLabel.Text = Convert.ToString((this.StartValue + (i * diff)));
                        }
                    }
                    //we do not need to adjust the major tick width as label will adjust itself
                    this.TickLabel.Render(new Point(Bound.Left + Bound.Width / 2,
                                            Bound.Top), e, _sweepAngle + _startGapAngle + i * majorInterval);
                    this.TickLabel.NoAutoRefresh = false;
                }
            }
            if (this.MinorTicknumber > 0)
            {
                m.Reset();
                rotateAngle = startAngle ;
                minorInterval = majorInterval / (this.MinorTicknumber + 1);
                GraphicsState state = e.Save();
                int majortick = this.MajorTickNumber;
                if (this.SweepAngle == 0)
                {
                    majortick += 1;
                }
         
                for (int i = 1; i < majortick; i++)
                {
                    m.RotateAt(rotateAngle + (i-1)*majorInterval, _center);
                    for (int k = 0; k < this.MinorTicknumber; k++)
                    {
                        m.RotateAt(minorInterval, _center);
                        e.Transform = m;
                        this.TickMinor.Render(new Point(Bound.Left + Bound.Width / 2 ,
                                                    Bound.Top), e);
                    }
                    m.Reset();
                }
                e.Restore(state);

            }

        }

        internal override void RenderPointer(RectangleWrap frameBound, Graphics e)
        {
            RectangleWrap Bound = frameBound.Shrink(this.OffsetFromFrame);
            foreach (Component.CircularMarker marker in _marker)
            {
                marker.Center = this._center;
                marker.Render(new Point(Bound.Left + Bound.Width / 2,
                                        Bound.Top), e);
            }
           
            foreach (Component.CircularPointer pointer in _pointer)
            {
                pointer.Render(new Point((int)_center.X, (int)_center.Y), e);
            }
        }

        /// <summary>
        /// return thr value based on angle
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        internal override float CalculateValue(float position)
        {
            bool big2small = false;
           // bool clockwise = true;
            //float moveAngle = position - _previousAngle;
            if (this.StartValue > this.EndValue)
                big2small = true;
    
            
            float startangle = AlgorithmHelper.NormalizeDegree(-90f, this.StartAngle + this.SweepAngle);
            float normalizedAngle = AlgorithmHelper.AngleDifferentClockWise(startangle, position);
            float diff = 0;
            float val = 0;
            if (big2small)
            {
                diff = (this.StartValue - this.EndValue) / (360 - this.SweepAngle);
                val = this.StartValue - normalizedAngle * diff;
                if (val > this.StartValue)
                    val = this.StartValue;
                else if (val < this.EndValue)
                    val = this.EndValue;
            }
            else
            {
                diff = (this.EndValue - this.StartValue) / (360 - this.SweepAngle);
                val = normalizedAngle * diff + this.StartValue ;
                if (val < this.StartValue)
                    val = this.StartValue;
                else if (val > this.EndValue)
                    val = this.EndValue;
            }

            return val;
            
        }

        /// <summary>
        /// Given the current value , return the angle with respect to positive y axis
        /// </summary>
        /// <param name="label"></param>
        /// <returns></returns>
    
        internal override float CalculatePosition(float label)
        {
            float index = 0;
            bool big2small = false;
            if (this.StartValue == this.EndValue)
            {
                index =  this.StartAngle + this.SweepAngle;
                goto gotoreturn;
            }

            if (this.StartValue > this.EndValue)
            {
                big2small = true;
            }
            float diff = 0;
            if (big2small)
            {
                if (label >= this.StartValue)
                {
                    index =  (this.StartAngle + this.SweepAngle);
                    goto gotoreturn;
                }
                if (label <= this.EndValue)
                {
                    index =  this.StartAngle;
                    goto gotoreturn;
                }
                diff = (360 - this.SweepAngle) / (this.StartValue - this.EndValue);
                float normalized = label - this.EndValue;
                index = (this.StartValue - this.EndValue - normalized) * diff + this.StartAngle + this.SweepAngle;
            }
            else
            {
                if (label <= this.StartValue)
                {
                    index =  this.StartAngle + this.SweepAngle;
                    goto gotoreturn;
                }
                if (label >= this.EndValue)
                {
                    index =  this.StartAngle;
                    goto gotoreturn;
                }
                diff = (360 - this.SweepAngle) / (this.EndValue - this.StartValue);
                float normalized = label - this.StartValue;
                index = diff * normalized + this.StartAngle + this.SweepAngle;
            }
            gotoreturn:
            return Helper.AlgorithmHelper.NormalizeDegree(270f, index);
        }

        internal override bool OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            if (_hitPointer != null)
            {
                _hitPointer = null;
            }
            return true;
        }

        internal override bool OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            if (_hitPointer != null)
            {
                float angle = AlgorithmHelper.PointToCenterAngle(this.Center, e.Location);
                angle = AlgorithmHelper.NormalizeDegree(-90, angle);
                _hitPointer.Value =  CalculateValue(angle);
                if (Rotate != null)
                {
                    Rotate(_hitPointer, _hitPointer.Value);
                }
             //   _previousAngle = angle;
                
            }
            return true;
        }

        internal override bool OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            bool status = false;
            //we check from the top most to the bottom most
            float angle = AlgorithmHelper.PointToCenterAngle(this.Center, e.Location);
            float radius = (float)(Math.Sqrt(Math.Pow(this.Center.X - e.X,2) + Math.Pow(this.Center.Y - e.Y,2)));
            //convert angle by djust it to + y 
            angle = AlgorithmHelper.NormalizeDegree(-90f, angle);
            for (int i = this.Pointer.Count - 1; i >= 0; i--)
            {
                if (this.Pointer[i].BasePointer.Length + this.Pointer[i].BasePointer.OffsetFromCenter >= radius &&
                     this.Pointer[i].Angle <= angle + this.Pointer[i].BasePointer.Width &&
                     this.Pointer[i].Angle >= angle - this.Pointer[i].BasePointer.Width) 
                {
                    _hitPointer =  this.Pointer[i];
           //         _previousAngle = angle;
                    status = true;
                    goto gotoreturn;
                    
                }
                else if ( AlgorithmHelper.IsPointInCircle(this.Center,this.Pointer[i].CapPointer.Diameter/2,
                                                     e.Location,0))
                {
                    _hitPointer = this.Pointer[i];
         //           _previousAngle = angle;
                    status =true ;
                    goto gotoreturn;
                }

            }
            gotoreturn:
                return status;

        }

    }
}