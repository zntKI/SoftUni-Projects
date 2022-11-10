using System;

namespace OnTimeForTheExam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourOfExam = int.Parse(Console.ReadLine());
            int minutesOfExam = int.Parse(Console.ReadLine());
            int hourOfArrival = int.Parse(Console.ReadLine());
            int minutesOfArrival = int.Parse(Console.ReadLine());
            if (hourOfExam == hourOfArrival && minutesOfArrival > minutesOfExam)
            {
                Console.WriteLine("Late");
                Console.WriteLine($"{minutesOfArrival - minutesOfExam} minutes after the start");
            }
            else if (hourOfExam < hourOfArrival && minutesOfArrival == minutesOfExam)
            {
                Console.WriteLine("Late");
                if (minutesOfArrival < 10)
                {
                    Console.WriteLine($"{hourOfArrival - hourOfExam}:00 hours after the start");
                }
                else
                {
                    Console.WriteLine($"{hourOfArrival - hourOfExam}:00 hours after the start");
                }
            }
            else if (hourOfExam < hourOfArrival && minutesOfArrival > minutesOfExam)
            {
                Console.WriteLine("Late");
                if (minutesOfArrival < 10 && minutesOfExam < 10)
                {
                    Console.WriteLine($"{hourOfArrival - hourOfExam}:0{minutesOfArrival - minutesOfExam} hours after the start");
                }
                else if (minutesOfArrival > 10 && minutesOfExam < 10)
                {
                    if (minutesOfArrival < 19 && minutesOfExam == 9)
                    {
                        Console.WriteLine($"{hourOfArrival - hourOfExam}:0{minutesOfArrival - minutesOfExam} hours after the start");
                    }
                    else if (minutesOfArrival < 18 && minutesOfExam >= 8)
                    {
                        Console.WriteLine($"{hourOfArrival - hourOfExam}:0{minutesOfArrival - minutesOfExam} hours after the start");
                    }
                    else if (minutesOfArrival < 17 && minutesOfExam >= 7)
                    {
                        Console.WriteLine($"{hourOfArrival - hourOfExam}:0{minutesOfArrival - minutesOfExam} hours after the start");
                    }
                    else if (minutesOfArrival < 16 && minutesOfExam >= 6)
                    {
                        Console.WriteLine($"{hourOfArrival - hourOfExam}:0{minutesOfArrival - minutesOfExam} hours after the start");
                    }
                    else if (minutesOfArrival < 15 && minutesOfExam >= 5)
                    {
                        Console.WriteLine($"{hourOfArrival - hourOfExam}:0{minutesOfArrival - minutesOfExam} hours after the start");
                    }
                    else if (minutesOfArrival < 14 && minutesOfExam >= 4)
                    {
                        Console.WriteLine($"{hourOfArrival - hourOfExam}:0{minutesOfArrival - minutesOfExam} hours after the start");
                    }
                    else if (minutesOfArrival < 13 && minutesOfExam >= 3)
                    {
                        Console.WriteLine($"{hourOfArrival - hourOfExam}:0{minutesOfArrival - minutesOfExam} hours after the start");
                    }
                    else if (minutesOfArrival < 12 && minutesOfExam >= 2)
                    {
                        Console.WriteLine($"{hourOfArrival - hourOfExam}:0{minutesOfArrival - minutesOfExam} hours after the start");
                    }
                    else if (minutesOfArrival == 19 && minutesOfExam <= 9)
                    {
                        Console.WriteLine($"{hourOfArrival - hourOfExam}:{minutesOfArrival - minutesOfExam} hours after the start");
                    }
                    else if (minutesOfArrival == 18 && minutesOfExam <= 8)
                    {
                        Console.WriteLine($"{hourOfArrival - hourOfExam}:{minutesOfArrival - minutesOfExam} hours after the start");
                    }
                    else if (minutesOfArrival == 17 && minutesOfExam <= 7)
                    {
                        Console.WriteLine($"{hourOfArrival - hourOfExam}:{minutesOfArrival - minutesOfExam} hours after the start");
                    }
                    else if (minutesOfArrival == 16 && minutesOfExam <= 6)
                    {
                        Console.WriteLine($"{hourOfArrival - hourOfExam}:{minutesOfArrival - minutesOfExam} hours after the start");
                    }
                    else if (minutesOfArrival == 15 && minutesOfExam <= 5)
                    {
                        Console.WriteLine($"{hourOfArrival - hourOfExam}:{minutesOfArrival - minutesOfExam} hours after the start");
                    }
                    else if (minutesOfArrival == 14 && minutesOfExam <= 4)
                    {
                        Console.WriteLine($"{hourOfArrival - hourOfExam}:{minutesOfArrival - minutesOfExam} hours after the start");
                    }
                    else if (minutesOfArrival == 13 && minutesOfExam <= 3)
                    {
                        Console.WriteLine($"{hourOfArrival - hourOfExam}:{minutesOfArrival - minutesOfExam} hours after the start");
                    }
                    else if (minutesOfArrival == 12 && minutesOfExam <= 2)
                    {
                        Console.WriteLine($"{hourOfArrival - hourOfExam}:{minutesOfArrival - minutesOfExam} hours after the start");
                    }
                    else if (minutesOfArrival == 11 && minutesOfExam <= 1)
                    {
                        Console.WriteLine($"{hourOfArrival - hourOfExam}:{minutesOfArrival - minutesOfExam} hours after the start");
                    }
                    else if (minutesOfArrival >= 20 && minutesOfExam < 10)
                    {
                        Console.WriteLine($"{hourOfArrival - hourOfExam}:{minutesOfArrival - minutesOfExam} hours after the start");
                    }
                }
                else if (minutesOfArrival > 10 && minutesOfExam > 10)
                {
                    if ((minutesOfArrival - minutesOfExam) < 10)
                    {
                        Console.WriteLine($"{hourOfArrival - hourOfExam}:0{minutesOfArrival - minutesOfExam} hours after the start");
                    }
                    else
                    {
                        Console.WriteLine($"{hourOfArrival - hourOfExam}:{minutesOfArrival - minutesOfExam} hours after the start");
                    }
                }
            }
            else if (hourOfExam < hourOfArrival && minutesOfArrival < minutesOfExam)
            {
                Console.WriteLine("Late");
                Console.WriteLine($"{(60 - minutesOfExam) + minutesOfArrival} minutes after the start");
            }
            else if (hourOfArrival == hourOfExam && minutesOfArrival == minutesOfExam)
            {
                Console.WriteLine("On time");
            }
            else if (hourOfArrival == hourOfExam && minutesOfArrival < minutesOfExam)
            {
                if ((minutesOfArrival + 30) < minutesOfExam)
                {
                    Console.WriteLine("Early");
                    Console.WriteLine($"{minutesOfExam - minutesOfArrival} minutes before the start");
                }
                else if ((minutesOfArrival + 30) >= minutesOfExam)
                {
                    Console.WriteLine("On time");
                    Console.WriteLine($"{minutesOfExam - minutesOfArrival} minutes before the start");
                }
                //else if ((minutesOfArrival + 30) == 60)
                //{
                //    Console.WriteLine("On time");
                //    Console.WriteLine($"{minutesOfExam - minutesOfArrival} minutes before the start");
                //}
            }
            else if (hourOfArrival < hourOfExam && minutesOfArrival < minutesOfExam)
            {
                Console.WriteLine("Early");
                if ((minutesOfExam - minutesOfArrival) < 10)
                {
                    Console.WriteLine($"{hourOfExam - hourOfArrival}:0{minutesOfExam - minutesOfArrival} hours before the start");
                }
                else
                {
                    Console.WriteLine($"{hourOfExam - hourOfArrival}:{minutesOfExam - minutesOfArrival} hours before the start");
                }
            }
            else if (hourOfArrival < hourOfExam && minutesOfArrival > minutesOfExam)
            {
                Console.WriteLine("Early");
                Console.WriteLine($"{minutesOfExam + (60 - minutesOfArrival)} minutes before the start");
            }
            else if (hourOfArrival < hourOfExam && minutesOfArrival == minutesOfExam)
            {
                Console.WriteLine("Early");
                Console.WriteLine($"{hourOfExam - hourOfArrival}:00 hours before the start");
            }
        }
    }
}
