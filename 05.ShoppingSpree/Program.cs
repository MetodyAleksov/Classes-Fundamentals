using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputPeople = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string[] inputProduct = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            foreach (var item in inputPeople)
            {
                string[] currPerson = item.Split("=").ToArray();
                Person newPerson = new Person(currPerson[0], int.Parse(currPerson[1]));
                people.Add(newPerson);
            }
            foreach (var item in inputProduct)
            {
                string[] currProduct = item.Split("=").ToArray();
                Product newProduct = new Product(currProduct[0], int.Parse(currProduct[1]));
                products.Add(newProduct);
            }

            string[] input = Console.ReadLine().Split().ToArray();
            while (input[0] != "END")
            {
                string person = input[0];
                string productName = input[1];
                int indexOf = people.FindIndex(x => x.Name == person);
                Person result = people.Find(x => x.Name == person);
                Product product = products.Find(x => x.Name == productName);

                if (result.Money >= product.Cost)
                {
                    Console.WriteLine($"{result.Name} bought {product.Name}");
                    result.Money -= product.Cost;
                    result.Bag.Add(product);
                }
                else
                {
                    Console.WriteLine($"{result.Name} can't afford {product.Name}");
                }
                people[indexOf] = result;
                input = Console.ReadLine().Split().ToArray();
            }
            Console.WriteLine(string.Join(Environment.NewLine, people));
        }
    }
    class Person
    {
        public Person(string name, int money)
        {
            Name = name;
            Money = money;
            Bag = new List<Product>();
        }

        public string Name { get; set; }
        public int Money { get; set; }
        public List<Product> Bag { get; set; }

        public override string ToString()
        {
            return $"{Name} - {(Bag.Count > 0 ? string.Join(", ", Bag): "Nothing bought")}";
        }
    }
    class Product
    {
        public Product(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name { get; set; }
        public int Cost { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
