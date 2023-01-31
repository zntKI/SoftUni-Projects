using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = Console.ReadLine().Split().ToList();
            string input = Console.ReadLine();
            while (input != "3:1")
            {
                string[] commands = input.Split();
                if (commands[0] == "merge")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);
                    if (startIndex >= 0 && startIndex < list.Count && endIndex >= 0 && endIndex < list.Count)
                    {
                        for (int i = startIndex; i < endIndex; i++)
                        {
                            list[startIndex] += list[startIndex + 1];
                            list.RemoveAt(startIndex + 1);
                        }
                    }
                    else if (startIndex >= 0 && startIndex < list.Count && endIndex < 0 || endIndex >= list.Count)
                    {
                        for (int i = startIndex; i < list.Count; i++)
                        {
                            list[startIndex] += list[startIndex + 1];
                            list.RemoveAt(startIndex + 1);
                        }
                    }
                    else if (startIndex < 0 || startIndex >= list.Count && endIndex >= 0 && endIndex < list.Count)
                    {
                        for (int i = endIndex; i > 0; i--)
                        {
                            list[endIndex] += list[endIndex - 1];
                            list.RemoveAt(endIndex - 1);
                        }
                    }
                    else if (startIndex < 0 || startIndex >= list.Count && endIndex < 0 || endIndex >= list.Count)
                    {
                        continue;
                    }
                }
                else if (commands[0] == "divide")
                {
                    int index = int.Parse(commands[1]);
                    int partition = int.Parse(commands[2]);
                    string name = list[index];
                    string parts = string.Empty;
                    int count = 0;
                    if (name.Length % partition == 0)
                    {
                        for (int i = 0; i < name.Length; i++)
                        {
                            if (i % 2 == 0)
                            {
                                parts += name[i].ToString();
                                parts += name[i + 1].ToString();
                            }
                            else
                            {
                                count++;
                                continue;
                            }
                            list.Insert(index + count, parts);
                            parts = "";
                        }
                        list.RemoveAt(index + count);
                    }
                    else if (name.Length % partition != 0)
                    {
                        list.RemoveAt(index);
                        int part = name.Length / partition;
                        List<string> dividedElements = new List<string>();
                        for (int i = 0; i < partition - 1; i++)
                        {
                            string currentElement = name.Substring(part * i, part);
                            dividedElements.Add(currentElement);
                        }
                        string lastElement = name.Substring(part * (partition - 1));
                        dividedElements.Add(lastElement);
                        list.InsertRange(index, dividedElements);
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', list));
        }
    }
}
