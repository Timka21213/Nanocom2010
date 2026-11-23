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

namespace NextUI.Component
{
    /// <summary>
    /// a horizontal scale label that can only be used by horizontal frame
    /// </summary>
    public class HorizontalScaleLabel : ScaleLabel
    {
        internal HorizontalScaleLabel(ScaleBase parent,Frame.Frame toplevel)
            :base(parent,toplevel)
        {
        }
        internal override void Render(System.Drawing.Point p, System.Drawing.Graphics e)
        {
            if (this.Visible)
            {
                Point textPoint = new Point(0, 0);
                Size proposedSize = new Size(int.MaxValue, int.MaxValue);
                Size z = TextRenderer.MeasureText(this.Text, this.LabelFont, proposedSize, TextFormatFlags.HorizontalCenter);
                GraphicsState state = e.Save();
                switch (this.LabelPostion)
                {
                    case Position.Cross:
                        textPoint = new Point(p.X - z.Width / 2, p.Y + this.Parent.ScaleBarSize / 2 - (int)(z.Height / 2));
                        break;
                    case Position.Inner:
                        textPoint = new Point(p.X - z.Width / 2, p.Y + this.Parent.ScaleBarSize + this.OffsetFromScale);
                        break;
                    case Position.Outer:
                        textPoint = new Point(p.X - z.Width / 2, p.Y - this.OffsetFromScale - (int)z.Height);
                        break;
                }
                Matrix m = e.Transform;
                m.RotateAt(this.Angle, new PointF(textPoint.X + z.Width / 2, textPoint.Y + z.Height / 2));
                e.Transform = m;

                GraphicsPath path = new GraphicsPath();
                path.AddString(this.Text, this.LabelFont.FontFamily, (int)this.LabelFont.Style, this.LabelFont.Size, textPoint, StringFormat.GenericDefault);
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
