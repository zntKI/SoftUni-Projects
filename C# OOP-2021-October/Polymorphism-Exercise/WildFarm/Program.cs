using System;
using WildFarm.Animal;
using WildFarm.Food;

namespace WildFarm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] command = input.Split();
                string[] command2 = Console.ReadLine().Split();
                string type = command[0];
                if (type.GetType().BaseType == typeof(Feline))
                {
                    Feline feline;
                    if (type == "Cat")
                    {
                        feline = new Cat(command[1], double.Parse(command[2]), command[3], command[4]);
                    }
                    else
                    {
                        feline = new Tiger(command[1], double.Parse(command[2]), command[3], command[4]);
                    }
                    IFood food;
                    switch (command2[0])
                    {
                        case "Vegetable":
                            food = new Vegetable(int.Parse(command2[1]));
                            break;
                        case "Fruit":
                            food = new Fruit(int.Parse(command2[1]));
                            break;
                        case "Meat":
                            food = new Meat(int.Parse(command2[1]));
                            break;
                        case "Seeds":
                            food = new Seeds(int.Parse(command2[1]));
                            break;
                        default:
                            food = null;
                            break;
                    }
                    feline.ProduceSound();
                    feline.Eat(food);
                }
                else if (type.GetType().BaseType == typeof(Bird))
                {
                    Bird bird;
                    if (type == "Owl")
                    {
                        bird = new Owl(command[1], double.Parse(command[2]), double.Parse(command[3]));
                    }
                    else
                    {
                        bird = new Hen(command[1], double.Parse(command[2]), double.Parse(command[3]));
                    }
                    IFood food;
                    switch (command2[0])
                    {
                        case "Vegetable":
                            food = new Vegetable(int.Parse(command2[1]));
                            break;
                        case "Fruit":
                            food = new Fruit(int.Parse(command2[1]));
                            break;
                        case "Meat":
                            food = new Meat(int.Parse(command2[1]));
                            break;
                        case "Seeds":
                            food = new Seeds(int.Parse(command2[1]));
                            break;
                        default:
                            food = null;
                            break;
                    }
                    bird.ProduceSound();
                    bird.Eat(food);
                }
                else if (type.GetType() == typeof(Mouse))
                {
                    Mammal mouse = new Mouse(command[1], double.Parse(command[2]), command[3]);
                    IFood food;
                    switch (command2[0])
                    {
                        case "Vegetable":
                            food = new Vegetable(int.Parse(command2[1]));
                            break;
                        case "Fruit":
                            food = new Fruit(int.Parse(command2[1]));
                            break;
                        case "Meat":
                            food = new Meat(int.Parse(command2[1]));
                            break;
                        case "Seeds":
                            food = new Seeds(int.Parse(command2[1]));
                            break;
                        default:
                            food = null;
                            break;
                    }
                    mouse.ProduceSound();
                    mouse.Eat(food);
                }
                else
                {
                    Mammal dog = new Dog(command[1], double.Parse(command[2]), command[3]);
                    IFood food;
                    switch (command2[0])
                    {
                        case "Vegetable":
                            food = new Vegetable(int.Parse(command2[1]));
                            break;
                        case "Fruit":
                            food = new Fruit(int.Parse(command2[1]));
                            break;
                        case "Meat":
                            food = new Meat(int.Parse(command2[1]));
                            break;
                        case "Seeds":
                            food = new Seeds(int.Parse(command2[1]));
                            break;
                        default:
                            food = null;
                            break;
                    }
                    dog.ProduceSound();
                    dog.Eat(food);
                }
                input = Console.ReadLine();
            }

        }
    }
}
