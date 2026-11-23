using System;

namespace Nanocom.Control
{
    /// <summary>
    /// Adds and removes transport protokoll informations to the data frame.
    /// </summary>
    public class FrameProtocol
    {
        const byte StartFrame = 10;
        /// <summary>
        /// adds a header and a trailing chechsum to the frame
        /// </summary>
        /// <param name="frame_"></param>
        /// <returns></returns>
        public static byte[] Encode(Frame frame_)
        {
            int bufferLen = frame_.BufferLength;
            if( bufferLen+3>255)
                bufferLen = 252;
            byte[] result = new byte[bufferLen + 6];
            result[0] = 0;
            result[1] = StartFrame;
            result[2] = (byte)( bufferLen + 2 );
            result[3] = (byte)frame_.TypeID;
            result[4] = frame_.Number;
            System.Buffer.BlockCopy(frame_.Buffer, 0, result, 5, bufferLen);
            byte checksum = 0;
            int nBytes = bufferLen + 3;
            const int startIndex = 2;
            int endIndex = nBytes + startIndex;
            for (int i = startIndex; i < endIndex; i++)
                checksum += result[i];
            result[bufferLen+5] = checksum;            
            return result;
        }

        private int _state;

        public void Reset()
        {

            _decoded = null;
            _state = 0;
        }
        private Frame _decoded;
        private byte _len;
        private byte _bytesToRead;
        private byte _checkSum;
        public Frame Decode(byte new_)
        {
            Frame result = null;
            switch (_state)
            {
            case 0: // frame marker
                 if (new_ == 0) _state++;
                 break;
            case 1: // frame stx
                 if (new_ == StartFrame) _state++; else _state = 0;
                 break;
            case 2: // length
                 _len = new_;
                 _checkSum = new_;
                 _state++;
                 break;
            case 3: // Type
                _decoded = new Frame( (Frame.Type)new_ );
                _checkSum += new_;
                _state++;
                break;
            case 4: // seq Number
                _decoded.Number = new_;
                _checkSum += new_;
                if( _len == 255 )
                {
                    _bytesToRead = 0;
                    _state = 6;
                }
                else if (_len < 2)
                {
                    _state = 0;
                }
                else
                {
                    _bytesToRead = (byte)(_len-2);
                    _state = _bytesToRead > 0 ? 5 : 6;
                }
                break;
            case 5: // data bytes
                _decoded.AddByte( new_ );
                _checkSum += new_;
                if( --_bytesToRead == 0 )
                    _state=6;
                break;
            case 6: // check sum
                _state = 0;
                result = _decoded;
                if (_checkSum != new_)
                    throw new ArgumentOutOfRangeException("Invalid check sum", new_, _checkSum.ToString());
                break;
            }
            if( result != null )
                _decoded = null;
            return result;
        }
    }
}
