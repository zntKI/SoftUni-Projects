using System;

namespace _08.BeerKings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double max = double.MinValue;
            string maxKeg = "";
            for (int i = 1; i <= n; i++)
            {
                string keg = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());
                double V = (radius * radius) * height;
                if (V > max)
                {
                    max = V;
                    maxKeg = keg;
                }
            }
            Console.WriteLine(maxKeg);
        }
    }
}
