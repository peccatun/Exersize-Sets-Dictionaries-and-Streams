using System;
using System.IO;

namespace MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "files";
            string file1 = "input1.txt";
            string file2 = "input2.txt";
            string output = "Output.txt";
            string file1Path = Path.Combine(path, file1);
            string file2Path = Path.Combine(path, file2);

            using (var readFile1 = new StreamReader(file1Path))
            {
                using (var readFile2 = new StreamReader(file2Path))
                {
                    string line1 = string.Empty;
                    string line2 = string.Empty;
                    using (var outputFile = new StreamWriter(output))
                    {
                        while ((line1 = readFile1.ReadLine()) != null && (line2 = readFile2.ReadLine()) != null)
                        {
                            outputFile.WriteLine(line1);
                            outputFile.WriteLine(line2);
                        }
                    }
                }
            }
        }
    }
}
