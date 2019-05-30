using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCountPartOne
{
    class Program
    {
        static void Main(string[] args)
        {
            string textFile = "text.txt";
            string wordsFile = "words.txt";
            string outputFile = "output.txt";

            using (StreamReader words = new StreamReader(wordsFile))
            {
                string[] matchWords = words.ReadLine().Split();
                Dictionary<string, int> wordsInfo = new Dictionary<string, int>();
                foreach (var word in matchWords)
                {
                    if (!wordsInfo.ContainsKey(word))
                    {
                        wordsInfo.Add(word, 0);
                    }
                }
                using (var text = new StreamReader(textFile))
                {
                    string line = string.Empty;
                    while ((line = text.ReadLine()) != null)
                    {
                        string[] separatedWords = line.Split(new char[] {' ',',','.','!','?','/','\\','-','_' });
                        foreach (var word in separatedWords)
                        {
                            string wordToLower = word.ToLower();
                            if (wordsInfo.ContainsKey(wordToLower))
                            {
                                wordsInfo[wordToLower]++;
                            }
                        }
                    }
                    using (var writer = new StreamWriter(outputFile))
                    {
                        wordsInfo = wordsInfo.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y=> y.Value);
                        foreach (var (key,value) in wordsInfo)
                        {
                            writer.Write($"{key} - {value} {Environment.NewLine}");
                        }
                    }
                }
            }
        }
    }
}
