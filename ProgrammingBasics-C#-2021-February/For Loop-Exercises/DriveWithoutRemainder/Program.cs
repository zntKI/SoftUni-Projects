using System;

namespace DriveWithoutRemainder
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double p1Counter = 0;
            double p2Counter = 0;
            double p3Counter = 0;
            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num % 2 == 0)
                {
                    p1Counter++;
                }
                if (num % 3 == 0)
                {
                    p2Counter++;
                }
                if (num % 4 == 0)
                {
                    p3Counter++;
                }
            }
            Console.WriteLine($"{((p1Counter/n)*100):f2}%");
            Console.WriteLine($"{((p2Counter/n)*100):f2}%");
            Console.WriteLine($"{((p3Counter/n)*100):f2}%");
        }
    }
}
