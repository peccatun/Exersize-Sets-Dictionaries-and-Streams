using System;
using System.Collections.Generic;
using System.Linq;

namespace TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            Dictionary<string, Dictionary<string, SortedSet<string>>> vlogers = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            while ((command = Console.ReadLine()) != "Statistics")
            {
                string[] actions = command.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                string vloger = actions[0];
                if (actions[1] == "joined")
                {
                    if (!vlogers.ContainsKey(vloger))
                    {
                        vlogers.Add(vloger, new Dictionary<string, SortedSet<string>>());
                        vlogers[vloger].Add("Following", new SortedSet<string>());
                        vlogers[vloger].Add("Followers", new SortedSet<string>());
                    }
                }
                if (actions[1] == "followed")
                {
                    string secondVloger = actions[2];
                    if (vlogers.ContainsKey(vloger) && vlogers.ContainsKey(secondVloger))
                    {
                        if (secondVloger != vloger)
                        {
                            vlogers[vloger]["Following"].Add(secondVloger);
                            vlogers[secondVloger]["Followers"].Add(vloger);
                        }
                    }
                }
            }
            bool hasFollowers = false;
            foreach (var vloger in vlogers)
            {
                foreach (var following in vloger.Value["Followers"])
                {

                    if (following.Count() > 0)
                    {
                        hasFollowers = true;
                    }
                }
            }
            Console.WriteLine($"The V-Logger has a total of {vlogers.Count} vloggers in its logs.");
            int count = 1;
            vlogers = vlogers.OrderByDescending(x => x.Value["Followers"].Count).ThenBy(x => x.Value["Following"].Count).ToDictionary(x => x.Key, y => y.Value);
            foreach (var vloger in vlogers)
            {
                Console.WriteLine($"{count}. {vloger.Key} : {vloger.Value["Followers"].Count} followers, {vloger.Value["Following"].Count} following");
                if (count == 1)
                {
                    foreach (var follower in vloger.Value["Followers"])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                count++;
            }

        }
    }
}
