using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.SchoolSystem
{
    public class Subject : ICommentable
    {
        private string name;
        private int numberLectures;
        private int numberExercises;
        private string comments;

        public Subject(string name, int numberLectures, int numberExercises)
        {
            this.name = name;
            this.numberLectures = numberLectures;
            this.numberExercises = numberExercises;
        }

        public string Name
        {
            get { return this.name; }  //you are not allowed to change the name of the subject later
        }

        public int NumberLectures
        {
            get { return this.numberLectures; }
        }

        public int NumberExercises
        {
            get { return this.numberExercises; }
        }

        public void AddComments(string comments)
        {
            this.comments = comments;
        }
    }
}
