using System;
using System.IO;
using System.IO.Compression;

namespace ZipAndExtract
{
    class Program
    {
        static void Main(string[] args)
        {
            string picFolderPath = ".";
            string targetPath = "../../../result.zip";
            ZipFile.CreateFromDirectory(picFolderPath, targetPath);

            ZipFile.ExtractToDirectory(targetPath, "../../");

        }
    }
}
