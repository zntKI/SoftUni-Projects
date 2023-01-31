using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> users = new Dictionary<string, int>();
            Dictionary<string, int> language = new Dictionary<string, int>();
            string input = Console.ReadLine();
            while (input != "exam finished")
            {
                string[] command = input.Split('-');
                if (command[1] == "banned")
                {
                    users.Remove(command[0]);
                    input = Console.ReadLine();
                    continue;
                }
                if (!users.ContainsKey(command[0]))
                {
                    users.Add(command[0], int.Parse(command[2]));
                }
                else if (users.ContainsKey(command[0]) && users[command[0]] < int.Parse(command[2]))
                {
                    users[command[0]] = int.Parse(command[2]);
                }
                if (!language.ContainsKey(command[1]))
                {
                    language.Add(command[1], 0);
                }
                language[command[1]]++;
                input = Console.ReadLine();
            }
            Console.WriteLine("Results:");
            foreach (var item in users.OrderByDescending(item => item.Value).ThenBy(item => item.Key))
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var item in language.OrderByDescending(item => item.Value).ThenBy(item => item.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
