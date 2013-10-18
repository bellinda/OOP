using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.SchoolSystem
{
    public class People : ICommentable
    {
        private string name;
        private string comment;

        public People(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public void AddComments(string comment)
        {
            this.comment = comment;
        }
    }
}
