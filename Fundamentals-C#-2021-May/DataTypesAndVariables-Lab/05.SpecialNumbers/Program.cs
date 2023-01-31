using System;

namespace _05.SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                int num = i;
                int sum = 0;
                while (num > 0)
                {
                    int currNum = num % 10;
                    num /= 10;
                    sum += currNum;
                }
                bool specialNum = sum == 5 || sum == 7 || sum == 11;
                Console.WriteLine($"{i} -> {specialNum}");
            }
        }
    }
}
