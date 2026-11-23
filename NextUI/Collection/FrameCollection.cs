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
    /// A stack that will stored a array of frame
    /// </summary>
    public class FrameCollection : BaseStack
    {
        /// <summary>
        /// Add a frame to collection
        /// </summary>
        /// <param name="value">the frame that was added</param>
        /// <returns>the frame that was added</returns>
        public Frame.Frame Add(Frame.Frame value)
        {
            base.List.Add(value as object);
            return value;
        }

        /// <summary>
        /// Add an array of frame to the collection
        /// </summary>
        /// <param name="value">array of frame</param>
        public void AddRange(Frame.Frame[] value)
        {
            foreach (Frame.Frame Gbase in value)
            {
                base.List.Add(Gbase as object);
            }

        }

        /// <summary>
        /// Remove the frame from the collection , index will be adjusted accordingly
        /// </summary>
        /// <param name="value"></param>
        public void Remove(Frame.Frame value)
        {
            base.List.Remove(value as Object);

        }

        /// <summary>
        /// Access the frame with the index
        /// </summary>
        /// <param name="index">the index of the object</param>
        /// <returns></returns>
        public Frame.Frame this[int index]
        {
            get { return (Frame.Frame)base.List[index]; }
            set { base.List[index] = value as object; }
        }
    }
}
