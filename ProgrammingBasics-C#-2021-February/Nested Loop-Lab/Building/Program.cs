using System;

namespace Building
{
    class Program
    {
        static void Main(string[] args)
        {
            int groundsNum = int.Parse(Console.ReadLine());
            int roomsNum = int.Parse(Console.ReadLine());
            for (int i = groundsNum; i >= 1; i--)
            {
                for (int j = 0; j < roomsNum; j++)
                {
                    if (i == groundsNum)
                    {
                        Console.Write($"L{i}{j} ");
                    }
                    if (i % 2 == 0 && i != groundsNum)
                    {
                        Console.Write($"O{i}{j} ");
                    }
                    else if (i % 2 != 0 && i != groundsNum)
                    {
                        Console.Write($"A{i}{j} ");
                    }
                    if ((roomsNum - 1) == j)
                    {
                        Console.WriteLine("");
                    }
                }
            }
        }
    }
}
