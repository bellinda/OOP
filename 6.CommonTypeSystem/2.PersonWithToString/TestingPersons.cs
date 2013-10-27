using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.PersonWithToString
{
    class TestingPersons
    {
        static void Main()
        {
            Person person1 = new Person("Kaloyan Yanakiev");
            Console.WriteLine(person1);
            Person person2 = new Person("Maria Hainova", 21);
            Console.WriteLine(person2);
        }
    }
}
