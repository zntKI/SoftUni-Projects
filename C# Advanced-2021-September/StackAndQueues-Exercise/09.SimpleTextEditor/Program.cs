using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "";
            int n = int.Parse(Console.ReadLine());
            Stack<string[]> operations = new Stack<string[]>();
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(" ");
                int name = int.Parse(command[0]);
                if (name == 1)
                {
                    string someString = command[1];
                    string appendedText = "";
                    appendedText += someString;
                    text += someString;
                    operations.Push(new string[] { command[0], appendedText});
                }
                else if (name == 2)
                {
                    int count = int.Parse(command[1]);
                    string textToRemember = "";
                    for (int j = 0; j < count; j++)
                    {
                        textToRemember += text.Substring(text.Length - 1, 1);
                        text = text.Remove(text.Length - 1, 1);
                    }
                    operations.Push(new string[] { command[0], textToRemember });
                }
                else if (name == 3)
                {
                    int index = int.Parse(command[1]) - 1;
                    string subString = text.Substring(index, 1);
                    Console.WriteLine(subString);
                }
                else if (name == 4)
                {
                    string[] lastOperation = operations.Peek();
                    if (int.Parse(lastOperation[0]) == 1)
                    {
                        for (int j = 0; j < lastOperation[1].Length; j++)
                        {
                            text = text.Remove(text.Length - 1, 1);
                        }
                    }
                    else if (int.Parse(lastOperation[0]) == 2)
                    {
                        string reversed = "";
                        for (int j = lastOperation[1].Length - 1; j >= 0; j--)
                        {
                            reversed += lastOperation[1][j];
                        }
                        text += reversed;
                    }
                    operations.Pop();
                }
            }
        }
    }
}
