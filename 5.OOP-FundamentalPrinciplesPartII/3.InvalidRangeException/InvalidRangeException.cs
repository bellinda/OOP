using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.InvalidRangeException
{
    public class InvalidRangeException<T> : ApplicationException
    {
        public T MinValue { get; private set; }
        public T MaxValue { get; private set; }

        public InvalidRangeException(string massage, Exception innerException, T minValue, T maxValue)
            : base(massage, innerException)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }

        public InvalidRangeException(string massage,T minValue, T maxValue)
            : this(massage, null, minValue, maxValue)
        {
        }

        public InvalidRangeException(T minValue, T maxValue)
            : this("", null, minValue, maxValue)
        {
        }
    }
}
