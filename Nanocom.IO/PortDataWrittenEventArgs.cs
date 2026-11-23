using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nanocom.IO
{
    public class PortDataWrittenEventArgs : System.EventArgs
    {
        public enum DataType : int { Timeout = 0,BytesWritten = 1, Exception = -1 };
        private DataType _eventType;
        private byte[] _buffer;
        private int _offset;
        private int _count;
        private System.Exception _exception;
        public PortDataWrittenEventArgs(byte[] buffer_, int offset_, int count_) 
        {
            _eventType = DataType.Timeout;
            _buffer = buffer_;
            _offset = offset_;
            _count = count_;
            _exception = null;
        }
        public byte[] Buffer
        {
            get
            {
                return _buffer;
            }
            set
            {
                _buffer = value;
            }
        }
        public DataType EventType
        {
            get
            {
                return _eventType;
            }
            set
            {
                _eventType = value;
            }
        }

        public int Offset
        {
            get
            {
                return _offset;
            }
            set
            {
                _offset = value;
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
            }
        }

        public System.Exception Exception
        {
            get
            {
                return _exception;
            }
            set
            {
                _exception = value;
            }
        }
    }
}
