using System;

namespace GenericCountMethodStrings
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();
            for (int i = 0; i < n; i++)
            {
                string text = Console.ReadLine();
                box.Add(text);
            }
            string item = Console.ReadLine();
            Console.WriteLine(box.CountLargerElementsByValue(item));
        }
    }
}
