using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5.SortingStudents2Ways
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    class SortingStudents2Ways
    {
        static void Main()
        {
            var students = new Student[]
            {
                new Student{FirstName = "Angel", LastName="Ivanov", Age = 19},
                new Student{FirstName = "Teodor", LastName = "Marinov", Age = 17},
                new Student{FirstName = "Georgi", LastName = "Seganov", Age = 21},
                new Student{FirstName = "Nikolay", LastName = "Penchev", Age = 21},
                new Student{FirstName = "Boryana", LastName = "Ljubenova", Age = 25},
                new Student{FirstName = "Chono", LastName = "Penchev", Age = 20},
                new Student{FirstName = "Diana", LastName = "Angelova", Age = 33},
                new Student{FirstName = "Elitsa", LastName = "Stoqnova", Age = 24},
                new Student{FirstName = "Aleksandar", LastName = "Marinov", Age = 56},
                new Student{FirstName = "Boryana", LastName = "Vasileva", Age = 23}
            };

            var ordered = students.OrderByDescending((x) => x.FirstName).ThenByDescending((x) => x.LastName);
            Console.WriteLine("Students ordered by the extension methods OrderBy() and ThenBy():");
            foreach (var student in ordered)
            {
                Console.WriteLine("{0} {1}, Age: {2}", student.FirstName, student.LastName, student.Age);
            }

            var secondOrder =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;

            Console.WriteLine();
            Console.WriteLine("Students ordered by LINQ query:");
            foreach (var student in secondOrder)
            {
                Console.WriteLine("{0} {1}, Age: {2}", student.FirstName, student.LastName, student.Age);
            }
        }
    }
}
