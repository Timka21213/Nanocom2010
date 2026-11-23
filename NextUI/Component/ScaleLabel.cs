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
    /// Base class of label for the scale bar, to be inherited and not be used directly
    /// </summary>
    public class ScaleLabel : Label
    {
        /// <summary>
        /// enumeration for the position of the label
        /// </summary>
        public enum Position { 
            /// <summary>
            /// Set the label to position on the inner side of the scale bar
            /// </summary>
            Inner, 
            /// <summary>
            /// Set the label to position on the outer side of the scale bar
            /// </summary>
            Outer,
            /// <summary>
            /// set the label to position on the middle of the scale bar
            /// </summary>
            Cross };
        private ScaleBase _parent = null;
        private Position _labelPostion = Position.Inner;
        private int _offsetFromScale = 10;
        /// <summary>
        /// Get the scalebase
        /// </summary>
        protected ScaleBase Parent
        {
            get { return _parent; }
        }
        /// <summary>
        /// Get or set the offset from scale , no effect when position is set to cross.
        /// </summary>
        public int OffsetFromScale
        {
            get { return _offsetFromScale; }
            set
            {
                if (_offsetFromScale != value)
                {
                    _offsetFromScale = value;
                    if ( ! this.NoAutoRefresh)
                    this.TopLevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// basic constructor
        /// </summary>
        /// <param name="bar">the scale bar that own this label</param>
        /// <param name="toplevel">the frame that own the scale bar</param>
        public ScaleLabel(ScaleBase bar,Frame.Frame toplevel)
            : base(toplevel)
        {
            _parent = bar;
        }

        /// <summary>
        /// Get or set the label position 
        /// </summary>
        public Position LabelPostion
        {
            get { return _labelPostion; }
            set
            {
                if (_labelPostion != value)
                {
                    _labelPostion = value;
                    if (!this.NoAutoRefresh)
                    this.TopLevel.Invalidate();
                }
            }
        }

        internal override void Render(Point p, Graphics e)
        {
            throw new Exception("The method or operation is not implemented.");
        }


    }
}
