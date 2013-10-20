﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.Shapes
{
    public abstract class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public abstract double CalculateSurface();
    }
}
