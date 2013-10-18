using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.Animals
{
    public abstract class Animal : ISound
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }

        public abstract void MakeSound();

        public static int AverageAge(Animal[] animals)
        {
            int sumOfAges = 0;
            foreach (var animal in animals)
            {
                sumOfAges += animal.Age;
            }
            int averageAge = sumOfAges / animals.Length;
            return averageAge;
        }
    }
}
