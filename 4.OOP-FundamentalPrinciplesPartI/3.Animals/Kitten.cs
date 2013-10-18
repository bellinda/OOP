using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age, string sex, string breed)
            : base(name, age, "female", breed)
        {
        }

        public void Purr()
        {
            Console.WriteLine("I'm soOoOo sweet. Just hug me!");
        }

    }
}
