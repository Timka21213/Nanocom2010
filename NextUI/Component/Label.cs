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
    /// an abstract class to be inherited that implements a label
    /// </summary>
    public abstract class Label
    {
        private string _text = "0"; // the text to display
        private Color _borderColor = Color.Black; // the Color of the border
        private float _borderWidth = 0.3f; // the width of the border
        private Color _fontColor = Color.Black; //the color of the font
        private Color _endColor = Color.White;
        private bool _enableBorder = false; // enable the color of the border
        private bool _enableGradient = false; // enable gradient of the text;
        private bool _visible = true;
        private Font _labelfont = new Font(FontFamily.GenericMonospace, 8,FontStyle.Bold);
        private float _angle = 0;
        private NextUI.Renderer.RenderShadow _shadow = null;
        private Frame.Frame _toplevel = null;
        private bool _noAutoUpdate = false;

        internal bool NoAutoRefresh
        {
            get { return _noAutoUpdate; }
            set { _noAutoUpdate = value; }
        }

        internal Frame.Frame TopLevel
        {
            get { return _toplevel; }

        }
        /// <summary>
        /// Get the shadow object to configured the shadow object
        /// </summary>
        public NextUI.Renderer.RenderShadow Shadow
        {
            get { return _shadow; }
        }

        /// <summary>
        /// Get or set the angle to rotate the label
        /// </summary>
        public float Angle
        {
            get { return _angle; }
            set
            {
                if (_angle != value && value < 360 && value >=0)
                {
                    _angle = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }
        

        /// <summary>
        /// Get or set the width of the border
        /// </summary>
        public float BorderWidth
        {
            get { return _borderWidth; }
            set
            {
                if (_borderWidth != value)
                {
                    _borderWidth = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set the end color if enable gradient is set to true.
        /// </summary>
        public Color EndColor
        {
            get { return _endColor; }
            set
            {
                if (_endColor != value)
                {
                    _endColor = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the label with a font
        /// </summary>
        public Font LabelFont
        {
            get { return _labelfont; }
            set
            {
                if (_labelfont != value)
                {
                    _labelfont = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// get or set to enable visible
        /// </summary>
        public bool Visible
        {
            get { return _visible; }
            set
            {
                if (_visible != value)
                {
                    _visible = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set to enable or disable the gradient effect.
        /// </summary>
        public bool EnableGradient
        {
            get { return _enableGradient; }
            set
            {
                if (_enableGradient != value)
                {
                    _enableGradient = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set to enable the border of the label
        /// </summary>
        public bool EnableBorder
        {
            get { return _enableBorder; }
            set
            {
                if (_enableBorder != value)
                {
                    _enableBorder = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the font color of the Font.
        /// </summary>
        public Color FontColor
        {
            get { return _fontColor; }
            set
            {
                if (_fontColor != value)
                {
                    _fontColor = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the color of the border
        /// </summary>
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                if (_borderColor != value)
                {
                    _borderColor = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// get or set the text to be displayed
        /// </summary>
        internal String Text
        {
            get { return _text; }
            set
            {
                if (_text != value)
                {
                    _text = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }

        internal Label(Frame.Frame toplevel)
        {
            if (toplevel == null)
            {
                throw new Exception("toplevel is null");
            }
            _toplevel = toplevel;
            _shadow = new NextUI.Renderer.RenderShadow(toplevel);
        }


        internal abstract void Render(Point p, Graphics e);
    }
}
