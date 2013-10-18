using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.ExtensionMethodsIEnumerable
{
    class ExtentionMethodsTest
    {
        static void Main()
        {
            List<float> testList = new List<float>();
            testList.Add(3.2f);
            testList.Add(0.57f);
            testList.Add(1.7f);
            Console.WriteLine(testList.Min<float>());
            Console.WriteLine(testList.Max<float>());
            Console.WriteLine(testList.SumNumbers<float>());
            Console.WriteLine(testList.AverageOfNumbers<float>());
            Console.WriteLine(testList.Product<float>());
            List<string> stringList = new List<string>() { "Pesho", "Gosho", "Bobi" };
            Console.WriteLine(stringList.Min<string>());
            Console.WriteLine(stringList.Max<string>());
            Console.WriteLine(stringList.SumStrings<string>());
        }
    }
}
