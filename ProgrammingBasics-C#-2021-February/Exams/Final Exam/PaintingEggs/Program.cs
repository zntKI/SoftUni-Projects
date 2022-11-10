using System;

namespace PaintingEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            string size = Console.ReadLine();
            string colour = Console.ReadLine();
            int numPartidi = int.Parse(Console.ReadLine());
            double pricePartida = 0;
            if (size == "Large")
            {
                if (colour == "Red")
                {
                    pricePartida += 16;
                }
                else if (colour == "Green")
                {
                    pricePartida += 12;
                }
                else if (colour == "Yellow")
                {
                    pricePartida += 9;
                }
            }
            else if (size == "Medium")
            {
                if (colour == "Red")
                {
                    pricePartida += 13;
                }
                else if (colour == "Green")
                {
                    pricePartida += 9;
                }
                else if (colour == "Yellow")
                {
                    pricePartida += 7;
                }
            }
            else if (size == "Small")
            {
                if (colour == "Red")
                {
                    pricePartida += 9;
                }
                else if (colour == "Green")
                {
                    pricePartida += 8;
                }
                else if (colour == "Yellow")
                {
                    pricePartida += 5;
                }
            }
            double priceAllPartidi = pricePartida * numPartidi;
            Console.WriteLine($"{(priceAllPartidi * 0.65):f2} leva.");
        }
    }
}
