using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string textPath = "text.txt";
            string wordsPath = "words.txt";
            string actualResultPatch = "actualResult.txt";
            string expectedResult = "expectedResult.txt";
            string[] textLines = File.ReadAllLines(textPath);
            string[] words = File.ReadAllLines(wordsPath);

            Dictionary<string, int> wordsInfo = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (!wordsInfo.ContainsKey(word))
                {

                    wordsInfo.Add(word, 0);
                }
            }

            foreach (var currentLine in textLines)
            {
                string[] currentLineWords = currentLine
                    .Split(new char[] {' ','-',',','?','.','!',':','\\',';' });

                foreach (var currentWord in currentLineWords)
                {
                    string currentWordToLower = currentWord.ToLower();
                    if (wordsInfo.ContainsKey(currentWordToLower))
                    {
                        wordsInfo[currentWordToLower]++;
                    }
                }
            }

            foreach (var word in wordsInfo)
            {
                File.AppendAllText(actualResultPatch, $"{word.Key} - {word.Value} {Environment.NewLine}");
            }
            wordsInfo = wordsInfo.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
            foreach (var word in wordsInfo)
            {
                File.AppendAllText(expectedResult, $"{word.Key} - {word.Value} {Environment.NewLine}");
            }
        }
    }
}
