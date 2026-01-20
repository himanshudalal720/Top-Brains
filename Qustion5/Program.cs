using System;
using System.IO;
class Program
{
    static void Main()
    {
        string inputFile = "log.txt";
        string outputFile = "error.txt";
        if (!File.Exists(inputFile))
        {
            Console.WriteLine("log.txt file not found.");
            return;
        }
        string[] lines = File.ReadAllLines(inputFile);
        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            foreach (string line in lines)
            {
                if (line.Contains("ERROR"))
                {
                    writer.WriteLine(line);
                }
            }
        }

        Console.WriteLine("ERROR logs extracted successfully.");
    }
}
