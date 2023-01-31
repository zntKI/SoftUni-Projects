using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public class StationaryPhone : ICallable
    { 
        public void Call(string number)
        {
            foreach (var item in number)
            {
                if (!char.IsDigit(item))
                {
                    throw new ArgumentException("Invalid number!");
                }
            }
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
