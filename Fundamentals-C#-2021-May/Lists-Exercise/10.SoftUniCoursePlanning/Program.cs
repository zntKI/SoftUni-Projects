using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> themes = Console.ReadLine().Split(", ").ToList();
            string input = Console.ReadLine();
            while (input != "course start")
            {
                string[] commands = input.Split(":");
                if (commands[0] == "Add")
                {
                    if (!themes.Contains(commands[1]))
                    {
                        themes.Add(commands[1]);
                    }
                }
                else if (commands[0] == "Insert")
                {
                    int index = int.Parse(commands[2]);
                    if (!themes.Contains(commands[1]))
                    {
                        themes.Insert(index, commands[1]);
                    }
                }
                else if (commands[0] == "Remove")
                {
                    if (themes.Contains(commands[1]))
                    {
                        themes.Remove(commands[1]);
                        if (themes.Contains($"{commands[1]}-Exercise"))
                        {
                            themes.Remove($"{commands[1]}-Exercise");
                        }
                    }
                }
                else if (commands[0] == "Swap")
                {
                    bool one = themes.Contains(commands[1]);
                    bool two = themes.Contains(commands[2]);
                    if (one == true && two == true)
                    {
                        for (int i = 0; i < themes.Count; i++)
                        {
                            if (themes[i] == commands[1])
                            {
                                themes.RemoveAt(i);
                                if (themes.Contains($"{commands[1]}-Exercise"))
                                {
                                    if (i != themes.Count - 1)
                                    {
                                        themes.RemoveAt(i + 1);
                                    }
                                    else
                                    {
                                        themes.RemoveAt(i);
                                    }
                                }
                                themes.Insert(i, commands[2]);
                                if (themes.Contains($"{commands[2]}-Exercise"))
                                {
                                    themes.Insert(i + 1, $"{commands[2]}-Exercise");
                                }
                                continue;
                            }
                            if (themes[i] == commands[2])
                            {
                                themes.RemoveAt(i);
                                if (themes.Contains($"{commands[2]}-Exercise"))
                                {
                                    if (i != themes.Count - 1)
                                    {
                                        themes.RemoveAt(i + 1);
                                    }
                                    else
                                    {
                                        themes.RemoveAt(i);
                                    }
                                }
                                themes.Insert(i, commands[1]);
                                if (themes.Contains($"{commands[1]}-Exercise"))
                                {
                                    themes.Insert(i + 1, $"{commands[1]}-Exercise");
                                }
                            }
                        }
                    }
                }
                else if (commands[0] == "Exercise")
                {
                    bool one = themes.Contains(commands[1]);
                    bool two = !themes.Contains($"{commands[1]}-Exercise");
                    if (one == true && two == true)
                    {
                        for (int i = 0; i < themes.Count; i++)
                        {
                            if (themes[i] == commands[1])
                            {
                                themes.Insert(i + 1, $"{commands[1]}-Exercise");
                                break;
                            }
                        }
                    }
                    else if (!themes.Contains(commands[1]))
                    {
                        themes.Add(commands[1]);
                        themes.Add($"{commands[1]}-Exercise");
                    }
                }
                input = Console.ReadLine();
            }
            for (int i = 0; i < themes.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{themes[i]}");
            }
        }
    }
}
