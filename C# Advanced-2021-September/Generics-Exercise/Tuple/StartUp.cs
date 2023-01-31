using System;

namespace Tuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] input1 = Console.ReadLine().Split(' ');
            string s = "";
            for (int i = 3; i < input1.Length; i++)
            {
                if (i == input1.Length - 1)
                {
                    s += input1[i];
                }
                else
                {
                    s += input1[i] + " ";
                }
            }
            Threeuple<string, string, string> tuple = new Threeuple<string, string, string>(input1[0] + " " + input1[1], input1[2], s);
            string[] input2 = Console.ReadLine().Split(' ');
            bool d = input2[2] == "drunk";
            Threeuple<string, int, bool> tuple2 = new Threeuple<string, int, bool>(input2[0], int.Parse(input2[1]), d);
            string[] input3 = Console.ReadLine().Split(' ');
            Threeuple<string, double, string> tuple3 = new Threeuple<string, double, string>(input3[0], double.Parse(input3[1]), input3[2]);
            Console.WriteLine(tuple.Print());
            Console.WriteLine(tuple2.Print());
            Console.WriteLine(tuple3.Print());
        }
    }
}
