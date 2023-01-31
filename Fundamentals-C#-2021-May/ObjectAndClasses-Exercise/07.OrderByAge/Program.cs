using System;
using System.Linq;
using System.Collections.Generic;

namespace _07.OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<People> people = new List<People>();
            while (input != "End")
            {
                string[] info = input.Split(" ");
                People person = new People(info[0], info[1], int.Parse(info[2]));
                people.Add(person);
                input = Console.ReadLine();
            }
            foreach (var person in people.OrderBy(x => x.Age))
            {
                Console.WriteLine(person);
            }
        }
    }

    class People
    { 
        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }

        public People(string name, string id, int age)
        {
            Name = name;
            ID = id;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
}
