using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();
            while (input != "end")
            {
                string[] elements = input.Split();
                if (elements[0] == "Delete")
                {
                    int num = int.Parse(elements[1]);
                    for (int i = 0; i < nums.Count; i++)
                    {
                        if (nums[i] == num)
                        {
                            nums.Remove(nums[i]);
                        }
                    }
                }
                else if (elements[0] == "Insert")
                {
                    int num = int.Parse(elements[1]);
                    int index = int.Parse(elements[2]);
                    nums.Insert(index, num);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', nums));
        }
    }
}
