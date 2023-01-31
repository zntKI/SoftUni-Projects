using System;
using System.Text;

namespace _04.CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int neshto = 0;
            StringBuilder neww = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                neshto = input[i];
                neshto += 3;
                neww.Append((char)neshto);
            }
            Console.WriteLine(neww);
        }
    }
}
