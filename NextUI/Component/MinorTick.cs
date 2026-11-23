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
    /// class that render the minor tick
    /// </summary>
    public class MinorTick : TickBase
    {
        /// <summary>
        /// basic constructor
        /// </summary>
        /// <param name="bar">the scalebar that own the minor tick</param>
        /// <param name="topLevel">the frame that own the scale bar</param>
        public MinorTick(ScaleBase bar,Frame.Frame topLevel) : base(bar,topLevel)
        {
            this.Width = 4;
            this.Height = 10;
        }
    }
}
