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
    /// a class that render a circular pointer which is only used by circular frame
    /// </summary>
    public class   CircularPointer
    {
        private Pointerbase _pointerBase = null;
        private PointerCapBase _pointerCap = null;
        private ScaleBase _parent = null;
        private bool _capOntop = true;
        private float _value = 0;
        private float _angle = 0;
        private Frame.Frame _toplevel = null;

        internal Frame.Frame TopLevel
        {
            get { return _toplevel; }

        }


        
        /// <summary>
        /// get or set the current angle the pointer is pointing to , the angle is 
        /// normalised to + y axis.
        /// </summary>
        internal float Angle
        {
            get { return _angle; }
            set
            {
                if (_angle != value)
                {
                    _angle = value;
                    _toplevel.Invalidate();
                }
            }
        }


        /// <summary>
        /// Get or set the value the pointer will be pointing to .
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
        /// Get or set whether the pointer cap should be on top.
        /// </summary>
        public bool CapOnTop
        {
            get { return _capOntop; }
            set
            {
                if (_capOntop != value)
                {
                    _capOntop = value;
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
        /// Get the pointer cap object that can be used to configured the pointer cap.
        /// </summary>
        public PointerCapBase CapPointer
        {
            get { return _pointerCap; }
        }

        /// <summary>
        /// basic constructor
        /// </summary>
        /// <param name="toplevel">the frame that owns the pointer</param>
        public CircularPointer(Frame.Frame toplevel)
        {
            if (toplevel == null)
            {
                throw new Exception("toplevel is null");
            }
            _pointerBase = new Pointerbase(toplevel);
            _pointerCap = new PointerCapBase(toplevel);
            _toplevel = toplevel;
        }

        internal void Render(Point center, Graphics e)
        {
            _angle = (int)_parent.CalculatePosition(_value);
            Matrix m = new Matrix();
            GraphicsState state = e.Save();
            m.RotateAt(_angle, new PointF(center.X, center.Y));
            e.Transform = m;
            if (_capOntop)
            {
                _pointerBase.Render(center, e);
                _pointerCap.Render(center, e);
            }
            else
            {
                _pointerCap.Render(center, e);
                _pointerBase.Render(center, e);
            }
            e.Restore(state);

        }

    }
}
