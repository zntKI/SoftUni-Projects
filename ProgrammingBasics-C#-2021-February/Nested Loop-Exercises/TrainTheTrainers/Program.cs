using System;

namespace TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfJudges = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();
            double sumOfGrades = 0;
            double sumOfFinalGrades = 0;
            double numOfPresentations = 0;
            while (input != "Finish")
            {
                numOfPresentations++;
                for (int i = 1; i <= numOfJudges; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    sumOfGrades += grade;
                }
                double finalGrade = (sumOfGrades / numOfJudges);
                Console.WriteLine($"{input} - {finalGrade:f2}.");
                sumOfFinalGrades += finalGrade;
                sumOfGrades = 0;
                finalGrade = 0;
                input = Console.ReadLine();
            }
            Console.WriteLine($"Student's final assessment is {(sumOfFinalGrades/numOfPresentations):f2}.");
        }
    }
}
