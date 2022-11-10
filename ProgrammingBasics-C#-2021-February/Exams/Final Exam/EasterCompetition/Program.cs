using System;

namespace EasterCompetition
{
    class Program
    {
        static void Main(string[] args)
        {
            int numKozunaci = int.Parse(Console.ReadLine());
            int gradesAll = 0;
            int max = int.MinValue;
            string contestantMax = "";
            for (int i = 1; i <= numKozunaci; i++)
            {
                string contestant = Console.ReadLine();
                string input = Console.ReadLine();
                while (input != "Stop")
                {
                    int grade = int.Parse(input);
                    gradesAll += grade;
                    input = Console.ReadLine();
                }
                Console.WriteLine($"{contestant} has {gradesAll} points.");
                if (gradesAll > max)
                {
                    max = gradesAll;
                    contestantMax = contestant;
                    Console.WriteLine($"{contestant} is the new number 1!");
                }
                gradesAll = 0;
            }
            Console.WriteLine($"{contestantMax} won competition with {max} points!");
        }
    }
}
