using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace _3.InvalidRangeException
{
    class TestingInvalidRangeExceptions
    {
        static void Main()
        {
            GetInteger();

            GetDate();
        }

        private static void GetInteger()
        {
            try
            {
                int min = 0;
                int max = 100;
                Console.Write("Enter a number: ");
                string temp = Console.ReadLine();
                int result;
                if (Int32.TryParse(temp, out result) == false)
                {
                    throw new InvalidRangeException<int>("Number is not in range.", min, max);
                }
                else
                {
                    int num = int.Parse(Console.ReadLine());
                    if (num < min || num > max)
                    {
                        throw new InvalidRangeException<int>("Number is not in range.", min, max);
                    }
                }
            }
            catch (InvalidRangeException<int> ire)
            {
                Console.WriteLine("{0} Range of current type: [{1}; {2}]", ire.Message, ire.MinValue, ire.MaxValue);
            }
        }

        public static void GetDate()
        {
            try
            {
                Console.Write("Enter a date: ");
                DateTime min = new DateTime(1980, 1, 1);
                DateTime max = new DateTime(2013, 12, 31);
                CultureInfo provider = CultureInfo.InvariantCulture;
                DateTime date = DateTime.Parse(Console.ReadLine());
                if (date < min || date > max)
                {
                    throw new InvalidRangeException<DateTime>("Date is not valid.", min, max);
                }
            }
            catch (InvalidRangeException<DateTime> ire)
            {
                Console.WriteLine("{0} Range of current type: [{1}; {2}]", ire.Message, ire.MinValue, ire.MaxValue);
            }
        }
    }
}
