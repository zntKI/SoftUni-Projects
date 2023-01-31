using System;

namespace _03.ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Console.ReadLine();
            path = path.Substring(path.LastIndexOf('\\') + 1);
            string name = path.Substring(0, path.LastIndexOf('.'));
            string type = path.Substring(path.LastIndexOf('.') + 1);
            Console.WriteLine($"File name: {name}");
            Console.WriteLine($"File extension: {type}");
        }
    }
}
