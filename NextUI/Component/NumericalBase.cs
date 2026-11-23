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
using System.Drawing.Drawing2D;
using System.Drawing;
using NextUI.Common;

namespace NextUI.Component
{
    /// <summary>
    /// Abstract class to be inherited for all numerical panel
    /// </summary>
    public abstract class NumericalBase
    {
        private Color _mainColor = Color.Black;
        private Color _backColor = Color.OliveDrab;
        private Color _borderColor = Color.White;
        private bool _enableBorder = true;
        private bool _enableGradient = false;
        private Color _endColor = Color.White;
        private int _borderWidth = 1;
        private char _displayValue = '0';
        private bool _visible = true;
        private bool _displayOn = false;
        private Renderer.RenderShadow _shadow = null;
        private Renderer.RendererGradient.GradientType _fillGradientType = NextUI.Renderer.RendererGradient.GradientType.DiagonalRight;
        private bool _enableDot = false;
        private Frame.Frame _toplevel = null;
        private bool _noAutoUpdate = false;
        Renderer.RendererGradient _gra = null;

        internal Renderer.RendererGradient Gradient
        {
            get { return _gra; }
        }

        internal bool NoAutoRefresh
        {
            get { return _noAutoUpdate; }
            set { _noAutoUpdate = value; }
        }

        internal Frame.Frame TopLevel
        {
            get { return _toplevel; }
            set
            {
                _toplevel = value;

            }

        }

        internal bool EnableDot
        {
            get { return _enableDot; }
            set
            {
                if (_enableDot != value)
                {
                    _enableDot = value;
                    if ( ! _noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }


        /// <summary>
        /// Get the shadow object to configure the shadow 
        /// </summary>
        public Renderer.RenderShadow Shadow
        {
            get { return _shadow; }
        }

        /// <summary>
        /// Get or set the type of gradient to be rendered if enable gradient is set to true
        /// </summary>
        public Renderer.RendererGradient.GradientType GradientType
        {
            get { return _fillGradientType; }
            set
            {
                if (_fillGradientType != value)
                {
                    _fillGradientType = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set to enable DisplayValue to be shown , else DisplayValue will not be shown regardless of the value
        /// </summary>
        internal bool DisplayOn
        {
            get { return _displayOn; }
            set
            {
                if (_displayOn != value)
                {
                    _displayOn = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the visibility of the component
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
        /// Get or set the value to be displayed
        /// </summary>
        internal char DisplayValue
        {
            get { return _displayValue; }
            set
            {
                if (_displayValue != value)
                {
                    _displayValue = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the Main display Color .
        /// </summary>
        public Color MainColor
        {
            get { return _mainColor; }
            set
            {
                if (_mainColor != value)
                {
                    _mainColor = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the back color
        /// </summary>
        public Color BackColor
        {
            get { return _backColor; }
            set
            {
                if (_backColor != value)
                {
                    _backColor = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();

                }
            }
        }
        /// <summary>
        /// Get or set the Color of the border
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
        /// Get or set the width of the border
        /// </summary>
        public int BorderWidth
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
        /// Get or set to enable the border
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
        /// Get or set to enable gradient 
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

        internal NumericalBase(Frame.Frame toplevel)
        {
            if (toplevel == null)
            {
                throw new Exception("toplevel is null");
            }
            _toplevel = toplevel;
            _shadow = new NextUI.Renderer.RenderShadow(_toplevel);
            _gra = new NextUI.Renderer.RendererGradient(_toplevel);
            _gra.NoAutoRefresh = true;
        }

        /// <summary>
        /// Get or set the end color , if gradient is enable
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


        internal abstract void Render(RectangleWrap bound, Graphics e);

    }
}
