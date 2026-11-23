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
    /// A stack that will stored a array of circular marker
    /// </summary>
    public class CircularMarkerCollection : BaseStack
    {
        /// <summary>
        /// Add a circular marker to collection
        /// </summary>
        /// <param name="value">the marker that was added</param>
        /// <returns>the marker that was added</returns>
        public CircularMarker Add(CircularMarker value)
        {
            base.List.Add(value as object);
            return value;
        }

        /// <summary>
        /// Add an array of marker to the collection
        /// </summary>
        /// <param name="value">array of marker</param>
        public void AddRange(CircularMarker[] value)
        {
            foreach (CircularMarker Gbase in value)
            {
                base.List.Add(Gbase as object);
            }

        }

        /// <summary>
        /// Remove the marker from the collection , index will be adjusted accordingly
        /// </summary>
        /// <param name="value"></param>
        public void Remove(CircularMarker value)
        {
            base.List.Remove(value as Object);

        }

        /// <summary>
        /// Access the circular marker with the index
        /// </summary>
        /// <param name="index">the index of the object</param>
        /// <returns></returns>
        public CircularMarker this[int index]
        {
            get { return (CircularMarker)base.List[index]; }
            set { base.List[index] = value as object; }
        }
    }
}
