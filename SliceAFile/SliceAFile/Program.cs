using System;
using System.IO;

namespace SliceAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var inputFile = new FileStream(@"files\input.txt",FileMode.Open))
            {
                long size = inputFile.Length;
                int partSize = (int)Math.Ceiling((double)size/4);
                byte[] buffer = new byte[partSize];

                for (int i = 0; i < 4; i++)
                {
                    using (var outputFile = new FileStream($"files\\Part-{i+1}.txt",FileMode.Create))
                    {
                        int readedBytes = inputFile.Read(buffer, 0, partSize);
                        outputFile.Write(buffer, 0, readedBytes);
                    }
                }
            }
        }
    }
}
