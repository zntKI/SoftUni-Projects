using System;

namespace WorldRecordSwimming
{
    class Program
    {
        static void Main(string[] args)
        {
            double recordSec = double.Parse(Console.ReadLine());
            double metri = double.Parse(Console.ReadLine());
            double secsForMeter = double.Parse(Console.ReadLine());
            double secsTotal = metri * secsForMeter;
            double suprotivlenieSecs = Math.Floor(metri / 15);
            double secsFinalTotal = secsTotal + suprotivlenieSecs * 12.5;
            if (secsFinalTotal < recordSec)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {(secsFinalTotal):f2} seconds.");
            }
            else
            {
                Console.WriteLine($"No, he failed! He was {(secsFinalTotal - recordSec):f2} seconds slower.");
            }
        }
    }
}
