//Read in MSDN about keyword event in C# and how to publish events. Re-implement the above using .NET events and following the best practices.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _8.Events
{
    public delegate void ChangedTimeEventHandler(object sender, ChangedTimeEventArgs eventArgs);
    
    public class Timer
    {
        private int tickCount;
        private int interval;

        public event ChangedTimeEventHandler ChangedTime;

        public Timer(int tickCount, int interval)
        {
            this.tickCount = tickCount;
            this.interval = interval;
        }

        public int TickCount
        {
            get { return tickCount; }
        }

        public int Interval
        {
            get { return interval; }
        }

        protected void OnChangedTime(int tick)
        {
            if (ChangedTime != null)
            {
                ChangedTimeEventArgs args = new ChangedTimeEventArgs(tick);
                ChangedTime(this, args);
            }
        }

        public void Run()
        {
            int tick = tickCount;
            while (tick > 0)
            {
                Thread.Sleep(interval);
                tick--;
                OnChangedTime(tick);
            }
        }
        
    }
}
