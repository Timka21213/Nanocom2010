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

namespace NextUI.Component
{
    /// <summary>
    /// an abstract class of the scale for both circular scale bar and horizontal scale bar
    /// </summary>
    public abstract class ScaleBase
    {
        /// <summary>
        ///  enumeration of type of border line for the scale bar 
        /// </summary>
        public enum Style{
            /// <summary>
            /// Style not set.
            /// </summary>
            NotSet,
            /// <summary>
            /// Specifies a line consisting of dashes. 
            /// </summary>
            Dash,
            /// <summary>
            /// Specifies a line consisting of a repeating pattern of dash-dot. 
            /// </summary>
            DashDot,
            /// <summary>
            /// Specifies a line consisting of a repeating pattern of dash-dot-dot.       
            /// </summary>
            DashDotDot,
            /// <summary>
            /// Specifies a line consisting of dots.  
            /// </summary>
            Dot,
            /// <summary>
            /// Specifies a solid line.
            /// </summary>
            Solid
        }; 
        private int _scaleBarSize = 10;
        private Renderer.RendererGradient.GradientType _fillGradientType = NextUI.Renderer.RendererGradient.GradientType.DiagonalRight;
        private Color _fillColor = Color.Gray ;
        private Color _fillGradientEndColor = Color.White;
        private Color _borderColor = Color.Black;
        private Style _borderStyle = Style.Solid;
        private int _offsetFromFrame = 10;
        private bool _visible = true;
        private float _startValue = 1;
        private float _endValue = 100;
        private int _majorTickNumber = 10;
        private int _minorTickNumber = 3;
        private Renderer.RenderShadow _shadow = null;
        private bool _interactivity = false;
        private string[] _customLabelText;
        private bool _labelCastInt = false;
        private MajorTick _majorTick = null;
        private MinorTick _minorTick = null;
        private Label _label = null;
        private Frame.Frame _toplevel = null;
        private Renderer.RendererGradient _gra;
        private bool _noAutoUpdate = false;

        internal bool NoAutoRefresh
        {
            get { return _noAutoUpdate; }
            set { _noAutoUpdate = value; }
        }

        internal Renderer.RendererGradient Gradient
        {
            get { return _gra; }
        }

        internal Frame.Frame TopLevel
        {
            get { return _toplevel; }

        }

        internal Label BaseLabel
        {
            get { return _label; }
            set { _label = value; }
        }

        /// <summary>
        /// Get Object to configure Major tick
        /// </summary>

        public MajorTick TickMajor
        {
            get { return _majorTick; }
        }
        /// <summary>
        /// Get Object to configure Minor Tick
        /// </summary>

        public MinorTick TickMinor
        {
            get { return _minorTick; }
        }

        /// <summary>
        /// Get or set the flag to cast all label value to integer , by
        /// default , they display in floating point.
        /// </summary>
        public bool CastLabelToInteger
        {
            get { return _labelCastInt; }
            set
            {
                if (_labelCastInt != value)
                {
                    _labelCastInt = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }


        /// <summary>
        /// Get or set the custom label to be displayed instead of library generated value
        /// Number of custom label should be equal to the MajorTickNumber for it to work correctly
        /// </summary>
        public string[] CustomLabel
        {
            get { return _customLabelText; }
            set
            {
                _customLabelText = value;
                if (!_noAutoUpdate)
                _toplevel.Invalidate();
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
        /// Get the shadow object to render a shadow on the scale
        /// </summary>
        public Renderer.RenderShadow Shadow
        {
            get { return _shadow; }
        }

        /// <summary>
        /// Get or set the number of minor tick between majorTick
        /// </summary>
        public int MinorTicknumber
        {
            get { return _minorTickNumber; }
            set
            {
                if (_minorTickNumber != value)
                {
                    _minorTickNumber = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the number of major tick
        /// </summary>
        public int MajorTickNumber
        {
            get { return _majorTickNumber; }
            set
            {
                if (_majorTickNumber != value && _majorTickNumber > 1)
                {
                    _majorTickNumber = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }


        /// <summary>
        /// Get or set the end value of the label. Library use StartValue , EndValue and MajorTickNumber
        /// to calculate the value of the label . If you wish to used customized label, set the CustomLabel array
        /// </summary>
        public float EndValue
        {
            get { return _endValue; }
            set
            {
                if (_endValue != value)
                {
                    _endValue = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }
        /// <summary>
        /// Get or set the start value of the label. Library use StartValue , EndValue and MajorTickNumber
        /// to calculate the value of the label . If you wish to used customized label, set the CustomLabel array
        /// </summary>
        public float StartValue
        {
            get { return _startValue; }
            set
            {
                if (_startValue != value)
                {
                    _startValue = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the visibility of the bar
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
        /// Get or set the distance from the frame.
        /// </summary>
        public int OffsetFromFrame
        {
            get { return _offsetFromFrame; }
            set
            {
                if (_offsetFromFrame != value)
                {
                    _offsetFromFrame = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Gets or sets the style of the border
        /// </summary>
        public Style BorderStyle
        {
            get { return _borderStyle; }
            set
            {
                if (_borderStyle != value)
                {
                    _borderStyle = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                    
                }
            }
        }

        /// <summary>
        /// Gets or sets the color of the border
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
        /// Set the thickness of the scale bar
        /// </summary>

        public int ScaleBarSize
        {
            get { return _scaleBarSize; }
            set
            {
                if (_scaleBarSize != value && value > 0)
                {
                    _scaleBarSize = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }
     
        /// <summary>
        /// The primary fill gradient type of the scale
        /// </summary>

        public Renderer.RendererGradient.GradientType FillGradientType
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
        /// Get or set the end color of the scale's fill gradient
        /// </summary>
        public Color EndColor
        {
            get { return _fillGradientEndColor; }
            set
            {
                if (_fillGradientEndColor != value)
                {
                    _fillGradientEndColor = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the end color of the scale's fill color
        /// </summary>
        public Color FillColor
        {
            get { return _fillColor; }
            set
            {
                if (_fillColor != value)
                {
                    _fillColor = value;
                    if (!_noAutoUpdate)
                    _toplevel.Invalidate();
                }
            }
        }

        internal ScaleBase(Frame.Frame topLevel)
        {
            if (topLevel == null)
            {
                throw new Exception("Toplevel object is null");
            }
            _shadow = new NextUI.Renderer.RenderShadow(topLevel);
            _gra = new NextUI.Renderer.RendererGradient(topLevel);
            _gra.NoAutoRefresh = true;
            _majorTick = new MajorTick(this,topLevel);
            _minorTick = new MinorTick(this,topLevel);
            _toplevel = topLevel;
        }
   
        /// <summary>
        /// Abstract method to render the scale bar
        /// </summary>
        /// <param name="Bound"></param>
        /// <param name="e"></param>
        internal abstract void RenderScale(RectangleWrap Bound, Graphics e);
        
        internal abstract void RenderMarking(RectangleWrap Bound,Graphics e);

        internal abstract void RenderPointer(RectangleWrap Bound,Graphics e); 

        /// <summary>
        /// Internal method to be inherited by child, it is used to calculate the position 
        /// based on the input value
        /// </summary>
        /// <param name="label">the input value </param>
        /// <returns></returns>
        internal abstract float CalculatePosition(float label);

        /// <summary>
        /// Internal method to be inherited by child , it is used to calculate the value based on the 
        /// current position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        internal abstract float CalculateValue(float position);

        internal virtual bool OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            return false;
        }

        internal virtual bool OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            return false;
        }

        internal virtual bool OnMouseMove(System.Windows.Forms.MouseEventArgs e)
        {
            return false;
        }

    }
}
