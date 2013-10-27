using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.PersonWithToString
{
    public class Person
    {
        private string name;
        private byte? age;

        public Person(string name, byte? age = null)
        {
            this.name = name;
            this.age = age;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public byte? Age
        {
            get { return this.age; }
            set
            {
                if (value > 0 && value < 120)
                {
                    this.age = value;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(String.Format("Name: {0}, ", this.Name));
            if (this.Age != null)
            {
                str.Append(String.Format("Age: {0}", this.Age));
            }
            else
            {
                str.Append("Age: not specified");
            }
            return str.ToString();
        }
    }
}
