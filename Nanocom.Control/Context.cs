using System;

namespace Nanocom.Control
{
    public class Context
    {
        private State _currentState;

        protected Context( State start_ )
        {
            _currentState = start_;
        }
        public State CurrentState()
        {
                return _currentState;
        }

        internal void ChangeState( State newState_ )
        {
            if (_currentState == newState_)
            {
                _currentState.InternalTransition(this);
            }
            else
            {
                _currentState.ExitAction(this);
                _currentState = newState_;
                newState_.EntryAction(this);
            }
        }
    }
}
