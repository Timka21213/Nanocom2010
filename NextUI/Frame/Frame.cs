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
using NextUI.Renderer;
using NextUI.Collection;
using System.Windows.Forms;

namespace NextUI.Frame
{
    /// <summary>
    /// Parent of all frame
    /// </summary>
    public class Frame
    {
        
        RectangleWrap _bound;
        private FrameRender _frameRenderer = null;
        private RendererGradient _backRenderer = null;
        private FrameCollection _frameCollection = null;
        private bool _interactivity = false;
        private Image _backImage = null;
        private Image _frameImage = null;
        private FrameLabelCollection _frameLabelCollection = null;
        private BaseUI.BaseUI _parent = null;

        internal BaseUI.BaseUI Parent
        {
            get { return _parent; }
            set
            {
                _parent = value;
            }
        
        }

        internal void Invalidate()
        {
            if (_parent != null)
            {
                _parent.Invalidate();
            }
        }

        /// <summary>
        /// Get or set the Image of the frame, set frameImage will disable the 
        /// framerenderer , set FrameImage to null will remove the image
        /// </summary>
        public Image FrameImage
        {
            get { return _frameImage; }
            set
            {
                if (_frameImage != value)
                {
                    _frameImage = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the background Image of the frame, set the background image will
        /// disable the backrenderer , set BackImage to null will remove the image
        /// </summary>
        public Image BackImage
        {
            get { return _backImage; }
            set
            {
                if (_backImage != value)
                {
                    _backImage = value;
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set to enable interactivity for this pointer
        /// </summary>
        internal bool Interact
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
        /// Get the FrameLabelCollection object to add framelabel into the current frame
        /// </summary>
        public FrameLabelCollection FrameLabelCollection
        {
            get { return _frameLabelCollection; }
        }

        /// <summary>
        /// Get the Framecollection object to add the inner frame
        /// </summary>
        public FrameCollection FrameCollection
        {
            get { return _frameCollection; }
        }
        /// <summary>
        /// Get the Rendererobject to set the type of background , setting BackImage will
        /// disanle the backrenderer
        /// </summary>
        public RendererGradient BackRenderer
        {
            get { return _backRenderer; }
        }

        /// <summary>
        /// Get the Rendererobject to set the type of frame to render, setting FrameImage will
        /// disable the framerenderer.
        /// </summary>
        public FrameRender FrameRenderer
        {
            get { return _frameRenderer; }
        }

        /// <summary>
        /// basic constructor
        /// </summary>
        /// <param name="bound">a rectangle wrap object that defines the bound</param>
        public Frame(RectangleWrap bound)
        {
            _bound = bound;
            _frameCollection = new FrameCollection();
            _frameCollection.Insert += new OnInsert(_frameCollection_Insert);
            _frameLabelCollection = new FrameLabelCollection();
         
            _frameRenderer = new FrameRender(this);
            _backRenderer = new RendererGradient(this);
        }



        void _frameCollection_Insert(object sender, int index)
        {
            //we adjust the internal frame to be relative to the baseUI container
            Frame fr = (Frame)sender;
            int left = this.Bound.Left + fr.Bound.Left;
            int top = this.Bound.Top + fr.Bound.Top;
            int width = fr.Bound.Width;
            int height = fr.Bound.Height;
            fr.Parent = this.Parent;
            fr.Bound = new RectangleWrap(new Rectangle(left, top, width, height));


        }

        /// <summary>
        /// Get the current location and size as rectangle 
        /// </summary>
        public Rectangle Rect
        {
            get { return _bound.Rect; }
        }
        
        /// <summary>
        /// Return the Current Bound of the Frame
        /// </summary>

        internal RectangleWrap Bound
        {
            get { return _bound; }
            set
            {
                if (_bound != value)
                {
                    _bound = value;
                    Invalidate();
                }
            }
        }
        
    
        /// <summary>
        ///  custom render method to be implemented by the child 
        /// </summary>
        /// <param name="e">the graphic object</param>
        internal virtual void Render(Graphics e)
        {
        }

        /// <summary>
        /// custom on mouse move to be implemented by child
        /// </summary>
        /// <param name="e"></param>
        internal virtual void OnMouseMove(MouseEventArgs e)
        {
        }
        internal virtual bool OnMouseDown(MouseEventArgs e)
        {
            return false;
        }

        internal virtual void OnMouseUp(MouseEventArgs e)
        {
        }
    }
}
