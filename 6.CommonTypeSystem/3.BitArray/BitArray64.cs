using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace _3.BitArray
{
    public class BitArray64 : IEnumerable<int>
    {
        public ulong Bits { get; private set; }

        public BitArray64(ulong bits)
        {
            this.Bits = bits;
        }

        public IEnumerator<int> GetEnumerator()
        {
            int[] arrayOfBits = this.GetBits();
            for (int i = 63; i >= 0; i--)
            {
                yield return arrayOfBits[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int[] GetBits()
        {
            int[] bits = new int[64];
            int counter = 63;
            ulong number = this.Bits;
            while (number > 0)
            {
                bits[63 - counter] = (int)number % 10;
                number /= 10;
                counter--;
            }
            while (counter >= 0)
            {
                bits[63 - counter] = 0;
                counter--;
            }
            return bits;
        }

        public override bool Equals(object obj)
        {
            BitArray64 arrayOfBits = obj as BitArray64;
            if (arrayOfBits == null)
            {
                return false;
            }
            if (!Object.Equals(this.Bits, arrayOfBits.Bits))
            {
                return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            return this.Bits.GetHashCode() ^ this.GetBits().GetHashCode();
        }

        public static bool operator ==(BitArray64 bitArray1, BitArray64 bitArray2)
        {
            return BitArray64.Equals(bitArray1, bitArray2);
        }

        public static bool operator !=(BitArray64 bitArray1, BitArray64 bitArray2)
        {
            return !BitArray64.Equals(bitArray1, bitArray2);
        }

        public int this[int index]
        {
            get
            {
                int[] bitsArray = this.GetBits();
                return bitsArray[index];
            }
            //we don't have set accessor, because the customer doesn't need to change the bits one by one.
        }
    }
}
