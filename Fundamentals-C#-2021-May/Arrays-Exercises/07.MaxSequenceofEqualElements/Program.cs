using System;
using System.Linq;

namespace _07.MaxSequenceofEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int maxElements = 0;
            int currEqualElements = 1;
            int element = 0;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    currEqualElements+=1;
                }
                else
                {
                    currEqualElements = 1;
                }
                if (currEqualElements > maxElements)
                {
                    maxElements = currEqualElements;
                    element = arr[i];
                }
            }
            for (int i = 0; i < maxElements; i++)
            {
                Console.Write(element + " ");
            }
        }
    }
}
