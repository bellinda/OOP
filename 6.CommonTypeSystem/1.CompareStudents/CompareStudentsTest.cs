using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.CompareStudents
{
    class CompareStudentsTest 
    {
        static void Main()
        {
            Student student1 = new Student("Mihail", "Georgiev", "Tomov", "600NM900L", "Varna 9000, Bul. \"Vitosha\", 21", 359885666333, "mihail.g.t@abv.bg", "first", Speciality.BusinessManagement, University.FreeUniversityOfBerlin, Faculty.FacultyOfLaw);
            Student student2 = new Student("Ivan", "Borisov", "Manolev", "2006M4K23", "Shumen 9700, Bul. \"Simeon Veliki\", 113", 359898502033, "ivan.b.m@abv.bg", "second", Speciality.ComputerScience, University.SofiaUniversity, Faculty.FacultyOfInformatics);
            Student student3 = student1;
            Student student4 = new Student();
            student4.FirstName = "Ivan";
            student4.MiddleName = "Borisov";
            student4.LastName = "Angelov";
            if (student1 != student2)
            {
                Console.WriteLine("Student1 and Student2 are not equal.");
            }
            if (student3 == student1)
            {
                Console.WriteLine("Students 1 and 3 are equal.");
            }
            if (Student.Equals(student1, student3))
            {
                Console.WriteLine("The overriden method Equals() is working correctly.");
            }
            if (Student.Equals(student3, student4))
            {
                Console.WriteLine("Students 3 and 4 are equal.");
            }
            Console.WriteLine(student2);

            Student clonedStudent = student4.Clone();
            clonedStudent.Email = "new_mail@gmail.com";
            Console.WriteLine("\n----- Is the copy deep? (changes on the copy don't change the original?) ----");
            Console.WriteLine("Student4: {0}\n", student4);
            Console.WriteLine("Cloned student: {0}\n", clonedStudent);
            Console.WriteLine(student1.CompareTo(student3));
            Console.WriteLine(student2.CompareTo(student4));
        }
        
    }
}
