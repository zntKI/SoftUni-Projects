using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"%([A-Z][a-z]+)%[^\|$%\.]*<(\w+)>[^\|$%\.]*\|([0-9]{0,})\|[^\|$%\.\d]*([0-9]+\.{0,}[0-9]+)\$");
            double allPrice = 0;
            while (input != "end of shift")
            {
                Match match = regex.Match(input);
                if (!match.Success)
                {
                    input = Console.ReadLine();
                    continue;
                }
                string name = match.Groups[1].Value;
                string productName = match.Groups[2].Value;
                int count = int.Parse(match.Groups[3].Value);
                double price = double.Parse(match.Groups[4].Value);
                double totalPrice = price * count;
                allPrice += totalPrice;
                Console.WriteLine($"{name}: {productName} - {totalPrice:f2}");
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total income: {allPrice:f2}");
        }
    }
}
