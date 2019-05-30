using System;
using System.IO;
using System.Linq;

namespace Problem02
{
    class Program
    {
        static void Main(string[] args)
        {
            string textPath = "text.txt";
            string[] textLines = File.ReadAllLines(textPath);
            string outputPath = "output.txt";
            int lineCounter = 1;

            foreach (var currentLine in textLines)
            {
                int letterCount = currentLine.Count(char.IsLetter);
                int puncCount = currentLine.Count(char.IsPunctuation);
                File.AppendAllText(outputPath,$"Line {lineCounter}: {currentLine} ({letterCount}) ({puncCount}) {Environment.NewLine}");
                lineCounter++;

            }
        }
    }
}
