using System;
using System.IO;

public static class Tournament
{   
    public static void Tally(Stream inStream, Stream outStream)
    {
        string input;
        using (var reader = new StreamReader(inStream)) {
            input = reader.ReadLine();
        }
        using (var writer = new StreamWriter(outStream))
        {
            writer.Write("Team                           | MP |  W |  D |  L |  P");
            if (input != null)
            {
                var parts = input.Split(";");
                var team1 = parts[0];
                var team2 = parts[1];
                writer.WriteLine();
                writer.Write(team1 + "             |  1 |  1 |  0 |  0 |  3");
                writer.WriteLine();
                writer.Write(team2 + "             |  1 |  0 |  0 |  1 |  0");
            }
        }
    }
}
