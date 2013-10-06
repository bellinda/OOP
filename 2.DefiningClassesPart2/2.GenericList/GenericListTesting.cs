using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.GenericList
{
    class GenericListTesting
    {
        static void Main()
        {
            GenericList<int> el = new GenericList<int>(5);
            el.Add(23);
            el.Add(15);
            Console.WriteLine("Element at position 0 in the list \"el\" is {0}.", el[0]);
            el.InsertAt(1, 77);
            Console.WriteLine("Minimal element in the array with integers = {0}.", GenericList<int>.Min<int>(el));
            Console.WriteLine("Maximal element in the array of integers = {0}.", GenericList<int>.Max<int>(el));
            el.Clear();
            Console.WriteLine(el.ToString());
            GenericList<string> test = new GenericList<string>(2);
            test.Add("Pesho");
            test.Add("is");
            test.InsertAt(1, "who");
            test.Add("a");
            test.Add("cool");
            test.Add("boy");
            Console.WriteLine("Element at position 1 in the list \"test\" is {0}.", test.ElementAt(1));
            Console.WriteLine("Element at position 1 in the list \"test\" is {0}.", test[1]);
            test.RemoveAt(0);
            Console.WriteLine(test.Count);
            test.InsertAt(0, "Pesho");
            Console.WriteLine("The element \"cool\" of the list \"test\" has index {0}", test.IndexOf("cool"));
            Console.WriteLine(test.IndexOf("test"));
            Console.WriteLine(test.ToString());
            Console.WriteLine("Minimal element in the array of strings = {0}.", GenericList<string>.Min<string>(test));
            Console.WriteLine("Maximal element in the array of strings = {0}.", GenericList<string>.Max<string>(test));
        }
    }
}
