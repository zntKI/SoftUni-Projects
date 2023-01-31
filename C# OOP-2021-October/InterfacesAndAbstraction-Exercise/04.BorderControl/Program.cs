using System;
using System.Collections.Generic;

namespace _04.BorderControl
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IBirthdayable> birthdayables = new List<IBirthdayable>();
            string line = Console.ReadLine();
            while (line != "End")
            {
                string[] command = line.Split(' ');
                if (command.Length == 5)
                {
                    IBirthdayable citizen = new Citizen(command[command.Length - 1]);
                    birthdayables.Add(citizen);
                }
                else
                {
                    if (command[0] == "Pet")
                    {
                        IBirthdayable pet = new Pet(command[command.Length - 1]);
                        birthdayables.Add(pet);
                    }
                }
                line = Console.ReadLine();
            }
            string num = Console.ReadLine();
            foreach (var item in birthdayables)
            {
                int index = 0;
                int count = 0;
                string birthday = item.Birthday.Substring(item.Birthday.LastIndexOf('/') + 1, item.Birthday.Length - item.Birthday.LastIndexOf('/') - 1);
                for (int i = 0; i < birthday.Length; i++)
                {
                    if (birthday[i] == num[index])
                    {
                        count++;
                    }
                    index++;
                }
                if (count == num.Length)
                {
                    Console.WriteLine(item.Birthday);
                }
            }
        }
    }
}
