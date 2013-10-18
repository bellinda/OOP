using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.SubstringImplementation
{
    public static class AddingSubstring
    {
        public static StringBuilder Substring(this StringBuilder str, int index, int length)
        {
            StringBuilder newStr = new StringBuilder();
            newStr.Append(str.ToString().Substring(index, length));
            return newStr;
        }
    }
}
