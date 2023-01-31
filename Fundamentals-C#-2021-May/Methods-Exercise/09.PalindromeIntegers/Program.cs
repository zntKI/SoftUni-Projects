using System;

namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "END")
            {
                string num = input;
                string numReverse = "";
                for (int i = num.Length - 1; i >= 0; i--)
                {
                    numReverse += num[i];
                }
                if (num == numReverse)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
                input = Console.ReadLine();
            }
        }
    }
}
