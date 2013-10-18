using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.Animals
{
    public class Dog : Animal
    {
        private string breed;

        public Dog(string name, int age, string sex, string breed)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
            this.breed = breed;
        }

        public string Breed
        {
            get { return this.breed; }
            set { this.breed = value; }
        }

        public override void MakeSound()
        {
            Console.WriteLine("Bau-bau!");
        }

        public override string ToString()
        {
            return String.Format("I am a {0} dog and my name is{1}. My breed is {2}. My age is {3}.", this.Sex, this.Name, this.Breed, this.Age);
        }
    }
}
