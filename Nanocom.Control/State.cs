using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nanocom.Control
{
    public class State
    {

        public virtual void EntryAction( Context ctx_ )
        {
        }

        public virtual void ExitAction(Context ctx_)
        {
        }

        public virtual void InternalTransition(Context ctx_)
        {
        }
    }
}
