using System;

namespace _02.CharMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();
            int sum = 0;
            int count = 0;
            if (arr[0].Length > arr[1].Length)
            {
                // 1234 123
                for (int i = 0; i < arr[1].Length; i++)
                {
                    sum += arr[1][i] * arr[0][i];
                    count = i;
                }
                for (int i = count + 1; i < arr[0].Length; i++)
                {
                    sum += arr[0][i];
                }
            }
            else
            {
                // a aaaa
                for (int i = 0; i < arr[0].Length; i++)
                {
                    sum += arr[0][i] * arr[1][i];
                    count = i;
                }
                for (int i = count + 1; i < arr[1].Length; i++)
                {
                    sum += arr[1][i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
