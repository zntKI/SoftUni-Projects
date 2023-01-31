using System;
using System.Text.RegularExpressions;

namespace _06.ExtraxtEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"(?<=\s)([A-Za-z0-9]+[-._]*[A-Za-z0-9]+)@([A-Za-z]+(([-.]*)[A-Za-z]+)*\.[a-z]{2,})");
            MatchCollection matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
