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
    /// A stack that will stored a array of frame label
    /// </summary>
    public class FrameLabelCollection : BaseStack
    {
        /// <summary>
        /// Add a frame label to collection
        /// </summary>
        /// <param name="value">the frame label that was added</param>
        /// <returns>the frame label  that was added</returns>
        public FrameLabel Add(FrameLabel value)
        {
            base.List.Add(value as object);
            return value;
        }


        /// <summary>
        /// Add an array of frame label to the collection
        /// </summary>
        /// <param name="value">array of frame label </param>
        public void AddRange(FrameLabel[] value)
        {
            foreach (FrameLabel Gbase in value)
            {
                base.List.Add(Gbase as object);
            }

        }

        /// <summary>
        /// Remove the frame label  from the collection , index will be adjusted accordingly
        /// </summary>
        /// <param name="value"></param>
        public void Remove(FrameLabel value)
        {
            base.List.Remove(value as Object);

        }


        /// <summary>
        /// Access the frame  label  with the index
        /// </summary>
        /// <param name="index">the index of the object</param>
        /// <returns></returns>
        public FrameLabel this[int index]
        {
            get { return (FrameLabel)base.List[index]; }
            set { base.List[index] = value as object; }
        }
    }
}
