using System;
using System.Text;

namespace Nanocom.Control
{
    public class Frame
    {
        public enum Type : byte 
        {
            None = (byte)' ',
            Init = (byte)'C',
            Box  = (byte)'B', 
            ObjectData = (byte)'D',
            StatusReq = (byte)'S',
            StatusAnswer = (byte)'A',
            ObjectReq = (byte)'R',
            ObjectAnswer = (byte)'O',
            FileExport = (byte)'E',
            FileReq = (byte)'F',
            FileImport = (byte)'I',
            StandbyReset = (byte)'Y',
            Error = (byte)'X',
            ListData = (byte)'L',
            TextData = (byte)'T',
            Ok = (byte)'K',
            Hallo = (byte)'H',
            FileSetName = (byte)'N',
            FileGetName = (byte)'G',
            ProgressData = (byte)'P',
            BoxReset = (byte)'Z',
            SetPage = (byte)'J',
            TextReport = (byte)'W'
        }
        private Type _type;
        private byte _number;
        private byte [] _buffer;
        private byte _len;

        public Frame( Type type_) : this(type_, 0) { }
        public Frame( Type type_, byte number_)
        {
            _type = type_;
            _number = number_;
            _buffer = new byte[250];
            _len = 0;
        }
        public Type TypeID
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public byte Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
            }
        }

        public byte BufferLength
        {
            get
            {
                return _len;
            }
        }
        public string Text()
        {
            return Text( 0 );
        }
        public string Text( int offset_ )
        {
            return Text( offset_, -1 );
        }
        public string Text(int offset_, int length_)
        {
            int len = length_;
            if( len < 0 )
            {
                if( len == -1 )
                {
                    len = BufferLength;
                }
                else
                {   
                    int max = BufferLength;
                    len = 0;      
                    for( int idx = offset_; len < max; idx++ )
                    {
                        if( _buffer[idx]==(char)'^' )
                            break;
                        else
                            len++;
                    }
                }
            }
            return System.Text.Encoding.ASCII.GetString(_buffer, offset_, len);
        }
        public byte[] Buffer
        {
            get
            {
                return _buffer;
            }
            set
            {
                int len = _buffer.Length;
                if (len > 250)
                    throw new ArgumentOutOfRangeException("Buffer length",len,"must be from [0..250]");
                _buffer = value;
            }
        }
        public void AddByte( byte byte_ )
        {
            if (_len < 250)
            {
                _buffer[_len] = byte_;
                _len++;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Buffer full");
            }
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder(256);
            str.Append('"');
            str.Append(Enum.GetName(typeof(Type), TypeID));
            str.Append('"');
            str.Append(':');
            str.Append( Number.ToString() );
            str.Append(':');
            str.Append( BufferLength.ToString());
            str.Append(" Byte(s):");
            switch (TypeID)
            {
            case Type.Init:
                break;
            case Type.Box:
                str.Append(Text(0,1));
                str.Append(':');
                str.Append(Text(1,-2)); 
                break;
            case Type.ObjectData:
                str.Append(Buffer[0].ToString("X2"));
                str.Append(' ');
                str.Append(Buffer[1].ToString("X2"));
                str.Append(':');
                str.Append(Text(2, -2));
                break;
            case Type.StatusAnswer:
                str.Append(Buffer[0].ToString("X2"));
                str.Append(':');
                str.Append(Buffer[1].ToString("X2"));
                str.Append(':');
                str.Append(Buffer[2].ToString("X2"));
                break;
            case Type.StatusReq:
            case Type.ObjectReq:
            case Type.ObjectAnswer:
            case Type.FileExport: 
            case Type.FileReq:
            case Type.FileImport:
            case Type.StandbyReset:
            case Type.Error:
            case Type.ListData:
            case Type.TextData:
            case Type.Ok:
            case Type.Hallo:
            case Type.FileSetName:
            case Type.FileGetName:
            case Type.ProgressData:
            case Type.BoxReset:
            case Type.SetPage:
            case Type.TextReport:
                break;
            }
            return str.ToString();
        }
    }
}
