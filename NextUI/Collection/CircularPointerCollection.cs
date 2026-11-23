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
    /// A stack that will stored a array of circular pointer
    /// </summary>
    public class CircularPointerCollection : BaseStack
    {
        /// <summary>
        /// Add a circular pointer to collection
        /// </summary>
        /// <param name="value">the pointer that was added</param>
        /// <returns>the pointer that was added</returns>
        public CircularPointer Add(CircularPointer value)
        {
            base.List.Add(value as object);
            return value;
        }

        /// <summary>
        /// Add an array of pointer to the collection
        /// </summary>
        /// <param name="value">array of pointer</param>
        public void AddRange(CircularPointer[] value)
        {
            foreach (CircularPointer Gbase in value)
            {
                base.List.Add(Gbase as object);
            }

        }
        /// <summary>
        /// Remove the pointer from the collection , index will be adjusted accordingly
        /// </summary>
        /// <param name="value"></param>
        public void Remove(CircularPointer value)
        {
            base.List.Remove(value as Object);

        }

        /// <summary>
        /// Access the circular pointer with the index
        /// </summary>
        /// <param name="index">the index of the object</param>
        /// <returns></returns>
        public CircularPointer this[int index]
        {
            get { return (CircularPointer)base.List[index]; }
            set { base.List[index] = value as object; }
        }
    }
}
