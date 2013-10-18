using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4.StudentsBetween18And24
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }

    class StudentsBetween18And24
    {
        static void Main()
        {
            var students = new Student[]
            {
                new Student{FirstName = "Angel", LastName="Ivanov", Age = 19},
                new Student{FirstName = "Teodor", LastName = "Marinov", Age = 17},
                new Student{FirstName = "Georgi", LastName = "Seganov", Age = 21},
                new Student{FirstName = "Nikolay", LastName = "Penchev", Age = 21},
                new Student{FirstName = "Borqna", LastName = "Vasileva", Age = 25},
                new Student{FirstName = "Chono", LastName = "Penchev", Age = 20},
                new Student{FirstName = "Diana", LastName = "Angelova", Age = 33},
                new Student{FirstName = "Elitsa", LastName = "Stoqnova", Age = 24},
                new Student{FirstName = "Aleksandar", LastName = "Marinov", Age = 56}
            };

            var studentsInBoundary =
                from student in students
                where (student.Age >= 18 && student.Age <= 24)
                select student;
            foreach (var student in studentsInBoundary)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }
    }
}
