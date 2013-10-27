using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.CompareStudents
{
    public class Student : ICloneable, IComparable<Student>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SSN { get; set; }
        public string PermAddress { get; set; }
        public long PhoneNum { get; set; }
        public string Email { get; set; }
        public string Course { get; set; }
        public Speciality Speciality { get; set; }
        public University University { get; set; }
        public Faculty Faculty { get; set; }

        public Student(string firstName, string middleName, string lastName, string ssn, string permAddress, long phoneNum, string email, string course, Speciality speaciality, University university, Faculty faculty)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.PermAddress = permAddress;
            this.PhoneNum = phoneNum;
            this.Email = email;
            this.Course = course;
            this.Speciality = speaciality;
            this.University = university;
            this.Faculty = faculty;
        }

        public Student()
            : this("", "", "", "", "", 0, "", "", Speciality.Communication, University.SofiaUniversity, Faculty.FacultyOfArts)
        {
        }

        public override bool Equals(object obj)
        {
            Student student = obj as Student;
            if (student == null)
            {
                return false;
            }
            if (!Object.Equals(this.FirstName, student.FirstName) || !Object.Equals(this.MiddleName, student.MiddleName) || !Object.Equals(this.LastName, student.LastName)
                || !Object.Equals(this.SSN, student.SSN) || !Object.Equals(this.PermAddress, student.PermAddress) || !Object.Equals(this.Email, student.Email)
                || !Object.Equals(this.Course, student.Course))
            {
                return false;
            }
            if (this.PhoneNum != student.PhoneNum || this.Speciality != student.Speciality || this.University != student.University || this.Faculty != student.Faculty)  //although in the reality one student can have more than one phone numbers
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() ^ LastName.GetHashCode();
        }

        public static bool operator ==(Student first, Student second)
        {
            return Student.Equals(first, second);
        }

        public static bool operator !=(Student first, Student second)
        {
            return !Student.Equals(first, second);
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2}, SSN: {3}, permanent address: {4}, phone number: {5}, email: {6}, course: {7}, speciality: {8}, university: {9}, faculty: {10}",
                this.FirstName, this.MiddleName, this.LastName, this.SSN, this.PermAddress, this.PhoneNum, this.Email, this.Course, this.Speciality, this.University, this.Faculty);
        }

        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Student Clone()
        {
            Student original = this;
            Student cloned = new Student(original.FirstName, original.MiddleName, original.LastName, original.SSN, original.PermAddress, original.PhoneNum, original.Email, original.Course, original.Speciality, original.University, original.Faculty);
            return cloned;
        }

        public int CompareTo(Student other)
        {
            if (this.FirstName != other.FirstName)
            {
                if (this.FirstName.CompareTo(other.FirstName) < 0)
                {
                    return -1;
                }
                else if (this.FirstName.CompareTo(other.FirstName) > 0)
                {
                    return 1;
                }
            }
            else if (this.FirstName == other.FirstName && this.MiddleName != other.MiddleName)
            {
                if (this.MiddleName.CompareTo(other.MiddleName) < 0)
                {
                    return -1;
                }
                else if (this.MiddleName.CompareTo(other.MiddleName) > 0)
                {
                    return 1;
                }
            }
            else if (this.FirstName == other.FirstName && this.MiddleName == other.MiddleName && this.LastName != other.LastName)
            {
                if (this.LastName.CompareTo(other.LastName) < 0)
                {
                    return -1;
                }
                else if (this.LastName.CompareTo(other.LastName) > 0)
                {
                    return 1;
                }
            }
            else if (this.FirstName == other.FirstName)
            {
                if (this.SSN.CompareTo(other.SSN) < 0)
                {
                    return -1;
                }
                else if (this.SSN.CompareTo(other.SSN) > 0)
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
