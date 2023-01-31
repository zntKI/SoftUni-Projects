using System;

namespace _03.Elavator
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPeople = int.Parse(Console.ReadLine());
            int capacityPeople = int.Parse(Console.ReadLine());
            Console.WriteLine(Math.Ceiling(numPeople/(double)capacityPeople));
        }
    }
}
