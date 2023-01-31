using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] command = input.Split(" : ");
                if (!courses.ContainsKey(command[0]))
                {
                    courses.Add(command[0], new List<string>());
                }
                courses[command[0]].Add(command[1]);
                input = Console.ReadLine();
            }
            foreach (var item in courses.OrderByDescending(item => item.Value.Count))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                foreach (var items in item.Value.OrderBy(items => items))
                {
                    Console.WriteLine($"-- {items}");
                }
            }
        }
    }
}
