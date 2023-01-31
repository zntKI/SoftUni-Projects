using System;
using System.Collections.Generic;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] nums = Console.ReadLine().Split();
            Stack<string> numbers = new Stack<string>();
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                numbers.Push(nums[i]);
            }
            while (numbers.Count > 1)
            {
                int firstNum = int.Parse(numbers.Pop());
                string sign = numbers.Pop();
                int secondNum = int.Parse(numbers.Pop());
                if (sign == "+")
                {
                    numbers.Push((firstNum + secondNum).ToString());
                }
                else if (sign == "-")
                {
                    numbers.Push((firstNum - secondNum).ToString());
                }
            }
            Console.WriteLine(numbers.Pop());
        }
    }
}
