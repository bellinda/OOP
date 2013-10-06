using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GSM
{
    public class Display
    {
        private float size;
        private int numberOfColors;

        public Display() : this(0, 0)
        {
        }

        public Display(float size) : this(size, 0)
        {
        }

        public Display(float size, int numberOfColors)
        {
            this.size = size;
            this.numberOfColors = numberOfColors;
        }

        public float Size
        {
            get { return this.size; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Negative size!");
                }
                this.size = value; 
            }
        }

        public int NumberOfColors
        {
            get { return this.numberOfColors; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Negative number of colors!");
                }
                this.numberOfColors = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Display size: {0}, Number of colors on the display: {1}", this.size, this.numberOfColors);
        }
    }
}
