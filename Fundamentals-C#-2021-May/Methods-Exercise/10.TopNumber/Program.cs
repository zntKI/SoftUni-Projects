using System;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumOfDigits = 0;
            int countOdd = 0;
            for (int i = 1; i <= n; i++)
            {
                string num = i.ToString();
                for (int j = 0; j < num.Length; j++)
                {
                    int digit = int.Parse(num[j].ToString());
                    sumOfDigits += digit;
                    if (digit % 2 != 0)
                    {
                        countOdd++;
                    }
                }
                if (sumOfDigits % 8 == 0 && countOdd > 0)
                {
                    Console.WriteLine(i);
                }
                sumOfDigits = 0;
                countOdd = 0;
            }
        }
    }
}
