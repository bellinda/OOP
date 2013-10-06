using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1._3D
{
    public struct Point3D
    {
        private static readonly Point3D startOfTheCoordSystem = new Point3D(0, 0, 0);

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public override string ToString()
        {
            return String.Format("3D point with coordinates: X = {0}, Y = {1}, Z = {2}", this.X, this.Y, this.Z);
        }

        public Point3D(int x, int y, int z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public static Point3D StartOfTheCoordSystem
        {
            get { return startOfTheCoordSystem; }
        }
    }
}
