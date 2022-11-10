using System;

namespace Cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfProjection = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());
            switch (typeOfProjection)
            {
                case "Premiere":
                    Console.WriteLine($"{(rows * columns * 12.00):f2} leva");
                    break;
                case "Normal":
                    Console.WriteLine($"{(rows * columns * 7.50):f2} leva");
                    break;
                case "Discount":
                    Console.WriteLine($"{(rows * columns * 5.00):f2} leva");
                    break;
            }
        }
    }
}
