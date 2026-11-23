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
    /// A stack that will stored a array of numeric panel
    /// </summary>
    public class NumericalBaseCollection : BaseStack
    {
        /// <summary>
        /// Add a numeric panel to collection
        /// </summary>
        /// <param name="value">the panel that was added</param>
        /// <returns>the panel that was added</returns>
        public NumericalBase Add(NumericalBase value)
        {
            base.List.Add(value as object);
            return value;
        }

        /// <summary>
        /// Add an array of panel to the collection
        /// </summary>
        /// <param name="value">array of panel</param>
        public void AddRange(NumericalBase[] value)
        {
            foreach (NumericalBase Gbase in value)
            {
                base.List.Add(Gbase as object);
            }

        }


        /// <summary>
        /// Remove the panel from the collection , index will be adjusted accordingly
        /// </summary>
        /// <param name="value"></param>
        public void Remove(NumericalBase value)
        {
            base.List.Remove(value as Object);

        }

        /// <summary>
        /// Access the panel with the index
        /// </summary>
        /// <param name="index">the index of the object</param>
        /// <returns></returns>
        public NumericalBase this[int index]
        {
            get { return (NumericalBase)base.List[index]; }
            set { base.List[index] = value as object; }
        }
    }
}
