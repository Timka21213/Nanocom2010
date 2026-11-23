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
    /// A frame that suppport a numeric display
    /// </summary>
    public class NumericalFrame : Frame
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

        private NumericalIndicator _indicator = null;
        private FrameType _frameType = FrameType.Rectangle;

        /// <summary>
        /// Get the numerical object that will be used for configuration.
        /// </summary>
        public NumericalIndicator Indicator
        {
            get { return _indicator; }
        }

        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="rect">the location and the size of the numeric frame. Position is relative to the parent baseUI</param>
        public NumericalFrame(Rectangle rect)
            :base(new RectangleWrap(rect))
        {
            _indicator = new NumericalIndicator(this);
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
            _indicator.Render(wrapper, e);

            if (this.FrameImage == null)
            {
                this.FrameRenderer.Render(shape, e);
            }
            else
            {
                e.DrawImage(this.FrameImage, this.Bound.Rect, new Rectangle(0, 0, this.FrameImage.Width, this.FrameImage.Height), GraphicsUnit.Pixel);
            }

        }
    }
}
