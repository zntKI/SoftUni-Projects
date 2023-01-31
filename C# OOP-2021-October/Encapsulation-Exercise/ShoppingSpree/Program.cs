using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Person> shoppers = new Dictionary<string, Person>();
            Dictionary<string, Product> stuff = new Dictionary<string, Product>();
            try
            {
                string[] people = Console.ReadLine().Split(';');
                for (int i = 0; i < people.Length; i++)
                {
                    string[] arr = people[i].Split('=');
                    Person person = new Person(arr[0], double.Parse(arr[1]));
                    shoppers.Add(arr[0], person);
                }
                string[] products = Console.ReadLine().Split(';');
                for (int i = 0; i < products.Length; i++)
                {
                    if (products[i] == "")
                    {
                        continue;
                    }
                    string[] arr = products[i].Split('=');
                    Product product = new Product(arr[0], double.Parse(arr[1]));
                    stuff.Add(arr[0], product);
                }
                string line = Console.ReadLine();
                while (line != "END")
                {
                    string[] command = line.Split(' ');
                    string personName = command[0];
                    string productName = command[1];
                    if (shoppers.ContainsKey(personName) && stuff.ContainsKey(productName))
                    {
                        shoppers[personName].AddProduct(stuff[productName]);
                    }
                    line = Console.ReadLine();
                }
                foreach (var item in shoppers)
                {
                    item.Value.PrintAllProducts();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
