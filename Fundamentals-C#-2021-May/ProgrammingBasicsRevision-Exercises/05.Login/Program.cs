using System;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = string.Empty;
            string username = Console.ReadLine();
            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }
            string password1 = Console.ReadLine();
            int counter = 0;
            while (password1 != password)
            {
                counter++;
                if (counter == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }
                Console.WriteLine("Incorrect password. Try again.");
                password1 = Console.ReadLine();
            }
            Console.WriteLine($"User {username} logged in.");
        }
    }
}
