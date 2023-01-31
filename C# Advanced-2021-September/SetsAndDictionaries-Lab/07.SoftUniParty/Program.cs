using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();
            HashSet<string> vipGuests = new HashSet<string>();
            string input = Console.ReadLine();
            while (input != "PARTY" && input != "END")
            {
                if (char.IsDigit(input[0]))
                {
                    vipGuests.Add(input);
                }
                else
                {
                    guests.Add(input);
                }
                input = Console.ReadLine();
            }
            if (input == "PARTY")
            {
                input = Console.ReadLine();
                while (input != "END")
                {
                    if (char.IsDigit(input[0]))
                    {
                        vipGuests.Remove(input);
                    }
                    else
                    {
                        guests.Remove(input);
                    }
                    input = Console.ReadLine();
                }
            }
            Console.WriteLine(guests.Count + vipGuests.Count);
            foreach (var guest in vipGuests)
            {
                Console.WriteLine(guest);
            }
            foreach (var guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
