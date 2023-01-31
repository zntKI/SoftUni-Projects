using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();
            string key = @"[STARstar]";
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                StringBuilder sb = new StringBuilder();
                string message = Console.ReadLine();
                int countKey = Regex.Matches(message, key).Count;
                foreach (char symbol in message)
                {
                    sb.Append((char)(symbol - countKey));
                }
                Regex regex = new Regex(@"@([A-Za-z]+)[^@\-!:>]*:([0-9]+)[^@\-!:>]*(!A!|!D!)[^@\-!:>]*->([0-9]+)");
                Match match = regex.Match(sb.ToString());
                if (!match.Success)
                {
                    continue;
                }
                string name = match.Groups[1].Value;
                int population = int.Parse(match.Groups[2].Value);
                string attack = match.Groups[3].Value;
                int soldiers = int.Parse(match.Groups[4].Value);
                if (attack[1] == 'A')
                {
                    attackedPlanets.Add(name);
                }
                else
                {
                    destroyedPlanets.Add(name);
                }
            }
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var planet in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var planet in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
        }
    }
}
