using System;
using System.Collections.Generic;
using System.Linq;

namespace _02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            string input = Console.ReadLine();
            while (input != "Finish")
            {
                string[] command = input.Split();
                int value = int.Parse(command[1]);
                if (command[0] != "Add" && command[0] != "Remove" && command[0] != "Replace" && command[0] != "Collapse")
                {
                    goto End;
                }
                if (command[0] == "Add")
                {
                    nums.Add(value);
                    goto End;
                }
                for (int i = 0; i < nums.Count; i++)
                {
                    if (command[0] == "Remove")
                    {
                        if (nums.Contains(value))
                        {
                            //for (int i = 0; i < nums.Count; i++)
                            //{
                                if (nums[i] == value)
                                {
                                    nums.RemoveAt(i);
                                    break;
                                }
                            //}
                        }
                        else
                        {
                            goto End;
                        }
                    }
                    else if (command[0] == "Replace")
                    {
                        if (nums.Contains(value))
                        {
                            int replacement = int.Parse(command[2]);
                            //for (int i = 0; i < nums.Count; i++)
                            //{
                                if (nums[i] == value)
                                {
                                    nums.RemoveAt(i);
                                    nums.Insert(i, replacement);
                                    break;
                                }
                            //}
                        }
                        else
                        {
                            goto End;
                        }
                    }
                    else if (command[0] == "Collapse")
                    {
                        //for (int i = 0; i < nums.Count; i++)
                        //{
                            if (nums[i] < value)
                            {
                                nums.RemoveAt(i);
                            }
                        //}
                    }
                }
                //if (command[0] == "Add")
                //{
                //    nums.Add(value);
                //}
                //else if (command[0] == "Remove")
                //{
                //    if (nums.Contains(value))
                //    {
                //        for (int i = 0; i < nums.Count; i++)
                //        {
                //            if (nums[i] == value)
                //            {
                //                nums.RemoveAt(i);
                //                break;
                //            }
                //        }
                //    }
                //}
                //else if (command[0] == "Replace")
                //{
                //    if (nums.Contains(value))
                //    {
                //        int replacement = int.Parse(command[2]);
                //        for (int i = 0; i < nums.Count; i++)
                //        {
                //            if (nums[i] == value)
                //            {
                //                nums.RemoveAt(i);
                //                nums.Insert(i, replacement);
                //                break;
                //            }
                //        }
                //    }
                //}
                //else //if (command[0] == "Collapse")
                //{
                //    for (int i = 0; i < nums.Count; i++)
                //    {
                //        if (nums[i] < value)
                //        {
                //            nums.RemoveAt(i);
                //        }
                //    }
                //}
                if (nums.Count <= 0)
                {
                    break;
                }
            End: input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', nums));
        }
    }
}
