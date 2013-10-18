using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace _3.Animals
{
    public class Cat : Animal
    {
        public string Breed { get; set; }

        public Cat(string name, int age, string sex, string breed)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
            this.Breed = breed;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Myauu-myauu!");
        }

        public override string ToString()
        {
            return String.Format("I am a {0} cat and my name is {1}. I am {2} years old and I am {3}.", this.Breed, this.Name, this.Age, this.Sex);
        }

        public void Sleep()
        {
            Console.WriteLine("Now I'm sleeping. Don't make noise, please!");
            Thread.Sleep(1000);
        }
    }
}
