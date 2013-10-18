using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.SchoolSystem
{
    public class Teacher : People
    {
        private List<Subject> subjects;
        private string comments;

        public Teacher(string name) : base(name)
        {
        }

        public Teacher(string name, List<Subject> subjects)
            : base(name)
        {
            this.subjects = subjects;
        }

        public List<Subject> Subjects
        {
            get { return this.subjects; }
            set { this.subjects = value; }
        }
    }
}
