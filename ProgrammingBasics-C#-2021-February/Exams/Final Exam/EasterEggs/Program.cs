using System;

namespace EasterEggs
{
    class Program
    {
        static void Main(string[] args)
        {
            int paintedEggs = int.Parse(Console.ReadLine());
            int counterRed = 0;
            int counterOrange = 0;
            int counterBlue = 0;
            int counterGreen = 0;
            int max = int.MinValue;
            string maxColor = "";
            for (int i = 1; i <= paintedEggs; i++)
            {
                string color = Console.ReadLine();
                if (color == "red")
                {
                    counterRed++;
                }
                else if (color == "orange")
                {
                    counterOrange++;
                }
                else if (color == "blue")
                {
                    counterBlue++;
                }
                else if (color == "green")
                {
                    counterGreen++;
                }
            }
            Console.WriteLine($"Red eggs: {counterRed}");
            Console.WriteLine($"Orange eggs: {counterOrange}");
            Console.WriteLine($"Blue eggs: {counterBlue}");
            Console.WriteLine($"Green eggs: {counterGreen}");
            if (counterRed > counterOrange && counterRed > counterBlue && counterRed > counterGreen)
            {
                max = counterRed;
                maxColor = "red";
            }
            else if (counterOrange > counterRed && counterOrange > counterBlue && counterOrange > counterGreen)
            {
                max = counterOrange;
                maxColor = "orange";
            }
            else if (counterBlue > counterRed && counterBlue > counterOrange && counterBlue > counterGreen)
            {
                max = counterBlue;
                maxColor = "blue";
            }
            else if (counterGreen > counterRed && counterGreen > counterOrange && counterGreen > counterBlue)
            {
                max = counterGreen;
                maxColor = "green";
            }
            Console.WriteLine($"Max eggs: {max} -> {maxColor}");
        }
    }
}
