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
using System.Drawing.Drawing2D;
using System.Drawing;
using NextUI.Common;
using NextUI.Collection;

namespace NextUI.Component
{
    /// <summary>
    /// a Class that encapculate all type of numerical panel
    /// </summary>
    public  class NumericalIndicator
    {
        private NumericalBaseCollection _collection = null;
        private string _displayValue = "";
        private bool _displayInteger = false;
        private int _rounded = 1;
        private Frame.Frame _toplevel = null;

        internal Frame.Frame TopLevel
        {
            get { return _toplevel; }

        }

        internal NumericalIndicator(Frame.Frame fr)
        {
            _collection = new NumericalBaseCollection();
            _toplevel = fr;
        }

        /// <summary>
        /// Get or set the display value is rounded to if RoundedOff is set to true
        /// Use the first discover dot as a starting point of discarding 
        /// If RoundedValue is set to 1, and DisplayValue is 1.333, the resultant value
        /// that will be displayed is 1.3
        /// </summary>
        public int RoundedValue
        {
            get { return _rounded; }
            set
            {
                if (_rounded != value)
                {
                    _rounded = value;
                    SetValue(_displayValue);
                    _toplevel.Invalidate();
                }
            }
        }


        /// <summary>
        /// Get or set  to enable rounded off of the display value 
        /// </summary>
        public bool RoundedOff
        {
            get { return _displayInteger; }
            set
            {
                if (_displayInteger != value)
                {
                    _displayInteger = value;
                    SetValue(_displayValue);
                    _toplevel.Invalidate();
                }
            }
        }
        /// <summary>
        /// Get the panels object to add panels
        /// </summary>
        public NumericalBaseCollection Panels
        {
            get { return _collection; }
        }
        /// <summary>
        /// Get or set the value to be displayed
        /// </summary>
        public string DisplayValue
        {
            get { return _displayValue; }
            set
            {

                    _displayValue = value;
                    SetValue(_displayValue);
                    _toplevel.Invalidate();
                
            }
        }

        private void SetValue(string val)
        {
            char[] charArray = val.ToCharArray();
            int dotCount = 0;
            if (this._displayInteger)
            {
                
                int remainchar = 0;
                foreach (char x in charArray)
                {
                    if (x == '.')
                    {
                        break;
                    }
                    remainchar++;
                }
                if (remainchar + this.RoundedValue < charArray.Length - 1)
                {
                    charArray = new char[remainchar + this.RoundedValue + 1];
                    for (int i = 0; i < remainchar + this.RoundedValue + 1; i++)
                    {
                        charArray[i] = val[i];
                    }
                }
            }
            //get the number of dot in the array
            foreach (char x in charArray)
            {
                if (x == '.')
                    dotCount++;
            }
            int limit = charArray.Length - dotCount;
            if (limit >= this.Panels.Count)
                limit = this.Panels.Count;
            int k = this.Panels.Count - limit;
            for (int i = 0; i < this.Panels.Count ; i++)
            {
                _collection[i].DisplayOn = false;
                _collection[i].EnableDot = false;
            }
            for (int i = 0; i < charArray.Length; i++)
            {

                if (charArray[i] == '.' && k - 1 >= 0)
                {
                    _collection[k - 1].EnableDot = true;
                    _collection[k - 1].DisplayOn = true;
                    continue;
                }
                else
                {
                    if (k < _collection.Count)
                    {
                        _collection[k].DisplayValue = charArray[i];
                        _collection[k].DisplayOn = true;
                        _collection[k].EnableDot = false;
                        k++;
                    }
                }
            }

        }



        internal void Render(RectangleWrap bound, Graphics e)
        {
            float width = 0;
            float i = 0;
            if (_collection.Count > 0)
            {
                width = (float)bound.Width / (float)_collection.Count;
                //quick fix to solve floating and integer conversion
                foreach (NumericalBase panel in _collection)
                {
                    RectangleWrap iBound = new RectangleWrap(
                        new Rectangle((int)(bound.Left + i * width), bound.Top, (int)(width), bound.Height));
                    panel.Render(iBound, e);
                    i++;
                }
            }
        }


        
      
    }
}
