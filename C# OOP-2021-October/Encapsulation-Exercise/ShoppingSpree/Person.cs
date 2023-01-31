using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private double money;
        private List<Product> products;

        public Person(string name, double money)
        {
            Name = name;
            Money = money;
            products = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            set 
            {
                if (value == "" || value == " ")
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value; 
            }
        }

        public double Money
        {
            get { return money; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value; 
            }
        }

        public void AddProduct(Product product)
        {
            if (Money >= product.Cost)
            {
                Money -= product.Cost;
                products.Add(product);
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }

        public void PrintAllProducts()
        {
            Console.Write($"{Name} - ");
            if (products.Count > 0)
            {
                for (int i = 0; i < products.Count; i++)
                {
                    if (i == products.Count - 1)
                    {
                        Console.WriteLine(products[i].Name);
                        break;
                    }
                    Console.Write($"{products[i].Name}, ");
                }
            }
            else
            {
                Console.WriteLine("Nothing bought");
            }
        }
    }
}
