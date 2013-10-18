//Using delegates write a class Timer that has can execute certain method each t seconds.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace _7.Timer
{
    public delegate void MyDelegate(string param);

    public class Timer
    {
        public static Stopwatch myWatch = new Stopwatch();
        private MyDelegate del;

        public Timer(MyDelegate del)
        {
            this.del = del;
        }

        public void Run()
        {
            while (true)
            {
                Thread.Sleep(9000);
                del("testing");
            }
        }

        static void CertainMethod(string param)
        {
            Console.WriteLine("I am a simple method. I have no real functions, but I appeare every 9 second with my parameter \"{0}\".", param);
        }

        static void Main()
        {
            MyDelegate helpingDel = CertainMethod;
            Timer test = new Timer(helpingDel);
            test.Run();
        }
    }
}

