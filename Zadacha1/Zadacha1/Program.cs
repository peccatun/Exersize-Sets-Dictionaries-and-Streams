using System;
using System.IO;

namespace Zadacha1
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFilePath = @"text.txt";

            using (StreamReader streamReader = new StreamReader(textFilePath))
            {
                string currentLine = string.Empty;
                int count = 0;
                while ((currentLine = streamReader.ReadLine()) != null)
                {
                    if (count % 2 == 0)
                    {
                        string replacedSimbols = ReplaceSpecialCaracters(currentLine);
                        string[] textArray = replacedSimbols.Split();
                        Array.Reverse(textArray);
                        Console.WriteLine(textArray);
                    }


                    count++;
                }
            }
        }

        private static string ReplaceSpecialCaracters(string currentLine)
        {
            currentLine.Replace(oldValue:"-",newValue:"@");
            currentLine.Replace(oldValue: ",",newValue:"@");
            currentLine.Replace(oldValue:".",newValue:"@");
            currentLine.Replace(oldValue: "|", newValue: "@");
            currentLine.Replace(oldValue: "?", newValue: "@");
            return currentLine;


        }
    }
}
