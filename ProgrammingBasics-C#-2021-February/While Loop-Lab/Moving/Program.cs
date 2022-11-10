using System;

namespace Moving
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int h = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            int size = a * b * h;
            int amountSize = 0;
            while (input != "Done")
            {
                int box = int.Parse(input);
                amountSize += box;
                if (amountSize < size)
                {
                    input = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"No more free space! You need {amountSize - size} Cubic meters more.");
                    return;
                }
            }
            Console.WriteLine($"{size - amountSize} Cubic meters left.");
        }
    }
}
