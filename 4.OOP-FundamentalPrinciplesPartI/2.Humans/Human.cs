using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Humans
{
    public abstract class Human : IComparable<Human>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int CompareTo(Human other)
        {
            return this.FirstName.CompareTo(other.FirstName);
        }
    }
}
