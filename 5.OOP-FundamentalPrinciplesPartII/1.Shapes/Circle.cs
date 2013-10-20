using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.Shapes
{
    public class Circle : Shape
    {
        public Circle(double height, double width)
        {
            if (height == width)
            {
                this.Height = this.Width = height;
            }
            else
            {
                throw new ArgumentException("The values of height and width should be equal to each other and to the raduis of the circle!");
            }
        }
        public override double CalculateSurface()
        {
            return Math.PI * this.Height * this.Height;
        }
    }
}
