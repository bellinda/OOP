using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.SchoolSystem
{
    public class Student : People
    {
        private int classNumber;

        public Student(string name, int classNumber)
            : base(name)
        {
            this.classNumber = classNumber;
        }

        public int ClassNumber
        {
            get { return this.classNumber; }
            set { this.classNumber = value; }
        }
    }
}
