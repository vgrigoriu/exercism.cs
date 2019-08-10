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
                var octet = n & 0x7F;
                if (!first)
                {
                    octet |= 0x80;
                }

                octets.Add(octet);
                n = n >> 7;
                first = false;
            }

            octets.Reverse();
            return octets;
        }).ToArray();
    }

    public static uint[] Decode(uint[] bytes)
    {
        var numbers = new List<uint>();
        uint number = 0;
        // is an empty array a valid input?
        bool hasBit8Set = true;
        foreach (var octet in bytes)
        {
            number = (number << 7) | (octet & 0x7F);
            hasBit8Set = (octet & 0x80) != 0;
            if (!hasBit8Set)
            {
                numbers.Add(number);
                number = 0;
            }
        }

        if (hasBit8Set)
        {
            throw new InvalidOperationException("Last byte had 8th bit set");
        }
        return numbers.ToArray();
    }
}