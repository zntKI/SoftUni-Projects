using System;
using System.Collections.Generic;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songsArr = Console.ReadLine().Split(", ");
            Queue<string> songs = new Queue<string>(songsArr);
            while (songs.Count > 0)
            {
                string command = Console.ReadLine();
                if (command == "Play")
                {
                    songs.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    string name = command.Substring(4, command.Length - 4);
                    if (!songs.Contains(name))
                    {
                        songs.Enqueue(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is already contained!");
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
