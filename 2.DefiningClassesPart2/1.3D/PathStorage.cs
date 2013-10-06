using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _1._3D
{
    public static class PathStorage
    {
        public static void SavePaths(Point3D p1)
        {
            StreamWriter textFile = new StreamWriter("textFile.txt");
            using (textFile)
            {
                textFile.WriteLine(p1);
            }
        }

        public static StringBuilder LoadPaths()
        {
            StringBuilder output = new StringBuilder();
            StreamReader textFile = new StreamReader("textFile.txt");
            using (textFile)
            {
                string line = textFile.ReadLine();
                while (line != null)
                {
                    output.Append(line);
                    line = textFile.ReadLine();
                }
            }
            return output;
        }
    }
}
