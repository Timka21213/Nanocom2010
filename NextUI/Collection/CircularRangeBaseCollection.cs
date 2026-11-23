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
    /// A stack that will stored a array of circular range
    /// </summary>
    public class CircularRangeBaseCollection : BaseStack
    {
        /// <summary>
        /// Add a circular range to collection
        /// </summary>
        /// <param name="value">the range that was added</param>
        /// <returns>the range that was added</returns>
        public CircularRange Add(CircularRange value)
        {
            base.List.Add(value as object);
            return value;
        }
        /// <summary>
        /// Add an array of range to the collection
        /// </summary>
        /// <param name="value">array of range</param>
        public void AddRange(CircularRange[] value)
        {
            foreach (CircularRange Gbase in value)
            {
                base.List.Add(Gbase as object);
            }

        }

        /// <summary>
        /// Remove the range from the collection , index will be adjusted accordingly
        /// </summary>
        /// <param name="value"></param>
        public void Remove(CircularRange value)
        {
            base.List.Remove(value as Object);

        }

        /// <summary>
        /// Access the circular range with the index
        /// </summary>
        /// <param name="index">the index of the object</param>
        /// <returns></returns>
        public CircularRange this[int index]
        {
            get { return (CircularRange)base.List[index]; }
            set { base.List[index] = value as object; }
        }
    }
}
