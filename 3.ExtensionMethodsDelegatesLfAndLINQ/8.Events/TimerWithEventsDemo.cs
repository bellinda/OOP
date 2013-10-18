using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _8.Events
{
    public class TimerWithEventsDemo
    {
        private static void Timer_ChangedTime(object sender, ChangedTimeEventArgs eventArgs)
        {
            Console.WriteLine("Timer! Ticks left = {0}", eventArgs.TicksLeft);
        }

        public static void Main()
        {
            Console.WriteLine("Timer will remind you for itself every 9 seconds:");
            Console.WriteLine();
            Console.Write("How many times do you want to see the appearance of the timer? ");
            int times = int.Parse(Console.ReadLine());
            Timer timer = new Timer(times, 9000);
            timer.ChangedTime += new ChangedTimeEventHandler(Timer_ChangedTime);
            timer.Run();
        }
    }
}
