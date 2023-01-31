using System;

namespace _06.StrongNum
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int sum = 0;
            int num1 = num;
            while (num > 0)
            {
                int currNum = num % 10;
                int factoriel = 1;
                for (int i = currNum; i >= 1; i--)
                {
                    factoriel *= i;
                }
                sum += factoriel;
                num /= 10;
            }
            if (sum == num1)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
