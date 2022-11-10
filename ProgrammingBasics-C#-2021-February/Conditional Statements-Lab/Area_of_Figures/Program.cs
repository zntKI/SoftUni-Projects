using System;

namespace Conditional_Statement6
{
    class Program
    {
        static void Main(string[] args)
        {
            string figure = Console.ReadLine();
            if (figure == "square")
            {
                double strana = double.Parse(Console.ReadLine());
                double lice = strana * strana;
                Console.WriteLine($"{lice:F3}");
            }
            else if (figure == "rectangle")
            {
                double strana = double.Parse(Console.ReadLine());
                double strana2 = double.Parse(Console.ReadLine());
                double lice = strana * strana2;
                Console.WriteLine($"{lice:F3}");
            }
            else if (figure == "circle")
            {
                double radius = double.Parse(Console.ReadLine());
                double lice = Math.PI * (radius * radius);
                Console.WriteLine($"{lice:F3}");
            }
            else if (figure == "triangle")
            {
                double strana = double.Parse(Console.ReadLine());
                double visochina = double.Parse(Console.ReadLine());
                double lice = (strana * visochina) / 2;
                Console.WriteLine($"{lice:F3}");
            }
        }
    }
}
