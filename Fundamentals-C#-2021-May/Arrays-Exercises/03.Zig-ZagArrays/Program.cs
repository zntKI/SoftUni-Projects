using System;
using System.Linq;

namespace _03.Zig_ZagArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            int[] arr1 = new int[n];
            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                if (i % 2 == 0)
                {
                    arr[i] = input[0];
                    arr1[i] = input[1];
                }
                else
                {
                    arr[i] = input[1];
                    arr1[i] = input[0];
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1)
                {
                    Console.WriteLine(arr[i]);
                }
                else
                {
                    Console.Write(arr[i] + " ");
                }
            }
            for (int i = 0; i < arr1.Length; i++)
            {
                Console.Write(arr1[i] + " ");
            }
        }
    }
}
