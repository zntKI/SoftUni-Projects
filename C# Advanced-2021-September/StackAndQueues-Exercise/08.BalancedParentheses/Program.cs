using System;
using System.Collections.Generic;

namespace _08.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> brackets = new Stack<char>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{' || input[i] == '(' || input[i] == '[')
                {
                    brackets.Push(input[i]);
                }
                else
                {
                    if (brackets.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    else
                    {
                        char bracket = brackets.Peek();
                        if (input[i] == ')' && bracket == '(')
                        {
                            brackets.Pop();
                        }
                        else if (input[i] == '}' && bracket == '{')
                        {
                            brackets.Pop();
                        }
                        else if (input[i] == ']' && bracket == '[')
                        {
                            brackets.Pop();
                        }
                        else
                        {
                            Console.WriteLine("NO");
                            return;
                        }
                    }
                }
            }
            Console.WriteLine("YES");
        }
    }
}
