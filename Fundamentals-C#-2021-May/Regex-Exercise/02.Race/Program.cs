using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace _02.Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] racers = Console.ReadLine().Split(", ");
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < racers.Length; i++)
            {
                dict.Add(racers[i], 0);
            }
            string input = Console.ReadLine();
            while (input != "end of race")
            {
                StringBuilder name = new StringBuilder();
                int km = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    if (char.IsLetter(input[i]))
                    {
                        name.Append(input[i]);
                    }
                    else if (char.IsDigit(input[i]))
                    {
                        km += int.Parse(input[i].ToString());
                    }
                }
                if (dict.ContainsKey(name.ToString()))
                {
                    dict[name.ToString()] += km;
                }
                input = Console.ReadLine();
            }
            int counter = 1;
            foreach (var item in dict.OrderByDescending(x => x.Value))
            {
                if (counter == 1)
                {
                    Console.WriteLine($"1st place: {item.Key}");
                }
                else if (counter == 2)
                {
                    Console.WriteLine($"2nd place: {item.Key}");
                }
                else if (counter == 3) 
                {
                    Console.WriteLine($"3rd place: {item.Key}");
                    break;
                }
                counter++;
            }
        }
    }
}
