using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1._3D
{
    class Point3DTesting
    {
        static void Main()
        {
            Point3D point1 = new Point3D(1, 3, 5);
            Point3D point2 = Point3D.StartOfTheCoordSystem;
            Console.WriteLine(point1);
            Console.WriteLine(point2);
            Console.WriteLine(CalcDistance.CalculateDistance(point1, point2));
            PathStorage.SavePaths(point1);
            Console.WriteLine(PathStorage.LoadPaths());
        }
    }
}
