using System;

namespace _03.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(' ');
            string[] urls = Console.ReadLine().Split(' ');
            foreach (var item in numbers)
            {
                try
                {
                    if (item.Length == 10)
                    {
                        Smartphone smartphone = new Smartphone();
                        smartphone.Call(item);
                    }
                    else
                    {
                        StationaryPhone stationaryPhone = new StationaryPhone();
                        stationaryPhone.Call(item);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            foreach (var item in urls)
            {
                try
                {
                    Smartphone smartphone = new Smartphone();
                    smartphone.Browse(item);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
