using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> force = new Dictionary<string, List<string>>();
            string input = Console.ReadLine();
            while (input != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    string[] addCom = input.Split(" | ");
                    if (!force.ContainsKey(addCom[0]))
                    {
                        force.Add(addCom[0], new List<string>());
                    }
                    if (!force[addCom[0]].Contains(addCom[1]) && !force.Values.Any(x => x.Contains(addCom[1])))
                    {
                        force[addCom[0]].Add(addCom[1]);
                    }
                }
                else
                {
                    string[] switchCom = input.Split(" -> ");
                    foreach (var item in force)
                    {
                        foreach (var items in item.Value)
                        {
                            if (items == switchCom[0])
                            {
                                force[item.Key].Remove(items);
                                break;
                            }
                        }
                    }
                    if (!force.ContainsKey(switchCom[1]))
                    {
                        force.Add(switchCom[1], new List<string>());
                    }
                    force[switchCom[1]].Add(switchCom[0]);
                    Console.WriteLine($"{switchCom[0]} joins the {switchCom[1]} side!");
                }
                input = Console.ReadLine();
            }
            foreach (var item in force.OrderByDescending(item => item.Value.Count).ThenBy(item => item.Key))
            {
                if (item.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                    foreach (var items in item.Value.OrderBy(items => items))
                    {
                        Console.WriteLine($"! {items}");
                    }
                }
            }
        }
    }
}
