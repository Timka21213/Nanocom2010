
namespace Nanocom.IO
{
    public class PortName : System.EventArgs
    {
        private string _portName;
        public PortName( string portName_ )
        {
            _portName = portName_;
        }
        public string portName
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
    }
}
