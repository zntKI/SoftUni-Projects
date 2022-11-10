using System;

namespace EasterEggsBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            int numEggsOne = int.Parse(Console.ReadLine());
            int numEggsTwo = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int countOne = numEggsOne;
            int countTwo = numEggsTwo;
            while (input != "End of battle")
            {
                if (input == "one")
                {
                    countTwo--;
                }
                else if (input == "two")
                {
                    countOne--;
                }
                if (countOne == 0)
                {
                    Console.WriteLine($"Player one is out of eggs. Player two has {countTwo} eggs left.");
                    return;
                }
                else if (countTwo == 0)
                {
                    Console.WriteLine($"Player two is out of eggs. Player one has {countOne} eggs left.");
                    return;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Player one has {countOne} eggs left.");
            Console.WriteLine($"Player two has {countTwo} eggs left.");
        }
    }
}
