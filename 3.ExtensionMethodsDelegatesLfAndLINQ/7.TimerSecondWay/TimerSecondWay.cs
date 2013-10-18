using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace _7.TimerSecondWay
{
    public delegate void MyDelegate(string param);

    public class Timer
    {
        public static Stopwatch myWatch = new Stopwatch();

        static void CertainMethod(string param)
        {
            Console.WriteLine("I am a simple method. I have no real functions, but I appeare every 9 second with my parameter \"{0}\".", param);
        }
        static void Main()
        {
            MyDelegate del = new MyDelegate(CertainMethod);
            Timer.myWatch.Start();
            while (true)
            {
                if (Timer.myWatch.ElapsedMilliseconds == 9000)
                {
                    del("testing");
                    Timer.myWatch.Restart();
                }
            }
        }
    }
}