using System;
using System.IO;
using System.Text;

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
                        StringBuilder result = new StringBuilder();
                        for (int i = textArray.Length - 1; i >= 0; i--)
                        {
                            result.Append(textArray[i]);
                            result.Append(" ");
                        }
                        Console.WriteLine(result);
                    }


                    count++;
                }
            }
        }

        private static string ReplaceSpecialCaracters(string currentLine)
        {
            currentLine = currentLine.Replace(oldValue: "-", newValue: "@");
            currentLine = currentLine.Replace(oldValue: ",", newValue: "@");
            currentLine = currentLine.Replace(oldValue: ".", newValue: "@");
            currentLine = currentLine.Replace(oldValue: "!", newValue: "@");
            currentLine = currentLine.Replace(oldValue: "?", newValue: "@");
            return currentLine;


        }
    }
}