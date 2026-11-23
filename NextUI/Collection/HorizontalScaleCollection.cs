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
using System.Collections;
using System.Drawing;
using NextUI.Component;

namespace NextUI.Collection
{
    /// <summary>
    /// A stack that will stored a array of horizontal scale bar
    /// </summary>
    public class HorizontalScaleCollection  : BaseStack
    {
        /// <summary>
        /// Add a horizontal scale bar to collection
        /// </summary>
        /// <param name="value">the scale bar that was added</param>
        /// <returns>the scale bar that was added</returns>
        public HorizontalScaleBar Add(HorizontalScaleBar value)
        {
            base.List.Add(value as object);
            return value;
        }

        /// <summary>
        /// Add an array of scale bar to the collection
        /// </summary>
        /// <param name="value">array of scale bar</param>
        public void AddRange(HorizontalScaleBar[] value)
        {
            foreach (HorizontalScaleBar Gbase in value)
            {
                base.List.Add(Gbase as object);
            }

        }
        /// <summary>
        /// Remove the scale bar from the collection , index will be adjusted accordingly
        /// </summary>
        /// <param name="value"></param>
        public void Remove(HorizontalScaleBar value)
        {
            base.List.Remove(value as Object);

        }

        /// <summary>
        /// Access the horizontal scale bar with the index
        /// </summary>
        /// <param name="index">the index of the object</param>
        /// <returns></returns>
        public HorizontalScaleBar this[int index]
        {
            get { return (HorizontalScaleBar)base.List[index]; }
            set { base.List[index] = value as object; }
        }
    }
}
