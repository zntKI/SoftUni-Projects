using System;

namespace _01.ValidUsername
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ");
            for (int i = 0; i < usernames.Length; i++)
            {
                if (usernames[i].Length < 3 || usernames[i].Length > 16)
                {
                    continue;
                }
                bool isValid = false;
                foreach (var symbol in usernames[i])
                {
                    if (!(char.IsDigit(symbol) || char.IsLetter(symbol) || symbol == '-' || symbol == '_'))
                    {
                        isValid = false;
                        break;
                    }
                    isValid = true;
                }
                if (isValid == true)
                {
                    Console.WriteLine(usernames[i]);
                }
            }
        }
    }
}
