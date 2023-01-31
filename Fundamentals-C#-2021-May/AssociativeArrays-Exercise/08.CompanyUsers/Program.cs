using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CompanyUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> employees = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] command = input.Split(" -> ");
                if (!employees.ContainsKey(command[0]))
                {
                    employees.Add(command[0], new List<string>());
                }
                if (!employees[command[0]].Contains(command[1]))
                {
                    employees[command[0]].Add(command[1]);
                }
                input = Console.ReadLine();
            }
            foreach (var item in employees.OrderBy(item => item.Key))
            {
                Console.WriteLine($"{item.Key}");
                foreach (var items in item.Value)
                {
                    Console.WriteLine($"-- {items}");
                }
            }
        }
    }
}
