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
    /// The circular range that is only supported by circular frame
    /// </summary>
    public class CircularRange : RangeBase
    {
        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="toplevel">the frame that owns the range</param>
        public CircularRange(Frame.Frame toplevel)
            : base(toplevel)
        {

        }

        internal override void Render(RectangleWrap frame, Graphics e)
        {
            //Get the center of the RectangleWrap .
            //The bound of the ring depends on the center and the radius.
            if (this.Visible)
            {    
                RectangleWrap bound = null;
                Shape.CustomArc shape = null;
                switch ( this.RangePosition)
                {
                    case Position.Cross:
                        bound = new RectangleWrap(new Rectangle(
                        frame.Rect.Left + this.Parent.ScaleBarSize / 2,
                        frame.Rect.Top + this.Parent.ScaleBarSize / 2 ,
                        frame.Rect.Width - this.Parent.ScaleBarSize ,
                        frame.Rect.Height - this.Parent.ScaleBarSize ));
                        shape = new Shape.CustomArc(bound);
                        shape.Direction = NextUI.Shape.CustomArc.Position.Cross;
                        break;
                        
                    case Position.Inner:
                        bound =  frame.Shrink(this.OffsetFromScale + this.Parent.ScaleBarSize);
                        shape = new Shape.CustomArc(bound);
                        shape.Direction = NextUI.Shape.CustomArc.Position.Inner;
                        break;
                    case Position.Outer:
                        bound = frame.Expand(this.OffsetFromScale);
                        shape = new Shape.CustomArc(bound);
                        shape.Direction = NextUI.Shape.CustomArc.Position.Outer;
                        break;
                }
                 
                float startLabel = this.Parent.CalculatePosition(StartValue);
                float endLabel = this.Parent.CalculatePosition(EndValue);
                startLabel = Helper.AlgorithmHelper.NormalizeDegree(90, startLabel);
                endLabel = Helper.AlgorithmHelper.NormalizeDegree(90, endLabel);
                shape.EndWidth = this.EndWidth;
                shape.StartWidth = this.StartWidth;
                if (startLabel == endLabel)
                {
                    shape.StartAngle = Helper.AlgorithmHelper.NormalizeDegree(90, endLabel);
                    shape.SweepAngle = 1;
                }
                else
                {
                    if (this.Parent.StartValue > this.Parent.EndValue)
                    {
                        //now startvalue > endvalue 
                        shape.StartAngle = endLabel;
                        shape.SweepAngle = Helper.AlgorithmHelper.AngleDifferentClockWise(endLabel, startLabel);
                    }
                    else
                    {
                        shape.StartAngle = startLabel;
                        shape.SweepAngle = Helper.AlgorithmHelper.AngleDifferentClockWise(startLabel, endLabel);
                    }

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
                if ( this.EnableBorder)
                {
                    e.DrawPath(new Pen(this.BorderColor,this.BorderWidth),shape.RenderPath());
                }
    
            }
            
        }
    }
}
