using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age, string sex, string breed)
            : base(name, age, "male", breed)
        {
        }

        public void FindAMouse()
        {
            Console.WriteLine("I'll find you and you'll be eaten!");
        }

    }
}
