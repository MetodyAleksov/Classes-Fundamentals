using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace _07.OrderByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ID> list = new List<ID>();
            string[] people = Console.ReadLine()
                .Split()
                .ToArray();
            while(people[0] != "End")
            {
                ID person = new ID(people[0], int.Parse(people[1]), int.Parse(people[2]));
                list.Add(person);
                people = Console.ReadLine()
                .Split()
                .ToArray();
            }
            list = list.OrderBy(x => x.Age).ToList();
            foreach (ID item in list)
            {
                Console.WriteLine($"{item.Name} with ID: {item.Id} is {item.Age} years old.");
            }
        }
    }
    class ID
    {
        public ID(string name, int id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }
        public string Name { get; set; }
        public int Id { get; set; }
        public int Age { get; set; }
    }
}
