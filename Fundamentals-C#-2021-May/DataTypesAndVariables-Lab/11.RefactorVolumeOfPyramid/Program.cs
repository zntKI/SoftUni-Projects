using System;

namespace _11.RefactorVolumeOfPyramid
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double V = length + width + height;
            Console.WriteLine($"Length: Width: Height: Pyramid Volume: {V:f2}");
        }
    }
}
