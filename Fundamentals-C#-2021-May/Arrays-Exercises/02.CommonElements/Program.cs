using System;

namespace _02.CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split();
            string[] arr1 = Console.ReadLine().Split();
            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    if (arr1[i] == arr[j])
                    {
                        Console.Write(arr1[i] + " ");
                    }
                }
            }
        }
    }
}
