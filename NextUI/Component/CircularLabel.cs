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
using System.Text;
using System.Windows.Forms;
using NextUI.Common;
using NextUI.Shape;
using NextUI.Helper;

namespace NextUI.Component
{
    /// <summary>
    /// a class that implement a label that is only used by circular frame
    /// </summary>
    public class CircularLabel : ScaleLabel
    {
        /// <summary>
        /// enumaration that set the way the label is displayed
        /// </summary>
        public enum Direction { 
            /// <summary>
            /// the label shall be displayed around the scale bar 
            /// </summary>
            Normal, 
            /// <summary>
            /// the label shall be displayed around the scale bar but displayed the text horizontally
            /// </summary>
            Horizontal };
        private PointF _center = new PointF(0, 0);
        private Direction _direction = Direction.Normal;
        
        /// <summary>
        /// Get or set the TextDirection of the font .
        /// Horizontal will always keep the text in horizontal position
        /// Normal will let the system handle the direction.
        /// </summary>
        public Direction TextDirection
        {
            get { return _direction; }
            set
            {
                if (_direction != value)
                {
                    _direction = value;
                    if (!this.NoAutoRefresh)
                    this.TopLevel.Invalidate();
                    
                }
            }
        }

        /// <summary>
        /// Get or set the center for the label to be render around
        /// </summary>
        internal PointF Center
        {
            get { return _center; }
            set
            {
                if (_center != value)
                {
                    _center = value;
                    if (!this.NoAutoRefresh)
                    this.TopLevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// basic constructor
        /// </summary>
        /// <param name="parent">the scale bar that owns the label</param>
        /// <param name="toplevel">the frame that owns the scale bar which owns the label</param>
        internal CircularLabel( ScaleBase parent, Frame.Frame toplevel)
            :base(parent,toplevel)
        {
         
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="e"></param>
        /// <param name="angle">Angle is always measured from positive x axis</param>
        internal  void Render(Point p, Graphics e, float angle)
        {
            if (this.Visible)
            {
                GraphicsState state = e.Save();
                PointF textPoint = new PointF(0, 0);
                Size proposedSize = new Size(int.MaxValue, int.MaxValue);
                Size z = TextRenderer.MeasureText(this.Text, this.LabelFont, proposedSize, TextFormatFlags.NoPadding);
                if (_direction == Direction.Horizontal)
                {
                    // when all text displayed in horizontal
                    //we need to adjust the center so all text will be displayed in a perfect circle
                    PointF center = new PointF(_center.X - z.Width/3, _center.Y - z.Height/2);
                    float radius = 0;
                    switch (this.LabelPostion)
                    {
                        case Position.Cross:
                            radius = center.Y - p.Y - this.Parent.ScaleBarSize / 2 + +z.Height/2;
                            break;
                        case Position.Inner:
                            radius = center.Y - p.Y - this.Parent.ScaleBarSize - this.OffsetFromScale + +z.Height/2;
                            break;
                        case Position.Outer:
                            radius = center.Y - p.Y + this.OffsetFromScale + z.Height/2;
                            break;
                    }
                    textPoint = Helper.AlgorithmHelper.LocationToCenter(center, (float)radius, angle);
                   //  textPoint.X = textPoint.X - z.Width / 2;
                    // textPoint.Y = textPoint.Y - z.Height / 2;
         //           e.FillRectangle(new SolidBrush(Color.White), textPoint.X, textPoint.Y, 10, 10);
                }
                else
                {
                    switch (this.LabelPostion)
                    {
                        case Position.Cross:
                            textPoint = new Point(p.X , p.Y + this.Parent.ScaleBarSize /2 );
                            break;
                        case Position.Inner:
                            textPoint = new Point(p.X , p.Y + this.Parent.ScaleBarSize + this.OffsetFromScale);
                            break;
                        case Position.Outer:
                            textPoint = new Point(p.X , p.Y - this.OffsetFromScale);
                            break;
                    }
                    Matrix m = new Matrix();
                    m.RotateAt(90 + angle, _center);
                    e.Transform = m;
                }
                Matrix ma = e.Transform;
                ma.RotateAt(this.Angle, new PointF(textPoint.X, textPoint.Y));
                e.Transform = ma;

                GraphicsPath path = new GraphicsPath();
               if (_direction == Direction.Normal)
                {
                    path.AddString(this.Text, this.LabelFont.FontFamily, (int)this.LabelFont.Style, this.LabelFont.Size * 1.33f, new PointF(textPoint.X - z.Width / 2, textPoint.Y - z.Height / 2), StringFormat.GenericTypographic);
                }
                else
                {
                    path.AddString(this.Text, this.LabelFont.FontFamily, (int)this.LabelFont.Style, this.LabelFont.Size * 1.33f, new PointF(textPoint.X, textPoint.Y), StringFormat.GenericTypographic);
                }
                Brush br;
                this.Shadow.RenderFillPath(path, e);
                if (this.EnableGradient)
                {
                    br = new LinearGradientBrush(new Rectangle(p.X, p.Y, (int)this.LabelFont.Size, (int)this.LabelFont.Size), this.FontColor, this.EndColor, 0f);
                }
                else
                {
                    br = new SolidBrush(this.FontColor);
                }
                e.FillPath(br, path);

                if (this.EnableBorder)
                {
                    e.DrawPath(new Pen(this.BorderColor, this.BorderWidth), path);
                }
                e.Restore(state);
            }

        }
    }
}
