using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] commandArgs = input.Split();
                string action = commandArgs[0];
                if (action == "Add")
                {
                    int n = Convert.ToInt32(commandArgs[1]);
                    list.Add(n);
                }
                else if (action == "Remove")
                {
                    int n = Convert.ToInt32(commandArgs[1]);
                    list.Remove(n);
                }
                else if (action == "RemoveAt")
                {
                    int n = Convert.ToInt32(commandArgs[1]);
                    list.RemoveAt(n);
                }
                else if (action == "Insert")
                {
                    int n = Convert.ToInt32(commandArgs[1]);
                    int i = Convert.ToInt32(commandArgs[2]);
                    list.Insert(i, n);
                }
                input = Console.ReadLine();
            }
            Console.Write(string.Join(' ', list));
        }
    }
}
