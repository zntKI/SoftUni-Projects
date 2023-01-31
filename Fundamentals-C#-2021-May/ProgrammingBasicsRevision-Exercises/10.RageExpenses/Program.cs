using System;

namespace _10.RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            int timesHeadset = 0;
            int timesMouse =0;
            int timesKeyboard = 0;
            int timesDisplay = 0;
            for (int i = 1; i <= lostGames; i++)
            {
                if (i % 2 == 0)
                {
                    timesHeadset++;
                }
                if (i % 3 == 0)
                {
                    timesMouse++;
                }
                if (i % 6 == 0)
                {
                    timesKeyboard++;
                }
                if (i % 12 == 0)
                {
                    timesDisplay++;
                }
            }
            Console.WriteLine($"Rage expenses: {((timesHeadset * headsetPrice) + (timesMouse * mousePrice) + (timesKeyboard * keyboardPrice) + (timesDisplay * displayPrice)):f2} lv.");
        }
    }
}
