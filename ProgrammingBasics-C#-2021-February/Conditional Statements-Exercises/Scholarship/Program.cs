using System;

namespace Scholarship
{
    class Program
    {
        static void Main(string[] args)
        {
            double dohod = double.Parse(Console.ReadLine());
            double sredenUspeh = double.Parse(Console.ReadLine());
            double minZaplata = double.Parse(Console.ReadLine());
            double socialScholarship = Math.Floor(minZaplata * 0.35);
            double sredenUspehScholarship = Math.Floor(sredenUspeh * 25);
            if (dohod >= minZaplata && sredenUspeh <= 4.5 || dohod >= minZaplata && sredenUspeh < 5.5)
            {
                Console.WriteLine("You cannot get a scholarship!");
            }
            else if (dohod < minZaplata && (sredenUspeh > 4.5 && sredenUspeh < 5.5))
            {
                Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
            }
            else if (dohod >= minZaplata && sredenUspeh >= 5.5)
            {
                Console.WriteLine($"You get a scholarship for excellent results {sredenUspehScholarship} BGN");
            }
            else if (dohod < minZaplata && sredenUspeh >= 5.5)
            {
                if (socialScholarship == sredenUspehScholarship)
                {
                    Console.WriteLine($"You get a scholarship for excellent results {sredenUspehScholarship} BGN");
                }
                else if (socialScholarship != sredenUspehScholarship)
                {
                    if (socialScholarship > sredenUspehScholarship)
                    {
                        Console.WriteLine($"You get a Social scholarship {socialScholarship} BGN");
                    }
                    else
                    {
                        Console.WriteLine($"You get a scholarship for excellent results {sredenUspehScholarship} BGN");
                    }
                }
            }
        }
    }
}
