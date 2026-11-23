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

namespace NextUI.Component
{
    /// <summary>
    /// a range that is used by horizontal frame
    /// </summary>
    public class LinearRange :RangeBase
    {
        /// <summary>
        /// basic constructor
        /// </summary>
        /// <param name="toplevel">the frame that is the parent of the scale that owns the range</param>
        public LinearRange(Frame.Frame toplevel)
            :base(toplevel)
        {

        }
        internal override void Render(RectangleWrap frame, Graphics e)
        {
            if (this.Visible)
            {
                int widthScale = this.StartWidth;
                if (this.StartWidth < this.EndWidth)
                    widthScale = this.EndWidth;
                RectangleWrap bound = null;
                Shape.CustomTriangle2 shape = null;
                int startIndex = (int)this.Parent.CalculatePosition(this.StartValue);
                int endIndex = (int)this.Parent.CalculatePosition(this.EndValue);
                int indexwidth = endIndex - startIndex;
                int left = startIndex;
                if (startIndex == endIndex)
                    return;
                if (startIndex > endIndex)
                {
                    indexwidth = startIndex - endIndex;
                    left = endIndex;
                }
                switch (this.RangePosition)
                {
                    case Position.Cross:
                        bound = new RectangleWrap(new Rectangle(
                         left,
                        frame.Rect.Top + this.Parent.ScaleBarSize / 2 - widthScale / 2,
                         indexwidth,
                        widthScale));
                        shape = new Shape.CustomTriangle2(bound);
                        shape.EndWidth = this.EndWidth;
                        shape.StartWidth = this.StartWidth;
                        shape.FacingDirection = NextUI.Shape.CustomTriangle2.Direction.Both;
                        break;

                    case Position.Inner:
                        bound = new RectangleWrap(new Rectangle(
                        left,
                        frame.Rect.Top + this.Parent.ScaleBarSize + this.OffsetFromScale,
                        indexwidth,
                        widthScale));
                        shape = new Shape.CustomTriangle2(bound);
                        shape.EndWidth = this.EndWidth;
                        shape.StartWidth = this.StartWidth;
                        shape.FacingDirection = NextUI.Shape.CustomTriangle2.Direction.Downward;
                        break;
                    case Position.Outer:
                        bound = new RectangleWrap(new Rectangle(
                        left,
                        frame.Rect.Top - widthScale - this.OffsetFromScale,
                        indexwidth,
                        widthScale));
                        shape = new Shape.CustomTriangle2(bound);
                        shape.EndWidth = this.EndWidth;
                        shape.StartWidth = this.StartWidth;
                        shape.FacingDirection = NextUI.Shape.CustomTriangle2.Direction.Upward;
                        break;
                }

                this.Shadow.Render(shape, e);
                if (this.EnableGradient)
                {
                    this.Gradient.FillGradientType = NextUI.Renderer.RendererGradient.GradientType.DiagonalLeft;
                    this.Gradient.CenterColor = Color.FromArgb(this.Opaque, this.FillColor);
                    this.Gradient.EndColor = Color.FromArgb(this.Opaque, this.EndColor);
                    this.Gradient.RenderFill(shape, e);
                }
                else
                {
                    e.FillPath(new SolidBrush(Color.FromArgb(this.Opaque, this.FillColor)), shape.RenderPath());
                }
                if (this.EnableBorder)
                {
                    e.DrawPath(new Pen(this.BorderColor, this.BorderWidth), shape.RenderPath());
                }
            }

        }
    }
}
