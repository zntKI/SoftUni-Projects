using System;

namespace HighJump
{
    class Program
    {
        static void Main(string[] args)
        {
            int wantedHeight = int.Parse(Console.ReadLine());
            int nowHeight = wantedHeight - 30;
            int jumpCounter = 0;
            int badJumpCounter = 0;
            while (nowHeight <= wantedHeight)
            {
                int jump = int.Parse(Console.ReadLine());
                jumpCounter++;
                if (jump > nowHeight)
                {
                    nowHeight += 5;
                    badJumpCounter = 0;
                }
                else
                {
                    badJumpCounter++;
                }
                if (badJumpCounter == 3)
                {
                    Console.WriteLine($"Tihomir failed at {nowHeight}cm after {jumpCounter} jumps.");
                    return;
                }
            }
            if (nowHeight > wantedHeight)
            {
                Console.WriteLine($"Tihomir succeeded, he jumped over {nowHeight-5}cm after {jumpCounter} jumps.");
            }
            else
            {
                Console.WriteLine($"Tihomir failed at {nowHeight}cm after {jumpCounter} jumps.");
            }
        }
    }
}
