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
using NextUI.Collection;
using NextUI.Shape;
using NextUI.Component;

namespace NextUI.Frame
{
    /// <summary>
    /// class to implement a circular frame object . User are required to adjust the scale bar 
    /// sweep angle and start angle manually to fit within the frame
    /// </summary>
    public class CircularFrame : Frame
    {
        /// <summary>
        /// The type of frame supported by circular frame
        /// </summary>
        public enum FrameType
        {
            /// <summary>
            /// Render the frame as a circle
            /// </summary>
            Circle, 
            /// <summary>
            /// Render the frame as a semi circle facing upward
            /// </summary>
            HalfCircle1, 
            /// <summary>
            /// Render the frame as a semi circle facing left
            /// </summary>
            HalfCircle2, 
            /// <summary>
            /// Render the frame as a semi circle facing right
            /// </summary>
            HalfCircle3, 
            /// <summary>
            /// Render the frame as a semi circle facing down
            /// </summary>
            HalfCircle4,
            /// <summary>
            /// Render the frame as a quarter circle facing upward left
            /// </summary>
            QuarterCircle1,
            /// <summary>
            /// Render the frame as a quarter circle facing downward left
            /// </summary>
            QuarterCircle2, 
            /// <summary>
            /// Render the frame as a quarter circle facing  upward right
            /// </summary>
            QuarterCircle3, 
            /// <summary>
            /// Render the frame as a quarter circle facing   downward right
            /// </summary>
            QuarterCircle4
        };

        private FrameType _frameType = FrameType.Circle;
        private CircularScaleCollection _scaleCollection;
        private CircularScaleBar _hitbar = null;

        /// <summary>
        /// Get or set the frame to show
        /// </summary>
        public FrameType Type
        {
            get { return _frameType; }
            set
            {
                if (_frameType != value)
                {
                    _frameType = value;
                    this.Invalidate();
                }
            }
        }
        /// <summary>
        /// Get a scale object to add a circlar bar object
        /// </summary>
        public CircularScaleCollection ScaleCollection
        {
            get { return _scaleCollection; }
        }

        /// <summary>
        /// Basic constructor of the circular frame
        /// </summary>
        /// <param name="F">the left , top point at which the circular frame is rendered, relative to baseUI container</param>
        /// <param name="size">the diameter of the circle </param>
        public CircularFrame(Point F, int size)
            : base(new RectangleWrap(new Rectangle(F,new Size(size,size))))
        {
            _scaleCollection = new CircularScaleCollection();
         
        }



        internal override void Render(Graphics e)
        {
            BaseShape shape = null;
            switch (_frameType)
            {
                case FrameType.Circle:
                    shape = new Circle(this.Bound);
                    break;
                case FrameType.HalfCircle1:
                    shape = new HalfCircleCustom1(this.Bound);
                    break;
                case FrameType.HalfCircle2:
                    shape = new HalfCircleCustom2(this.Bound);
                    break;
                case FrameType.HalfCircle3:
                    shape = new HalfCircleCustom3(this.Bound);
                    break;
                case FrameType.HalfCircle4:
                    shape = new HalfCircleCustom4(this.Bound);
                    break;
                case FrameType.QuarterCircle1:
                    shape = new QuarterCustom1(this.Bound);
                    break;
                case FrameType.QuarterCircle2:
                    shape = new QuarterCustom2(this.Bound);
                    break;
                case FrameType.QuarterCircle3:
                    shape = new QuarterCustom3(this.Bound);
                    break;
                case FrameType.QuarterCircle4:
                    shape = new QuarterCustom4(this.Bound);
                    break;
            }
            if (this.BackImage != null)
            {
                GraphicsState state = e.Save();
                e.Clip = shape.RenderRegion();
                e.DrawImage(this.BackImage, this.Bound.Rect, new Rectangle(0, 0, this.BackImage.Width, this.BackImage.Height), GraphicsUnit.Pixel);
                e.Restore(state);
            }
            else
            {
                this.BackRenderer.RenderFill(shape, e);
            }
            //get the width of the frame 
            int frameThickness = (int)(this.FrameRenderer.FrameWidth * 1.5);
            RectangleWrap wrapper = new RectangleWrap(this.Bound.Rect);
            wrapper = wrapper.Shrink(frameThickness);

            foreach (CircularScaleBar bar in this.ScaleCollection)
            {
                bar.Radius = shape.Radius - frameThickness;
                bar.Center = new PointF((float)shape.Center.X,(float) shape.Center.Y);
                bar.RenderScale(wrapper, e);
            }
            foreach (CircularScaleBar bar in this.ScaleCollection)
            {
                bar.RenderMarking(wrapper, e);
            }
            foreach (FrameLabel fl in this.FrameLabelCollection)
            {
                fl.Render(new Point(0,0), e);
            }
            foreach (Frame fr in this.FrameCollection)
            {
                fr.Render(e);
            }
            foreach (CircularScaleBar bar in this.ScaleCollection)
            {
                bar.RenderPointer(wrapper, e);
            }
            if (this.FrameImage == null)
            {
                this.FrameRenderer.Render(shape, e);
            }
            else
            {
                e.DrawImage(this.FrameImage, this.Bound.Rect, new Rectangle(0, 0, this.FrameImage.Width, this.FrameImage.Height), GraphicsUnit.Pixel);
            }

        }

        internal override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            if (_hitbar != null)
            {
                _hitbar.OnMouseUp(e);
                _hitbar = null;
            }
        }

        internal override bool OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            //who ever is the top will get the event first .
            for (int i = this.ScaleCollection.Count-1; i >= 0; i--)
            {
                if (this.ScaleCollection[i].OnMouseDown(e) == true)
                {
                    _hitbar = this.ScaleCollection[i];
                    return true;
                }
            }
            return false;
            
        }

        internal override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            if (_hitbar != null)
            {
                _hitbar.OnMouseMove(e);

            }
        }


    }
}
