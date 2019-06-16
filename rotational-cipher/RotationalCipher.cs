using System.Text;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var ch in text)
        {
            sb.Append(Rotate(ch, shiftKey));
        }

        return sb.ToString();
    }

    private static char Rotate(char ch, int shiftKey)
    {
        if ('a' <= ch && ch <= 'z')
        {
            return (char)('a' + (ch - 'a' + shiftKey) % 26);
        }

        if ('A' <= ch && ch <= 'Z')
        {
            return (char)('A' + (ch - 'A' + shiftKey) % 26);
        }

        return ch;
    }
}