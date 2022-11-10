using System;

namespace Histogram
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double p1Counter = 0;
            double p2Counter = 0;
            double p3Counter = 0;
            double p4Counter = 0;
            double p5Counter = 0;
            for (int i = 1; i <= n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num < 200)
                {
                    p1Counter++;
                }
                else if (num >= 200 && num <= 399)
                {
                    p2Counter++;
                }
                else if (num >= 400 && num <= 599)
                {
                    p3Counter++;
                }
                else if (num >= 600 && num <= 799)
                {
                    p4Counter++;
                }
                else
                {
                    p5Counter++;
                }
            }
            Console.WriteLine($"{((p1Counter / n) * 100):f2}%");
            Console.WriteLine($"{((p2Counter / n) * 100):f2}%");
            Console.WriteLine($"{((p3Counter / n) * 100):f2}%");
            Console.WriteLine($"{((p4Counter / n) * 100):f2}%");
            Console.WriteLine($"{((p5Counter / n) * 100):f2}%");
        }
    }
}
