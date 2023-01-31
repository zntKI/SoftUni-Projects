using System;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();
            for (int i = 0; i < n; i++)
            {
                int text = int.Parse(Console.ReadLine());
                box.Add(text);
            }
            string[] indexes = Console.ReadLine().Split();
            int firstIndex = int.Parse(indexes[0]);
            int secondIndex = int.Parse(indexes[1]);
            box.SwapElements(firstIndex, secondIndex);
            Console.WriteLine(box.ToString());
        }
    }
}
