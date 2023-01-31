using System;

namespace _04.PasswordValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            string pass = Console.ReadLine();
            CheckIfPassIsValid(pass);
        }

        private static void CheckIfPassIsValid(string pass)
        {
            int count1 = 0;
            if (pass.Length < 6 || pass.Length > 10)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            else
            {
                count1++;
            }
            int count2 = 0;
            for (int i = 0; i < pass.Length; i++)
            {
                if (!char.IsLetterOrDigit(pass[i]))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                    break;
                }
                count2++;
            }
            int count = 0;
            int count3 = 0;
            for (int i = 0; i < pass.Length; i++)
            {
                if (char.IsDigit(pass[i]))
                {
                    count++;
                }
            }
            if (count < 2)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            else
            {
                count3 = 1;
            }
            if (count1 == 1 && count2 == pass.Length && count3 == 1)
            {
                Console.WriteLine("Password is valid");
            }
        }
    }
}
