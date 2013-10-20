﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public override double CalculateSurface()
        {
            return this.Height * this.Width;
        }
    }
}
