using System;
using System.Linq;

namespace _06.EqualSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int leftSum = 0;
            int rightSum = 0;
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int num = arr[i];
                if (i == 0 || i == arr.Length - 1)
                {
                    if (i == 0)
                    {
                        leftSum = 0;
                        for (int j = i + 1; j <= arr.Length - 1; j++)
                        {
                            rightSum += arr[j];
                        }
                    }
                    else if (i == arr.Length - 1)
                    {
                        rightSum = 0;
                        for (int j = i - 1; j >= 0; j--)
                        {
                            leftSum += arr[j];
                        }
                    }
                }
                else
                {
                    for (int j = i - 1; j >= 0; j--)
                    {
                        leftSum += arr[j];
                    }
                    for (int j = i + 1; j <= arr.Length - 1; j++)
                    {
                        rightSum += arr[j];
                    }
                }
                if (rightSum == leftSum)
                {
                    Console.WriteLine(i);
                    break;
                }
                else
                {
                    count++;
                }
                leftSum = 0;
                rightSum = 0;
            }
            if (count == arr.Length)
            {
                Console.WriteLine("no");
            }
        }
    }
}
