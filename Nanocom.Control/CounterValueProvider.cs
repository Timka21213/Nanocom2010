using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nanocom.Control
{
    public class CounterValueProvider
    {
        public event EventHandler ValueChanged;
        private float _value = 0;
        public float Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    if( ValueChanged != null )
                        ValueChanged(this, new EventArgs());
                }
            }
        }
    }
}
