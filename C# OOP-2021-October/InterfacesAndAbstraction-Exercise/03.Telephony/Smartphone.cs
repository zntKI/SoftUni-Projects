using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        public void Browse(string website)
        {
            foreach (var item in website)
            {
                if (char.IsDigit(item))
                {
                    throw new ArgumentException("Invalid URL!");
                }
            }
            Console.WriteLine($"Browsing: {website}!");
        }

        public void Call(string number)
        {
            foreach (var item in number)
            {
                if (!char.IsDigit(item))
                {
                    throw new ArgumentException("Invalid number!");
                }
            }
            Console.WriteLine($"Calling... {number}");
        }
    }
}
