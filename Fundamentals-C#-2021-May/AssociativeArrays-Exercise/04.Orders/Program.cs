using System;
using System.Collections.Generic;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double[]> products = new Dictionary<string, double[]>();
            string input = Console.ReadLine();
            while (input != "buy")
            {
                string[] arr = input.Split();
                string name = arr[0];
                double price = double.Parse(arr[1]);
                double quantity = double.Parse(arr[2]);
                if (!products.ContainsKey(name))
                {
                    products.Add(arr[0], new double[2]);
                }
                double previousQnt = products[name][1];
                double[] newArr = { price, previousQnt + quantity };
                products[name] = newArr;
                input = Console.ReadLine();
            }
            foreach (var item in products)
            {
                double priceAll = item.Value[0] * item.Value[1];
                Console.WriteLine($"{item.Key} -> {priceAll:f2}");
            }
        }
    }
}
