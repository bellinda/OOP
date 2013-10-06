using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace _4.VersionAttribute
{
    [Version("1.7")]
    class VersionAttributeTest
    {
        [Version("1.8")]
        enum MyTestingEnum { }

        [Version("1.9")]
        enum SecondTry { }

        [Version("5.10")]
        public static void Try()
        {
        }

        [Version("1.12")]
        static void Main()
        {
            Type type = typeof(VersionAttributeTest);

            //version of the classes:
            object[] allAttributes = type.GetCustomAttributes(false);
            foreach (VersionAttribute attribute in allAttributes)
            {
                Console.WriteLine("Version of the class: {0}", attribute.Version);
            }

            //version of the methods:
            MethodInfo[] methods = type.GetMethods(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (MethodInfo method in methods)
            {
                object[] methodAttr = method.GetCustomAttributes(false);
                Console.WriteLine("Method {0} has version {1}", method.Name, (methodAttr[0] as VersionAttribute).Version);
            }

            //version of the enumarations:
            Type[] enumType = type.GetNestedTypes(BindingFlags.NonPublic);
            foreach (var enumAttr in enumType)
            {
                object[] enumCustomAttributes = enumAttr.GetCustomAttributes(false);
                Console.WriteLine("Enumerations {0} - version {1}", enumAttr.Name, (enumCustomAttributes[0] as VersionAttribute).Version);
            }
        }
    }
}