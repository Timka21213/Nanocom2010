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
    /// a Class that render a major tick
    /// </summary>
    public class MajorTick : TickBase
    {
        /// <summary>
        /// basic constructor
        /// </summary>
        /// <param name="bar">the scale bar that own the major tick</param>
        /// <param name="toplevel">the frame that own the scale bar</param>
        public MajorTick(ScaleBase bar,Frame.Frame toplevel) : base(bar,toplevel)
        {
            this.Width = 4;
            this.Height = 20;
        }
    }
}
