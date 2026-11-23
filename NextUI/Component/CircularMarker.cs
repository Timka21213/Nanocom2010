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
    /// a class that implement the marker which is only used by circular frame
    /// </summary>
    public class CircularMarker : HorizontalPointer
    {

        private PointF _center = new PointF(0, 0);

        /// <summary>
        /// get or set the center of the marker to be evol arround
        /// </summary>
        internal PointF Center
        {
            get { return _center; }
            set
            {
                if (_center != value)
                {
                    _center = value;
                    this.TopLevel.Invalidate();
                }
            }
        }
        /// <summary>
        /// Basic ocnstructor
        /// </summary>
        /// <param name="toplevel">the frame that owns the marker</param>

        public CircularMarker(Frame.Frame toplevel)
            : base(toplevel)
        {
            this.BasePointer.Length = 10;
            this.BasePointer.PointerShapeType = Pointerbase.PointerType.Type2;
            this.PointerPosition = Position.Cross;
        }

        internal override void Render(Point x, Graphics e)
        {
            PointF markerLocation = new PointF(0, 0);
            float  angle = this.Parent.CalculatePosition(this.Value);
            GraphicsState state = e.Save();
            switch (this.PointerPosition)
            {
                case Position.Cross:
                    markerLocation.Y = x.Y + this.Parent.ScaleBarSize / 2 + this.BasePointer.Length / 2;
                    markerLocation.X = x.X;
                    break;

                case Position.Inner:
                    markerLocation.Y =  x.Y + this.Parent.ScaleBarSize + this.OffsetFromScale + this.BasePointer.Length;
                    markerLocation.X = x.X;
                    break;
                case Position.Outer:
                    markerLocation.Y =  x.Y - this.OffsetFromScale ;
                    markerLocation.X = x.X;
                    break;
            }
            Matrix m = new Matrix();
            m.RotateAt(angle, _center);
            if (this.PointerPosition == Position.Outer)
            {
                m.RotateAt(180f, markerLocation);
                m.Translate(0, this.BasePointer.Length);
            }
            e.Transform = m;
            this.BasePointer.Render(new Point((int)markerLocation.X,(int)markerLocation.Y), e);
            e.Restore(state);

        }
    }
}
