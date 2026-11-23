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

namespace NextUI.Collection
{
    /// <summary>
    /// Call when an object is being inserted into collection
    /// </summary>
    /// <param name="sender">the object being inserted</param>
    /// <param name="index">the index of the object in the collection</param>
    public delegate void OnInsert(object sender, int index);
    /// <summary>
    /// Call when an object in collection is being replaced
    /// </summary>
    /// <param name="sender">the object being replaced</param>
    /// <param name="index">the index of the object in the collection</param>
    public delegate void OnSet(object sender, int index);
    /// <summary>
    /// Call when an object is being removed from collection
    /// </summary>
    /// <param name="sender">the object being removed</param>
    /// <param name="index">the index of the object in the collection</param>
    public delegate void OnRemove(object sender, int index);
    /// <summary>
    /// base class that inherited by all collection
    /// </summary>
    public class BaseStack : CollectionBase
    {
        /// <summary>
        /// Event raised when an object is being inserted
        /// </summary>
        public event OnInsert Insert;
        /// <summary>
        /// Event raised when an object is being deleted
        /// </summary>
        public event OnRemove Delete;
        /// <summary>
        /// Event raised when an object being replaced
        /// </summary>
        public event OnSet Set;

        /// <summary>
        /// Override method that called when insert to collection is done
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        protected override void OnInsertComplete(int index, object value)
        {
            if (Insert != null)
                Insert(value, index);
        }

        /// <summary>
        /// Override method that called when remove from collection is done
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
        protected override void OnRemoveComplete(int index, object value)
        {
            if (Delete != null)
                Delete(value, index);
        }

        /// <summary>
        /// Override method that called when set to collection is done.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        protected override void OnSetComplete(int index, object oldValue, object newValue)
        {
            if (Set != null)
                Set(newValue, index);
        }

        /// <summary>
        /// override method that provide validation 
        /// </summary>
        /// <param name="value"></param>
        protected override void OnValidate(Object value)
        {
        }


        public virtual void Remove()
        {
            if (List.Count > 0)
            {
                List.RemoveAt(List.Count - 1);
                
            }

        }

    }
}
