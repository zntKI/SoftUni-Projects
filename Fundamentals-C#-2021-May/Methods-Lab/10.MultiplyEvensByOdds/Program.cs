using System;
using System.Linq;

namespace _10.MultiplyEvensByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string arr = Console.ReadLine();
            int sumEven = 0;
            int sumOdd = 0;
            int sumAllEven = 0;
            int sumAllOdd = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == '-')
                {
                    continue;
                }
                else
                {
                    string neshto = arr[i].ToString();
                    int num = int.Parse(neshto);
                    if (num % 2 == 0)
                    {
                        sumAllEven += GetSumOfEvenDigits(num, sumEven);
                    }
                    else if (num % 2 != 0)
                    {
                        sumAllOdd += GetSumOfOddDigits(num, sumOdd);
                    }
                }
            }
            Console.WriteLine(sumAllOdd * sumAllEven);
        }

        private static int GetSumOfOddDigits(int num, int sumOdd)
        {
            sumOdd += num;
            return sumOdd;
        }

        private static int GetSumOfEvenDigits(int num, int sumEven)
        {
            sumEven += num;
            return sumEven;
        }
    }
}
