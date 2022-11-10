using System;

namespace Conditional_Statement5
{
    class Program
    {
        static void Main(string[] args)
        {
            string password1 = Console.ReadLine();
            string password = "s3cr3t!P@ssw0rd";
            if (password1 == password)
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Wrong password!");
            }
        }
    }
}
