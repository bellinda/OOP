using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.Shapes
{
    class TestingShapes
    {
        static void Main()
        {
            Shape[] shapes = new Shape[]
            {
                new Triangle(3.2, 5.3),
                new Circle(5, 5),
                new Rectangle(2.5, 0.7),
                //new Circle(7, 7.1) with this line it won't be working, because height and width of the circle (equal to its radius) should be equal
            };

            foreach (Shape shape in shapes)
            {
                Console.WriteLine("{0}: {1}", shape.GetType().Name, shape.CalculateSurface());
            }
        }
    }
}
