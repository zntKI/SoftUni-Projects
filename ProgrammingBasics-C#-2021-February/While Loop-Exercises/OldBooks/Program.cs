using System;

namespace OldBooks
{
    class Program
    {
        static void Main(string[] args)
        {
            string wantedBook = Console.ReadLine();
            string input = Console.ReadLine();
            int counter = 0;
            while (input != wantedBook)
            {
                counter++;
                if (input != "No More Books")
                {
                    input = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("The book you search is not here!");
                    Console.WriteLine($"You checked {counter-1} books.");
                    return;
                }
            }
            Console.WriteLine($"You checked {counter} books and found it.");
        }
    }
}
