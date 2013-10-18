/*Write a program that prints from given array of integers all numbers that are divisible by 7 and 3. 
Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6.DivisibleInts2Ways
{
    class DivisibleInts2Ways
    {
        static void Main()
        {
            int[] numbers = new int[] { 10, 3, 63, 18, 21, 42, 17, 7, 19 };
            var selected = numbers.Where((x) => (x % 7 == 0 && x % 3 == 0));
            Console.WriteLine("Find the numbers, that are divisible by 7 and 3 at the same time, with extension methods:");
            foreach (var num in selected)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine("Find the numbers, that are divisible by 7 and 3 at the same time, with LINQ:");
            var divisible =
                from num in numbers
                where (num % 7 == 0 && num % 3 == 0)
                select num;
            foreach (var num in divisible)
            {
                Console.WriteLine(num);
            }
        }
    }
}
