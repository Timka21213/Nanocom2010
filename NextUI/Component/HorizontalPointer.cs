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
    /// A horizontal that rides along the horizontal scalebar.
    /// </summary>
    public class HorizontalPointer
    {
        /// <summary>
        /// enumeration for the position of the pointer
        /// </summary>
        public enum Position { 
            /// <summary>
            /// Set the position of the pointer on the inner side of the scale bar
            /// </summary>
            Inner, 
            /// <summary>
            /// Set the position of the pointer on the middle of the scale bar
            /// </summary>
            Cross, 
            /// <summary>
            /// Set the position of the pointer on the outward side of the scale bar
            /// </summary>
            Outer };
        private Pointerbase _pointerBase = null;
        private ScaleBase _parent = null;
        private int _offsetfromScale = 1;
        private Position _pointerPostion = Position.Inner;
        private float _value = 0;
        private  Frame.Frame _toplevel = null;

        internal Frame.Frame TopLevel
        {
            get { return _toplevel; }

        }

        /// <summary>
        /// Get or set the value the pointer to point to, the value depends on the label of the scale. 
        /// the value of the label is the automatic calculated value by the library and not the custom label
        /// </summary>
        public float Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the offset from the scale, does not impact when poation is set to cross
        /// </summary>
        public int OffsetFromScale
        {
            get { return _offsetfromScale; }
            set
            {
                if (_offsetfromScale != value)
                {
                    _offsetfromScale = value;
                    _toplevel.Invalidate();
                }
            }
        }

        /// <summary>
        /// Get or set the position of the pointer
        /// </summary>
        public Position PointerPosition
        {
            get { return _pointerPostion; }
            set
            {
                if (_pointerPostion != value)
                {
                    _pointerPostion = value;
                    _toplevel.Invalidate();
                }
            }
        }


        /// <summary>
        /// Internal to be set by Scale.
        /// </summary>
        internal ScaleBase Parent
        {
            get { return _parent; }
            set
            {
                if (_parent != value)
                {
                    _parent = value;
                }
            }
        }

        /// <summary>
        /// Get the pointer object that can be used to configured the pointer.
        /// </summary>
        public Pointerbase BasePointer
        {
            get { return _pointerBase; }
        }

        /// <summary>
        /// basic constructor
        /// </summary>
        /// <param name="toplevel">the parent frame that own the scale bar which own the pointer</param>

        public HorizontalPointer(Frame.Frame toplevel)
        {
            if ( toplevel == null )
            {
                throw new Exception ("toplevel is null");
            }
            _toplevel = toplevel;
            _pointerBase = new Pointerbase(toplevel);
        }

        internal virtual void Render(Point x, Graphics e)
        {
            PointF center = new Point(0, 0);
            float xlocation = _parent.CalculatePosition(_value);
            
            switch (_pointerPostion)
            {
                case Position.Cross:
                    center.X = xlocation;
                    center.Y = x.Y + _parent.ScaleBarSize / 2 + _pointerBase.Length / 2;
                    break;

                case Position.Inner:
                    center.X = xlocation;
                    center.Y = x.Y + _parent.ScaleBarSize + _pointerBase.Length + _offsetfromScale;
                    break;
                case Position.Outer:
                    center.X = xlocation;
                    center.Y = x.Y - _offsetfromScale;
                    break;
            }
            if (_pointerPostion == Position.Outer)
            {
                GraphicsState state = e.Save();
                Matrix m = new Matrix();
                m.RotateAt(180f,center);
                m.Translate(0, _pointerBase.Length);
                e.Transform = m;
                _pointerBase.Render(new Point((int)center.X,(int)center.Y), e);
                e.Restore(state);

            }
            else
            {
                _pointerBase.Render(new Point((int)center.X, (int)center.Y), e);
            }
        }

    }
}
