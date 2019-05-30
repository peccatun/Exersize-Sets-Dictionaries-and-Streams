using System;
using System.Collections.Generic;
using System.Linq;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] clothes = input[1].Split(',', StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }
                for (int j = 0; j < clothes.Length; j++)
                {
                    if (!wardrobe[color].ContainsKey(clothes[j]))
                    {
                        wardrobe[color].Add(clothes[j], 0);
                    }
                    wardrobe[color][clothes[j]]++;
                }
            }

            string[] neededDres = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            bool hasColor = false;
            bool hasDres = false;
            Console.WriteLine();
            foreach (var color in wardrobe)
            {
                Console.WriteLine(color.Key + " clothes:");
                if (color.Key == neededDres[0])
                {
                    hasColor = true;
                }
                foreach (var dress in color.Value)
                {
                    if (dress.Key == neededDres[1])
                    {
                        hasDres = true;
                    }
                    if (hasColor == true && hasDres == true)
                    {
                        Console.WriteLine($"* {dress.Key} - {dress.Value} (found!)");
                        hasColor = false;
                        hasDres = false;
                    }
                    else
                    {
                        Console.WriteLine($"* {dress.Key} - {dress.Value}");
                    }
                }
            }
        }
    }
}
