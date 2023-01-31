using System;
using System.Linq;

namespace _05.TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int max = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                max = arr[i];
                if (arr[i] != arr[arr.Length - 1])
                {
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[j] > arr[i])
                        {
                            goto Loop;
                        }
                    }
                    Console.Write(max + " ");
                }
            Loop:;
            }
            Console.Write(max);
        }
    }
}
