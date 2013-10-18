using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.SchoolSystem
{
    public class Class : ICommentable
    {
        private string textIdentificator;
        private List<Student> students;
        private List<Teacher> teachers;
        private string comments;

        public Class(string textIdentificator, List<Student> students, List<Teacher> teachers)
        {
            this.textIdentificator = textIdentificator;
            this.students = students;
            this.teachers = teachers;
        }

        public Class(string textIdentificator)
            : this(textIdentificator, new List<Student>(), new List<Teacher>())
        {
        }

        public string TextIdentificator
        {
            get { return this.textIdentificator; }
            set { this.textIdentificator = value; }
        }

        public List<Student> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public List<Teacher> Teachers
        {
            get { return this.teachers; }
            set { this.teachers = value; }
        }

        public void AddComments(string comments)
        {
            this.comments = comments;
        }
    }
}
