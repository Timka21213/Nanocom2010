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
    /// A horizontal scalebar that can only be used by horizontal frame
    /// </summary>
    public class HorizontalScaleBar : ScaleBase
    {
        /// <summary>
        /// The event is generated if interact is set to true for the baseUI and when someone click on 
        /// the pointer
        /// </summary>
        /// <param name="sender">the pointer that was click</param>
        /// <param name="value">the value that pointer is pointing to </param>
        public delegate void OnDrag(object sender, float value);
        /// <summary>
        /// To receive drag event whenever a mouse is use to move the pointer
        /// </summary>
        public event OnDrag Drag;
        private LinearRangeCollection _rangeCollection = null;
        private horizontalPointerCollection _pointerCollection = null;
        private float _scaleWidth = 10;
        /// <summary>
        /// a private rectangle warp that is used to calculate the offset of the pointer
        /// relative to the scale bar
        /// </summary>
        private RectangleWrap _bound = null;
        private HorizontalPointer _hitPointer = null;

        /// <summary>
        /// Get the pointer collection to add or remove new pointer
        /// </summary>
        public horizontalPointerCollection Pointer
        {
            get { return _pointerCollection; }
        }

        /// <summary>
        /// Get the collection object to add a Range.
        /// </summary>
        public LinearRangeCollection Range
        {
            get { return _rangeCollection; }
        }

        /// <summary>
        /// Get the label object to configure the tick label.
        /// </summary>
        public HorizontalScaleLabel TickLabel
        {
            get { return (HorizontalScaleLabel)this.BaseLabel; }
        }
      
        /// <summary>
        /// basic constructor
        /// </summary>
        /// <param name="toplevel">the frame that own this scale bar</param>

        public HorizontalScaleBar(Frame.Frame toplevel)
            :base(toplevel)
        {
            this.BaseLabel = new HorizontalScaleLabel(this,toplevel);
            _rangeCollection = new LinearRangeCollection();
            _rangeCollection.Insert += new OnInsert(_rangeCollection_Insert);
            _pointerCollection = new horizontalPointerCollection();
            _pointerCollection.Insert += new OnInsert(_pointerCollection_Insert);

        }

        void _pointerCollection_Insert(object sender, int index)
        {
            HorizontalPointer pointer =  (HorizontalPointer)(sender);
            pointer.Parent = this;
        }

        void _rangeCollection_Insert(object sender, int index)
        {
            LinearRange range =  (LinearRange)(sender);
            range.Parent = this;
        }


        internal override void RenderScale(RectangleWrap Bound, Graphics e)
        {

            int x = (int)(Bound.Left + Bound.Width / 2 - Bound.Width * 0.9 / 2);
            int y = Bound.Top + this.OffsetFromFrame;
            int height = this.ScaleBarSize;
            int width = (int)(Bound.Width * 0.9);
            if (width <= 0)
                width = Global.SIZE;
            _scaleWidth = width;
            Shape.SRectangle shape = new SRectangle(new RectangleWrap(new Rectangle(x, y, width, height)));
            _bound = new RectangleWrap(new Rectangle(x, y, width , height));
            if (this.Visible)
            {
                this.Shadow.Render(shape, e);
                this.Gradient.FillGradientType = this.FillGradientType;
                this.Gradient.CenterColor = this.FillColor;
                this.Gradient.EndColor = this.EndColor;
                this.Gradient.RenderFill(shape, e);
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
                    e.DrawPath(_pen, shape.RenderPath());
                }
            }

            foreach (Component.LinearRange range in _rangeCollection)
            {
                range.Render(shape.Bound, e);
            }
        }

        internal override void RenderMarking(RectangleWrap Bound, Graphics e)
        {
            int x = (int)(Bound.Left + Bound.Width / 2 - Bound.Width * 0.9 / 2);
            int y = Bound.Top + this.OffsetFromFrame;
            int height = this.ScaleBarSize;
            int width = (int)(Bound.Width * 0.9);
            if (width <= 0)
                width = Global.SIZE;
            float majorDistance = 0;
            float minorDistance = 0;
            int renderWidth = width ;
            if (renderWidth <= 1)
            {
                renderWidth = Global.SIZE;
            }
           // _bound = new RectangleWrap(new Rectangle(x, y, width - 1 * _majorTick.Width, height));
            if (this.MajorTickNumber > 0)
            {
                float diff = 0;
                if (this.MajorTickNumber > 1)
                {
                    majorDistance = (float)renderWidth / (this.MajorTickNumber - 1);
                    diff = (this.EndValue - this.StartValue) / (this.MajorTickNumber - 1);
                }
                else
                {
                    diff = 0;
                    majorDistance = renderWidth;
                }
                //minorDistance = majorDistance / (_minorTickNumber + 1);

                GraphicsState state = e.Save();
                Matrix m = new Matrix();
                for (int i = 0; i < this.MajorTickNumber; i++)
                {
                    this.TickMajor.Render(new Point(x, y), e);
                    this.TickLabel.NoAutoRefresh = true;
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
                            this.TickLabel.Text = Convert.ToString(this.StartValue + (i * diff));
                        }
                    }
                    this.TickLabel.Render(new Point(x, y), e);
                    m.Translate(majorDistance, 0);
                    e.Transform = m;
                    this.TickLabel.NoAutoRefresh = false;

                }
                e.Restore(state);
            }
            if (this.MinorTicknumber > 0)
            {
                minorDistance = majorDistance / (this.MinorTicknumber + 1);
                GraphicsState state = e.Save();
                Matrix m = new Matrix();
                for (int i = 1; i < this.MajorTickNumber; i++)
                {
                    m.Translate((i - 1) * majorDistance, 0);
                    for (int j = 0; j < this.MinorTicknumber; j++)
                    {
                        m.Translate(minorDistance, 0);
                        e.Transform = m;
                        this.TickMinor.Render(new Point(x, y), e);
                    }
                    m.Reset();
                }
                e.Restore(state);

            }
        }




        internal override void  RenderPointer(RectangleWrap Bound, Graphics e)
        {
            int x = (int)(Bound.Left + Bound.Width / 2 - Bound.Width * 0.9 / 2);
            int y = Bound.Top + this.OffsetFromFrame;
            int height = this.ScaleBarSize;
            int width = (int)(Bound.Width * 0.9);
            if (width <= 0)
                width = Global.SIZE;
            foreach (Component.HorizontalPointer pointer in _pointerCollection)
            {
                pointer.Render(new Point(x, y), e);
            }
        }

        internal override float CalculateValue(float position)
        {
            if (position <= _bound.Left)
            {
                return this.StartValue;
            }
            if (position >= _bound.Left + _bound.Width)
            {
                return this.EndValue;
            }
            float diff = Math.Abs(this.StartValue - this.EndValue) / _bound.Width;
            float normalised = position - _bound.Left;
            return normalised * diff;

        }

        internal override float CalculatePosition(float label)
        {
            float index = 0;
            if ( _bound != null)
            {
                bool big2small = false;
                if (this.StartValue == this.EndValue)
                    return _bound.Left + this.TickMajor.Width;

                if (this.StartValue > this.EndValue)
                {
                    big2small = true;
                }
                
                //calculate the relative position 
                float diff = 0;
                if (big2small)
                {
                    if (label >= this.StartValue)
                    {
                        return _bound.Left;
                    }
                    if (label <= this.EndValue)
                    {
                        return _bound.Left + _bound.Width;
                    }
                    diff = _bound.Width / (this.StartValue - this.EndValue);
                    float normalized = label - this.EndValue;
                    index = (this.StartValue - this.EndValue - normalized) * diff + _bound.Left + this.TickMajor.Width;
                }
                else
                {
                    if (label <= this.StartValue)
                    {
                        return _bound.Left;
                    }
                    if (label >= this.EndValue)
                    {
                        return _bound.Left + _bound.Width;
                    }
                    diff = _bound.Width / (this.EndValue - this.StartValue);
                    float normalized = label - this.StartValue;
                    index = diff * normalized + _bound.Left + this.TickMajor.Width;
                }
            }
        //    Console.WriteLine("label = " + label + "  index = " + index);
            return index;
        }

        internal override bool OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            for (int i = Pointer.Count - 1; i >= 0; i--)
            {
                if (this.Pointer[i].BasePointer.HitTest(e.Location) == true)
                {
                    _hitPointer = this.Pointer[i];
                    return true;
                }
            }

            return false;
        }

        internal override bool OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            if (_hitPointer != null)
            {
                _hitPointer.Value = CalculateValue(e.X);
                if (Drag != null)
                {
                    Drag(_hitPointer, _hitPointer.Value);
                }
            }
            return true;
        }

        internal override bool OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            _hitPointer = null;
            return true;
        }
    }
    
}
