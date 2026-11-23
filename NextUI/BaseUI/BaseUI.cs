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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using NextUI.Common;
using NextUI.Shape;
using NextUI.Frame;
using NextUI.Component;
using System.Windows.Forms;
using NextUI.Collection;


namespace NextUI.BaseUI
{
    /// <remarks>
    /// BaseUI provides a parent container class for all frame
    /// </remarks>
	public class BaseUI : UserControl
	{
        private Bitmap _map = null;
        private FrameCollection _collection;
        private Frame.Frame _hitFrame = null;
        private bool _interactivity = false;

        /// <summary>
        /// Get or set to enable interactivity for all frame within this baseUI.
        /// When intaractivity is on , all pointer will be able to accept mouse event
        /// </summary>
        public bool Interact
        {
            get { return _interactivity; }
            set
            {
                if (_interactivity != value)
                {
                    _interactivity = value;
                }
            }
        }


        /// <summary>
        /// Get a frame collection to add a frame to be rendered
        /// </summary>
        public FrameCollection Frame
        {
            get { return _collection; }
        }

        /// <summary>
        /// Basic constructor
        /// </summary>
        public BaseUI()
        {
            _collection =  new FrameCollection();
            _collection.Insert += new OnInsert(_collection_Insert);
        }

        void _collection_Insert(object sender, int index)
        {
            NextUI.Frame.Frame fr = (NextUI.Frame.Frame)sender;
            fr.Parent = this;
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_interactivity)
            {
                if (_hitFrame != null)
                {
                    _hitFrame.OnMouseUp(e);
                    _hitFrame = null;
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_interactivity)
            {
                if (_hitFrame != null)
                {
                    _hitFrame.OnMouseMove(e);
                    this.Invalidate();
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (_interactivity)
            {
                for (int i = _collection.Count - 1; i >= 0; i--)
                {
                    if (_collection[i].OnMouseDown(e) == true)
                    {
                        _hitFrame = _collection[i];
                        Console.WriteLine("hitframe = " + i);
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_map == null)
            {
                _map = new Bitmap(this.Width, this.Height);
            }
            Graphics g = Graphics.FromImage(_map);
            g.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(new Point(0, 0), _map.Size));
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            g.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(0, 0, this.Width, this.Height));
            if (this.BackgroundImage != null)
            {
                g.DrawImage(this.BackgroundImage, new Rectangle(0, 0, this.Width, this.Height), new Rectangle(0, 0, this.BackgroundImage.Width, this.BackgroundImage.Height), GraphicsUnit.Pixel);
            }
            foreach (NextUI.Frame.Frame frame in _collection)
            {
                frame.Render(g);
            }
           
            g.Dispose();
            e.Graphics.DrawImage(_map, new Point(0, 0));
            base.OnPaint(e);
        }

        protected Bitmap Map()
        {
            return _map;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }
	}
}
