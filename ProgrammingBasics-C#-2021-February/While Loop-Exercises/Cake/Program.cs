using System;

namespace Cake
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int sizeOfCake = lenght * width;
            string input = Console.ReadLine();
            int sumPeacesNum = 0;
            while (input != "STOP")
            {
                int peacesNum = int.Parse(input);
                sumPeacesNum += peacesNum;
                if (sumPeacesNum >= sizeOfCake)
                {
                    Console.WriteLine($"No more cake left! You need {sumPeacesNum - sizeOfCake} pieces more.");
                    return;
                }
                else
                {
                    input = Console.ReadLine();
                }
            }
            Console.WriteLine($"{sizeOfCake - sumPeacesNum} pieces are left.");
        }
    }
}
