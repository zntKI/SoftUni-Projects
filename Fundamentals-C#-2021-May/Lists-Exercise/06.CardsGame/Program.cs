using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // 10 20 30 40 50
            // 50 40 30 30 10

            // 
            List<int> firstDeck = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondDeck = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> firstResult = firstDeck.ToList();
            List<int> secondResult = secondDeck.ToList();
            for (int i = 0; i < firstDeck.Count; i++)
            {
                if (firstResult.Count == 0 || secondResult.Count == 0)
                {
                    break;
                }
                if (firstDeck[i] > secondDeck[i])
                {
                    firstResult.Add(firstDeck[i]);
                    firstResult.RemoveAt(0);
                    firstResult.Add(secondDeck[i]);
                    secondResult.RemoveAt(0);
                }
                else if (firstDeck[i] < secondDeck[i])
                {
                    secondResult.Add(secondDeck[i]);
                    secondResult.RemoveAt(0);
                    secondResult.Add(firstDeck[i]);
                    firstResult.RemoveAt(0);
                }
                else if (firstDeck[i] == secondDeck[i])
                {
                    firstResult.RemoveAt(0);
                    secondResult.RemoveAt(0);
                }
            }
            if (firstResult.Count > secondResult.Count)
            {
                Console.WriteLine($"First player wins! Sum: {firstResult.Sum()}");
            }
            else
            {
                Console.WriteLine($"First player wins! Sum: {secondResult.Sum()}");
            }
        }
    }
}
