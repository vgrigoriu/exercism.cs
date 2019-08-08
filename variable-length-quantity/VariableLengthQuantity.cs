using System;
using System.Collections.Generic;
using System.Linq;

public static class VariableLengthQuantity
{
    public static uint[] Encode(uint[] numbers)
    {
        return numbers.SelectMany(n =>
        {
            if (n == 0)
            {
                return new List<uint> { 0 };
            }

            var octets = new List<uint>();
            var first = true;
            while (n > 0)
            {
                // get last 7 bits
                var octet = n & 0x7F;
                if (first)
                {
                    first = false;
                }
                else
                {
                    octet |= 0x80;
                }
                octets.Add(octet);
                n = n >> 7;
            }
            octets.Reverse();
            return octets;
        }).ToArray();
    }

    public static uint[] Decode(uint[] bytes)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public static int rightmostSetBit(int n)
    {
        return (int)((Math.Log10(n & -n)) / Math.Log10(2)) + 1;
    }
}