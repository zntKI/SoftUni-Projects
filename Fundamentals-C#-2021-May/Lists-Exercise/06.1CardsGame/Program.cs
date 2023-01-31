using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._1CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // 20 30 40 50
            // 10 20 30 40
            List<int> firstPlayerDeck = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            List<int> secondPlayerDeck = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            for (int i = 0; i < firstPlayerDeck.Count; i++)
            {
                if (firstPlayerDeck[i] > secondPlayerDeck[i])
                {
                    firstPlayerDeck.Add(firstPlayerDeck[i]);
                    firstPlayerDeck.RemoveAt(i);
                    firstPlayerDeck.Add(secondPlayerDeck[i]);
                    secondPlayerDeck.RemoveAt(i);
                }
                else if (firstPlayerDeck[i] < secondPlayerDeck[i])
                {
                    secondPlayerDeck.Add(secondPlayerDeck[i]);
                    secondPlayerDeck.RemoveAt(i);
                    secondPlayerDeck.Add(firstPlayerDeck[i]);
                    firstPlayerDeck.RemoveAt(i);
                }
                else if (firstPlayerDeck[i] == secondPlayerDeck[i])
                {
                    firstPlayerDeck.RemoveAt(i);
                    secondPlayerDeck.RemoveAt(i);
                }
                if (firstPlayerDeck.Count == 0 || secondPlayerDeck.Count == 0)
                {
                    break;
                }
                i--;
            }
            if (firstPlayerDeck.Count > 0)
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayerDeck.Sum()}");
            }
            else if (secondPlayerDeck.Count > 0)
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayerDeck.Sum()}");
            }
        }
    }
}
