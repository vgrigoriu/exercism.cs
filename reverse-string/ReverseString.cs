using System;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        var chars = input.ToCharArray();
        var len = chars.Length;
        for (var i = 0; i < len / 2; i++)
        {
            (chars[i], chars[len - 1 - i]) = (chars[len - 1 - i], chars[i]);
        }

        return new String(chars);
    }
}