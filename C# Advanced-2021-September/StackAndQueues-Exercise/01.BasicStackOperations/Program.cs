using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] oper = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] nums = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < oper[0]; i++)
            {
                stack.Push(nums[i]);
            }
            for (int i = 0; i < oper[1]; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(oper[2]))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count <= 0)
            {
                Console.WriteLine("0");
            }
            else if (!stack.Contains(oper[2]))
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
