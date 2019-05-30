using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] fileArray = Directory.GetFiles(".","*.*");

            var dirInfo = new Dictionary<string, Dictionary<string, double>>();

            DirectoryInfo directoryInfo = new DirectoryInfo(".");

            FileInfo[] allFiles = directoryInfo.GetFiles();

            foreach (FileInfo currentFile in allFiles)
            {
                double size = currentFile.Length/1024d;
                string fileName = currentFile.Name;
                string ext = currentFile.Extension;

                if (!dirInfo.ContainsKey(ext))
                {
                    dirInfo.Add(ext, new Dictionary<string, double>());
                }

                if (!dirInfo[ext].ContainsKey(fileName))
                {
                    dirInfo[ext].Add(fileName, size);
                }
            }
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/report.txt";
            var sortedDictionary = dirInfo
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);
            foreach (var (extension,value) in dirInfo)
            {
                File.AppendAllText(path, extension + Environment.NewLine);
                foreach (var (fileName,size) in value.OrderBy(x => x.Value))
                {
                    File.AppendAllText(path,$"--{fileName} - {Math.Round(size,3)}kb ,{Environment.NewLine}");
                }
            }
        }
    }
}
