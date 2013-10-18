using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Humans
{
    public class TestingHierarchy
    {
        static void Main()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student("Petar", "Nikolov", 6.00f));
            students.Add(new Student("Metodi", "Ivanchev", 3.75f));
            students.Add(new Student("Amelia", "Dimitrova", 4.52f));
            students.Add(new Student("Monika", "Mihailova", 5.25f));
            students.Add(new Student("Asen", "Dimitrov", 2.99f));
            students.Add(new Student("Kamelia", "Todorova", 4.68f));
            students.Add(new Student("Branimir", "Nikolov", 5.90f));
            students.Add(new Student("Mirela", "Andonova", 4.83f));
            students.Add(new Student("Dominika", "Valkanova", 3.33f));
            students.Add(new Student("Atanas", "Ivalinov", 5.67f));

            var sortedByGrade =
                from currStudent in students
                orderby currStudent.Grade
                select currStudent;
            Console.WriteLine("-------SORTED BY GRADE-------");
            foreach (Student student in sortedByGrade)
            {
                Console.WriteLine("{0} {1}, grade: {2}", student.FirstName, student.LastName, student.Grade);
            }

            List<Worker> workers = new List<Worker>();
            workers.Add(new Worker("Angel", "Metodiev", 200.50, 8));
            workers.Add(new Worker("Todor", "Skrimov", 250.73, 10));
            workers.Add(new Worker("Mariya", "Yankova", 150, 4));
            workers.Add(new Worker("Bilqna", "Madzharova", 200, 5));
            workers.Add(new Worker("Tedi", "Boneva", 132.99, 5));
            workers.Add(new Worker("Simona", "Ivanova", 315, 10));
            workers.Add(new Worker("Tihomir", "Vasilev", 223.75, 6));
            workers.Add(new Worker("Filip", "Todorov", 135.20, 4));
            workers.Add(new Worker("Mariya", "Antonova", 77.50, 4));
            workers.Add(new Worker("Ana-Mariya", "Stefanova", 112.01, 5));
            var sortedByMoneyPerHour =
                from worker in workers
                orderby worker.MoneyPerHour() descending
                select worker;
            Console.WriteLine();
            Console.WriteLine("-------SORTED BY MONEY PER HOUR-------");
            foreach (Worker worker in sortedByMoneyPerHour)
            {
                Console.WriteLine("{0} {1}, money per hour: {2}", worker.FirstName, worker.LastName, worker.MoneyPerHour());
            }
            Console.WriteLine();
            Console.WriteLine("-------SORTED BY NAME-------");
            List<dynamic> mergedLists = new List<dynamic>();
            foreach (Student item in students)
            {
                mergedLists.Add(item);
            }
            foreach (Worker item in workers)
            {
                mergedLists.Add(item);
            }

            var sortedByName =
                from person in mergedLists
                orderby person.FirstName, person.LastName
                select person;

            foreach (var person in sortedByName)
            {
                Console.WriteLine("{0} {1}", person.FirstName, person.LastName);
            }

        }
    }
}
