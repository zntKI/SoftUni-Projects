using System;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex date = new Regex(@"\b([0-9]{2})([-.\/])([A-Z][a-z]{2})\2([0-9]{4})\b");
            MatchCollection dates = date.Matches(input);
            foreach (Match match in dates)
            {
                Console.WriteLine($"Day: {match.Groups[1].Value}, Month: {match.Groups[3].Value}, Year: {match.Groups[4].Value}");
            }
        }
    }
}
