using System;
using System.IO;

namespace OddFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "files";
            string fileName = "input.txt";
            string outputFile = "output.txt";
            string filePath = Path.Combine(path, fileName);
            using (var reader = new StreamReader(filePath))
            {
                int count = 1;

                string line = reader.ReadLine();
                using (var writer = new StreamWriter(Path.Combine(path, outputFile)))
                {
                    while (line != null)
                    {
                        Console.WriteLine(count +". " +line);
                        writer.WriteLine(count + " " +line);
                        count++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
