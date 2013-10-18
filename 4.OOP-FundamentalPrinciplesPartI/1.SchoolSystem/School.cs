using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.SchoolSystem
{
    public class School
    {
        private List<Class> classes;

        public School(List<Class> classes)
        {
            this.classes = classes;
        }

        public List<Class> Classes
        {
            get { return this.classes; }
            set { this.classes = value; }
        }

        static void Main()
        {
            Student myStudent = new Student("Ivan Marianov", 17);
            Student myStudent2 = new Student("Petar Nikolov", 23);
            List<Student> students = new List<Student>();
            students.Add(myStudent);
            students.Add(myStudent2);
            List<Student> students2 = new List<Student>();
            students2.Add(new Student("Maria Asenova", 11));
            students2.Add(new Student("Angel Dobrev", 1));
            students2.Add(new Student("Teodor Tomov", 20));
            List<Subject> teacherSubjects = new List<Subject>();
            teacherSubjects.Add(new Subject("History", 30, 15));
            teacherSubjects.Add(new Subject("Mathe", 35, 50));
            Teacher myTeacher = new Teacher("Valentin Milanov", teacherSubjects);
            List<Teacher> teachers = new List<Teacher>();
            Class myClass = new Class("12g", students, teachers);
            Class myClass2 = new Class("12a", students2, teachers);
            List<Class> classes = new List<Class>()
            {
                myClass, myClass2
            };
            School mySchool = new School(classes);
        }
    }
}
