using System;
using System.Collections.Generic;
using System.Linq;

namespace _03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> cardsOriginal = Console.ReadLine().Split(':').ToList();
            List<string> cardsNew = new List<string>();
            string input = Console.ReadLine();
            while (input != "Ready")
            {
                string[] command = input.Split();
                if (command[0] == "Add")
                {
                    if (cardsOriginal.Contains(command[1]))
                    {
                        cardsNew.Add(command[1]);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }
                else if (command[0] == "Insert")
                {
                    int index = int.Parse(command[2]);
                    if (cardsOriginal.Contains(command[1]) && index >= 0 && index < cardsNew.Count)
                    {
                        cardsNew.Insert(index, command[1]);
                    }
                    else
                    {
                        Console.WriteLine("Error!");
                    }
                }
                else if (command[0] == "Remove")
                {
                    if (cardsNew.Contains(command[1]))
                    {
                        cardsNew.Remove(command[1]);
                    }
                    else
                    {
                        Console.WriteLine("Card not found.");
                    }
                }
                else if (command[0] == "Swap")
                {
                    int count = 0;
                    for (int i = 0; i < cardsNew.Count; i++)
                    {
                        if (cardsNew[i] == command[1])
                        {
                            cardsNew.RemoveAt(i);
                            cardsNew.Insert(i, command[2]);
                            count++;
                        }
                        else if (cardsNew[i] == command[2])
                        {
                            cardsNew.RemoveAt(i);
                            cardsNew.Insert(i, command[1]);
                            count++;
                        }
                        if (count == 2)
                        {
                            break;
                        }
                    }
                }
                else if (command[0] == "Shuffle")
                {
                    cardsNew.Reverse();
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', cardsNew));
        }
    }
}
