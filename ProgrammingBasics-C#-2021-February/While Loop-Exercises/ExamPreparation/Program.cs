using System;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string problem = Console.ReadLine();
            double grade = double.Parse(Console.ReadLine());
            double counterProblems = 0;
            int counterPoorGrades = 0;
            double sumGrades = 0.0;
            string lastProblem = "";
            while (problem != "Enough")
            {
                counterProblems++;
                sumGrades += grade;
                if (grade <= 4.00)
                {
                    counterPoorGrades++;
                }
                if (counterPoorGrades >= n)
                {
                    Console.WriteLine($"You need a break, {counterPoorGrades} poor grades.");
                    return;
                }
                lastProblem = problem;
                problem = Console.ReadLine();
                if (problem == "Enough")
                {
                    break;
                }
                else
                {
                    grade = double.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine($"Average score: {(sumGrades/counterProblems):f2}");
            Console.WriteLine($"Number of problems: {counterProblems}");
            Console.WriteLine($"Last problem: {lastProblem}");
        }
    }
}
