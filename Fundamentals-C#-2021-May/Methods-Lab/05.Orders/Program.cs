using System;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int numsProduct = int.Parse(Console.ReadLine());
            Order(product, numsProduct);
        }

        private static void Order(string product, int numsProduct)
        {
            double sum = 0;
            if (product == "coffee")
            {
                sum = numsProduct * 1.50;
            }
            else if (product == "water")
            {
                sum = numsProduct * 1.00;
            }
            else if (product == "coke")
            {
                sum = numsProduct * 1.40;
            }
            else if (product == "snacks")
            {
                sum = numsProduct * 2.00;
            }
            Console.WriteLine($"{sum:f2}");
        }
    }
}
