//Write a method that from a given array of students finds all students whose first name is before its last name alphabetically. Use LINQ query operators. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.FirstNameBeforeLastName
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    class FirstNameLastName
    {
        static void Main()
        {
            var students = new Student[] 
            {
                new Student {FirstName = "Pesho", LastName = "Nikolov"},
                new Student {FirstName = "Gosho", LastName = "Petrov"},
                new Student {FirstName = "Mirela", LastName = "Dimitrova"},
                new Student {FirstName = "Albena", LastName = "Angelova"}
            };

            var selectedStudents =
                from student in students
                where student.FirstName.CompareTo(student.LastName) < 0
                select student;
            foreach (var student in selectedStudents)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }
    }
}
