using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                List<Animal> animals = new List<Animal>();
                string line = Console.ReadLine();
                while (line != "Beast!")
                {
                    string[] command = Console.ReadLine().Split();
                    string name = command[0];
                    int age = int.Parse(command[1]);
                    string gender = command[2];
                    if (line == "Dog")
                    {
                        Dog dog = new Dog(name, age, gender);
                        animals.Add(dog);
                    }
                    else if (line == "Frog")
                    {
                        Frog frog = new Frog(name, age, gender);
                        animals.Add(frog);
                    }
                    else if (line == "Cat")
                    {
                        Cat cat = new Cat(name, age, gender);
                        animals.Add(cat);
                    }
                    else if (line == "Kitten")
                    {
                        Kitten kitten = new Kitten(name, age);
                        animals.Add(kitten);
                    }
                    else if (line == "Tomcat")
                    {
                        Tomcat tomcat = new Tomcat(name, age);
                        animals.Add(tomcat);
                    }
                    line = Console.ReadLine();
                }
                foreach (var animal in animals)
                {
                    Console.WriteLine(animal.GetType().Name);
                    Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                    Console.WriteLine(animal.ProduceSound());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
