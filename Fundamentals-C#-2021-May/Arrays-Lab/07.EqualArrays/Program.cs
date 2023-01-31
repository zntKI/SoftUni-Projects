using System;
using System.Linq;

namespace _07.EqualArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] arr1 = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sumArr = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == arr1[i])
                {
                    sumArr += arr[i];
                }
                else
                {
                    Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
                    return;
                }
            }
            Console.WriteLine($"Arrays are identical. Sum: {sumArr}");
        }
    }
}
