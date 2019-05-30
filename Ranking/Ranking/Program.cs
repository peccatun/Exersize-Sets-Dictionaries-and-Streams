using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> candidates = new SortedDictionary<string, Dictionary<string, int>>();
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end of contests")
            {
                string[] contest = command.Split(':', StringSplitOptions.RemoveEmptyEntries);
                contests.Add(contest[0], contest[1]);
            }
            while ((command = Console.ReadLine()) != "end of submissions")
            {
                string[] tokens = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);
                if (contests.ContainsKey(contest))
                {
                    if (contests[contest] == password)
                    {
                        if (!candidates.ContainsKey(username))
                        {
                            candidates.Add(username, new Dictionary<string, int>());
                        }
                        if (!candidates[username].ContainsKey(contest))
                        {
                            candidates[username].Add(contest, 0);
                        }
                        if (candidates[username][contest] < points)
                        {
                            candidates[username][contest] = points;
                        }
                    }
                }
            }
            string bestCandidate = string.Empty;
            int maxPoints = int.MinValue;
            foreach (var candidate in candidates)
            {
                int curentPoints = 0;
                foreach (var value in candidate.Value)
                {
                    curentPoints += value.Value;
                }
                if (maxPoints < curentPoints)
                {
                    maxPoints = curentPoints;
                    bestCandidate = candidate.Key;
                }
            }
            Console.WriteLine($"Best candidate is {bestCandidate} with total {maxPoints} points.");
            foreach (var candidate in candidates)
            {
                Console.WriteLine(candidate.Key);
                foreach (var contest in candidate.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"# {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
