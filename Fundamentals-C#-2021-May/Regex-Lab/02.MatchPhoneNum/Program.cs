using System;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNum
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Regex regex = new Regex(@"\+359([ -])2\1[0-9]{3}\1[0-9]{4}\b");
            MatchCollection phoneNums = regex.Matches(input);
            Console.WriteLine(string.Join(", ", phoneNums));
        }
    }
}
