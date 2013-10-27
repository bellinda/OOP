using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.BitArray
{
    class TestingBitArrays
    {
        static void Main()
        {
            BitArray64 bitArray1 = new BitArray64(1011101);  //decimal: 93
            BitArray64 bitArray2 = new BitArray64(1001001);  //decimal: 73
            foreach (int bit in bitArray1)
            {
                Console.Write(bit);
            }
            Console.WriteLine();
            Console.WriteLine(bitArray1[3]);
            Console.WriteLine(bitArray1.Equals(bitArray2));
            Console.WriteLine(bitArray2 == bitArray1);
            Console.WriteLine(bitArray1 != bitArray2);
        }
    }
}
