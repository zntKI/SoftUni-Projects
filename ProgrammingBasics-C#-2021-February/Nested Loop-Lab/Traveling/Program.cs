using System;

namespace Traveling
{
    class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();
            int moneyNeeded = int.Parse(Console.ReadLine());
            int moneySaved = int.Parse(Console.ReadLine());
            int sum = moneySaved;
            while (destination != "End")
            {
                while (sum < moneyNeeded)
                {
                    moneySaved = int.Parse(Console.ReadLine());
                    sum += moneySaved;
                }
                Console.WriteLine($"Going to {destination}!");
                sum = 0;
                destination = Console.ReadLine();
                if (destination == "End")
                {
                    break;
                }
                moneyNeeded = int.Parse(Console.ReadLine());
            }
        }
    }
}
