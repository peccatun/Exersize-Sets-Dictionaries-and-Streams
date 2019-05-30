using System;
using System.IO;

namespace FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Resources";
            string path1 = "06. Folder Size";
            string path2 = "TestFolder";

            string file1 = "1. Java-Advanced-Stacks-and-Queues.pptx";
            string file2 = "1. Java-Advanced-Stacks-and-Queues-Exercises.docx";
            string file3 = "1. Java-Advanced-Stacks-and-Queues-Lab.docx";
            string file4 = "2. Simple-Calculations-Exercises.docx";
            string file1Path = Path.Combine(path, path1, path2, file1);
            string file2Path = Path.Combine(path, path1, path2, file2);
            string file3Path = Path.Combine(path, path1, path2, file3);
            string file4Path = Path.Combine(path, path1, path2, file4);
            using (var theFile1 = new FileStream(file1Path, FileMode.Open))
            {
                long size = theFile1.Length;
                using (var theFile2 = new FileStream(file2Path, FileMode.Open))
                {
                    long size1 = theFile2.Length;
                    using (var theFile3 = new FileStream(file3Path, FileMode.Open))
                    {
                        long size2 = theFile3.Length;
                        using (var theFile4 = new FileStream(file4Path, FileMode.Open))
                        {
                            long size3 = theFile4.Length;
                            decimal sum = size + size1 + size2 + size3;
                            using (var outputResult = new StreamWriter("Output.txt"))
                            {
                                string[] sizes = { "B", "KB", "MB", "GB", "TB" };
                                int order = 0;
                                while (sum >= 1024 && order < sizes.Length - 1)
                                {
                                    order++;
                                    sum = sum / 1024;
                                }
                                outputResult.Write(sum);
                            }
                        }
                    }
                }
            }
        }
    }
}
