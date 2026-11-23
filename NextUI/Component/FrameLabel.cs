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
using NextUI.Frame;

namespace NextUI.Component
{
    /// <summary>
    /// a class that implement the frame label
    /// </summary>
    public class FrameLabel : NextUI.Component.Label
    {
        private Point _p = new Point(0,0);
        private Image _image = null; // the image to display
        private string _text = "";

        /// <summary>
        /// Get or set the text to be displayed
        /// </summary>
        public string LabelText
        {
            get { return _text; }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    this.TopLevel.Invalidate();
                }
            }
        }
        

        /// <summary>
        /// Get or set the image to be displayed , no image will be displayed if set to null
        /// </summary>
        public Image BackGrdImage
        {
            get { return _image; }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    this.TopLevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the point relative to the frame owner 
        /// </summary>
        public Point Location
        {
            get { return _p; }
            set
            {
                if (_p != value)
                {
                    _p = value;
                    this.TopLevel.Invalidate();
                }
            }
        }
        
        /// <summary>
        /// basic constructor
        /// </summary>
        /// <param name="p">the point to render the label , relative to the parent frame</param>
        /// <param name="toplevel">the frame that owns the label</param>
        public FrameLabel(Point p,Frame.Frame toplevel)
            : base(toplevel)
        {
            _p = p;
        }

        internal override void Render(Point notused , Graphics e)
        {
            if (this.Visible)
            {
                Point textPoint = new Point(this.TopLevel.Rect.Left + _p.X, this.TopLevel.Rect.Top + _p.Y);
                GraphicsState state = e.Save();
                Matrix m = e.Transform;
                if (this.BackGrdImage == null)
                {
                    Size proposedSize = new Size(int.MaxValue, int.MaxValue);
                    Size z = TextRenderer.MeasureText(this.LabelText, this.LabelFont, proposedSize, TextFormatFlags.HorizontalCenter);
                    m.RotateAt(this.Angle, new PointF(textPoint.X + z.Width / 2, textPoint.Y + z.Height / 2));
                    e.Transform = m;

                    GraphicsPath path = new GraphicsPath();
                    path.AddString(this.LabelText, this.LabelFont.FontFamily, (int)this.LabelFont.Style, this.LabelFont.Size, textPoint, StringFormat.GenericDefault);
                    Brush br;
                    this.Shadow.RenderFillPath(path, e);
                    if (this.EnableGradient)
                    {
                        br = new LinearGradientBrush(new Rectangle(textPoint.X, textPoint.Y, (int)this.LabelFont.Size, (int)this.LabelFont.Size), this.FontColor, this.EndColor, 0f);
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
                else
                {
                    Rectangle location = new Rectangle(textPoint, new Size(this.BackGrdImage.Width, this.BackGrdImage.Height));
                    GraphicsPath path = new GraphicsPath();
                    m.RotateAt(this.Angle, new PointF(textPoint.X + this.BackGrdImage.Width / 2, textPoint.Y + this.BackGrdImage.Height / 2));
                    e.Transform = m;
                    path.AddRectangle(location);
                    this.Shadow.RenderFillPath(path, e);
                    
                    e.DrawImage(this.BackGrdImage, location, new Rectangle(0, 0, this.BackGrdImage.Width, this.BackGrdImage.Height), GraphicsUnit.Pixel);

                }
                e.Restore(state);
            }
        }
    }
}
