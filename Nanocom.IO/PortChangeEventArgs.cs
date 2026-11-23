
namespace Nanocom.IO
{
    public enum PortChange : int { Removed = 0, Arrival = 1 };
    public class PortChangeEventArgs : System.EventArgs
    {
        private PortChange _eventType;
        private string _portName;
        public PortChangeEventArgs( PortChange eventType_ ) : this( eventType_, null ) {}
        public PortChangeEventArgs( PortChange eventType_,  string portName_ )
        {
            _eventType = eventType_;
            _portName = portName_;
        }
        public string PortName
        {
            get
            {
                return _portName;
            }
            set
            {
                _portName = value;
            }
        }
        public PortChange EventType
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
    }
}
