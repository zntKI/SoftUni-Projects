using System;

namespace MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            string metric1 = Console.ReadLine();
            string metric2 = Console.ReadLine();
            if (metric1 == "mm" && metric2 == "m")
            {
                Console.WriteLine($"{number/1000:f3}");
            }
            else if (metric1 == "mm" && metric2 == "cm")
            {
                Console.WriteLine($"{number/10:f3}");
            }
            else if (metric1 == "mm" && metric2 == "mm")
            {
                Console.WriteLine($"{number:f3}");
            }
            else if (metric1 == "cm" && metric2 == "m")
            {
                Console.WriteLine($"{number/100:f3}");
            }
            else if (metric1 == "cm" && metric2 == "mm")
            {
                Console.WriteLine($"{number * 10:f3}");
            }
            else if (metric1 == "cm" && metric2 == "cm")
            {
                Console.WriteLine($"{number:f3}");
            }
            else if (metric1 == "m" && metric2 == "cm")
            {
                Console.WriteLine($"{number * 100:f3}");
            }
            else if (metric1 == "m" && metric2 == "mm")
            {
                Console.WriteLine($"{number * 1000:f3}");
            }
            else
            {
                Console.WriteLine($"{number:f3}");
            }
        }
    }
}
