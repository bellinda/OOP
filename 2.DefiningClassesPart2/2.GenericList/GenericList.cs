using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.GenericList
{
    public class GenericList<T>
    {
        private const int defaultCapacity = 3000;
        private T[] listOfElements;
        private int count = 0;

        public GenericList(int capacity)
        {
            listOfElements = new T[capacity];
        }

        public GenericList()
            : this(defaultCapacity)
        {
        }

        public int Count
        {
            get { return this.count; }
        }

        public void Add(T element)
        {
            if (count >= listOfElements.Length)
            {
                T[] newList = new T[count*2];
                for (int i = 0; i < this.Count; i++)
                {
                    newList[i] = this.listOfElements[i];
                }
                this.listOfElements = newList;
                //throw new IndexOutOfRangeException("Index is out of range!");
            }
            this.listOfElements[count] = element;
            count++;
        }

        public T this[int index]
        {
            get
            {
                if (index >= count)
                {
                    throw new IndexOutOfRangeException("The index outside of the arrays' boundaries! Try out with another one.");
                }
                return this.listOfElements[index];
            }
        }

        //or:
        public T ElementAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("You want to take an element that doesn't exist! Try with another index!");
            }
            return this.listOfElements[index];
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("You want to remove an element that doesn't exist! Try with another index!");
            }
            for (int i = index; i < this.Count - 1; i++)
            {
                this.listOfElements[i] = this.listOfElements[i + 1];
            }
            this.listOfElements[this.Count - 1] = default(T);
            count--;
        }

        public void InsertAt(int index, T element)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("You want to remove an element that doesn't exist! Try with another index!");
            }
            this.Add(default(T));
            for (int i = this.Count - 1; i > index; i--)
            {
                this.listOfElements[i] = this.listOfElements[i - 1];
            }
            this.listOfElements[index] = element;
        }

        public void Clear()
        {
            for (int i = 0; i < this.Count; i++)
            {
                this.listOfElements[i] = default(T);
            }
            count = 0;
        }

        public int IndexOf(T element)
        {
            bool found = false;
            int index = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.listOfElements[i].Equals(element))
                {
                    index = i;
                    found = true;
                }
            }
            if (found == true)
            {
                return index;
            }
            else
            {
                return -1;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(String.Format("Current list has {0} elements", this.Count));
            if (this.Count != 0)
            {
                output.Append(" and they are: ");
                foreach (T item in this.listOfElements)
                {
                    output.Append(item + " ");
                }
            }
            else
            {
                output.Append(".");
            }
            return output.ToString();
        }

        public static T Min<T>(GenericList<T> elements)
            where T: IComparable<T>
        {
            if (elements.Count != 0)
            {
                T min = elements[0];
                for (int i = 0; i < elements.Count; i++)
                {
                    if (min.CompareTo(elements[i]) > 0)
                    {
                        min = elements[i];
                    }
                }
                return min;
            }
            else
            {
                return default(T);
            }
        }

        public static T Max<T>(GenericList<T> elements)
            where T : IComparable<T>
        {
            if (elements.Count != 0)
            {
                T max = elements[0];
                for (int i = 0; i < elements.Count; i++)
                {
                    if (max.CompareTo(elements[i]) < 0)
                    {
                        max = elements[i];
                    }
                }
                return max;
            }
            else
            {
                return default(T);
            }
        }
    }
}
