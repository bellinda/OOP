using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.SubstringImplementation
{
    class SubstringImplementationTest
    {
        static void Main()
        {
            StringBuilder test = new StringBuilder();
            test.Append("I am an idiot and can't understand the delegates.");
            Console.WriteLine(test.Substring(8, 5));
        }
    }
}
