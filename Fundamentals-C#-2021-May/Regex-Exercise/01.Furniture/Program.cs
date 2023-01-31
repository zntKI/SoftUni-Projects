using System;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"^>>([A-Za-z]+)<<([0-9]+\.{0,1}[0-9]{0,})!([0-9]+)");
            Console.WriteLine("Bought furniture:");
            decimal priceAll = 0;
            while (input != "Purchase")
            {
                Match match = regex.Match(input);
                if (!match.Success)
                {
                    input = Console.ReadLine();
                    continue;
                }
                Console.WriteLine(match.Groups[1]);
                decimal price = decimal.Parse(match.Groups[2].Value);
                int count = int.Parse(match.Groups[3].Value);
                priceAll += price * count;
                input = Console.ReadLine();
            }
            Console.WriteLine($"Total money spend: {priceAll:f2}");
        }
    }
}
