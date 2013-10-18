using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.ExtensionMethodsIEnumerable
{
    public static class ExtentionMethodsIEnumerable
    {
        public static T Min<T>(this IEnumerable<T> enumeration)
            where T: IComparable
        {
            T min = default(T);
            foreach (T item in enumeration)
            {
                min = item;
                break;
            }
            foreach (T item in enumeration)
            {
                if (min.CompareTo(item) > 0)
                {
                    min = item;
                }
            }
            return min;
        }

        public static T Max<T>(this IEnumerable<T> enumeration)
            where T: IComparable
        {
            T max = default(T);
            foreach (T item in enumeration)
            {
                max = item;
                break;
            }
            foreach (T item in enumeration)
            {
                if (max.CompareTo(item) < 1)
                {
                    max = item;
                }
            }
            return max;
        }

        public static T SumNumbers<T>(this IEnumerable<T> enumeration)
            where T: IComparable
        {
            T sum = default(T);
            foreach (T item in enumeration)
            {
                sum = (T)Convert.ChangeType(Convert.ToDecimal(sum) + Convert.ToDecimal(item), typeof(T));
            }
            return sum;
        }

        public static T SumStrings<T>(this IEnumerable<T> enumeration)
            where T: IComparable
        {
            T sum = default(T);
            foreach (T item in enumeration)
            {
                sum = (T)Convert.ChangeType(Convert.ToString(sum) + Convert.ToString(item), typeof(T));
            }
            return sum;
        }

        public static T AverageOfNumbers<T>(this IEnumerable<T> enumeration)
            where T: IComparable
        {
            T sum = default(T);
            foreach (T item in enumeration)
            {
                sum = (dynamic)sum + item;
            }
            T average = (dynamic)sum / enumeration.Count();
            return average;
        }

        public static T Product<T>(this IEnumerable<T> enumeration)
            where T: IComparable
        {
            T product = default(T);
            T first = default(T);
            foreach (T item in enumeration)
            {
                product = item;
                first = item;
                break;
            }
            foreach (T item in enumeration)
            {
                product = (dynamic)product * item;
            }
            product = (dynamic)product / first;
            return product;
        }
    }
}
