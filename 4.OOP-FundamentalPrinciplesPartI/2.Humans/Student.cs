using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Humans
{
    public class Student : Human
    {
        private float grade;

        public Student(string firstName, string lastName, float grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.grade = grade;
        }

        public float Grade
        {
            get { return this.grade; }
            set { this.grade = value; }
        }
    }
}
