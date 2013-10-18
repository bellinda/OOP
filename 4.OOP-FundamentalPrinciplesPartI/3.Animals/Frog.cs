using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.Animals
{
    public class Frog : Animal
    {
        public int JumpHight { get; set; }

        public Frog(string name, int age, string sex, int jumpHight)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
            this.JumpHight = jumpHight;
        }

        public override void MakeSound()
        {
            Console.WriteLine("Quack, quack!");
        }

        public override string ToString()
        {
            return String.Format("I am a {0} frog. My name is {1}. I'm {2} years old and I can jump to a hight of {3} meters.", this.Sex, this.Name, this.Age, this.JumpHight);
        }

        public void Jump()
        {
            Console.WriteLine("Wait a second, I'm jumping now!");
        }
    }
}
