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
    /// Provide class to support a horizontal frame 
    /// </summary>
    public class HorizontalFrame : Frame
    {
        /// <summary>
        /// The type of frame supported by circular frame
        /// </summary>
        public enum FrameType
        {
            /// <summary>
            /// Render the frame as rectangle
            /// </summary>
            Rectangle,
            /// <summary>
            /// Render the frame as rounded rectangle
            /// </summary>
            RoundedRectangle
        };

        private HorizontalScaleCollection _indicator = null;
        private FrameType _frameType = FrameType.Rectangle;
        private HorizontalScaleBar _hitbar = null;

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
        /// Get the horizontal scale collection object to manipulate the horozontal scale
        /// </summary>
        public HorizontalScaleCollection ScaleCollection
        {
            get { return _indicator; }
        }

        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="rect">the location and the size of the frame. Position is relative to the parent baseUI</param>
        public HorizontalFrame(Rectangle rect) :
            base(new RectangleWrap(rect))
        {
            _indicator = new HorizontalScaleCollection();
        }


        internal override void Render(Graphics e)
        {
            BaseShape shape = null;
            switch (_frameType)
            {
                case FrameType.Rectangle:
                    shape = new Shape.SRectangle(this.Bound);
                    break;
                case FrameType.RoundedRectangle:
                    shape = new Shape.RoundedRectangle(this.Bound);
                    break;
                default:
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
            foreach (HorizontalScaleBar bar in this.ScaleCollection)
            {
                bar.RenderScale(wrapper, e);
            }
            foreach (HorizontalScaleBar bar in this.ScaleCollection)
            {
                bar.RenderMarking(wrapper, e);
            }
            foreach (FrameLabel fl in this.FrameLabelCollection)
            {
                fl.Render(new Point(0, 0), e);
            }
            foreach (Frame fr in this.FrameCollection)
            {
                fr.Render(e);
            }
            foreach (HorizontalScaleBar bar in this.ScaleCollection)
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

        internal override bool OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            for (int i = _indicator.Count - 1; i >= 0; i--)
            {
                if (_indicator[i].OnMouseDown(e) == true)
                {
                    _hitbar = _indicator[i];
                    return true;
                }
            }
            return false;
        }

        internal override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            if ( _hitbar != null)
            {
                _hitbar.OnMouseMove(e);
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
    }
}
