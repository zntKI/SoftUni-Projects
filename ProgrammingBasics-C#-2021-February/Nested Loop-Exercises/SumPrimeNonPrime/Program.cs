using System;

namespace SumPrimeNonPrime
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int sumPrimeNum = 0;
            int sumNonPrimeNum = 0;
            while (input != "stop")
            {
                int num = int.Parse(input);
                if (num < 0)
                {
                    Console.WriteLine("Number is negative.");
                }
                else
                {
                    int count = 0;
                    for (int i = 1; i <= num; i++)
                    {
                        if (num % i == 0)
                        {
                            count++;
                        }
                    }
                    if (count == 2)
                    {
                        sumPrimeNum += num;
                    }
                    else
                    {
                        sumNonPrimeNum += num;
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"Sum of all prime numbers is: {sumPrimeNum}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrimeNum}");
        }
    }
}
