using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8.Events
{
    public class ChangedTimeEventArgs : EventArgs
    {
        private int ticksLeft;

        public ChangedTimeEventArgs(int ticksLeft)
        {
            this.ticksLeft = ticksLeft;
        }
        public int TicksLeft
        {
            get { return this.ticksLeft; }
        }
    }
}
