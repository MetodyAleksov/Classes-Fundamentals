using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OldestFamilyMember
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Member> family = new List<Member>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                Member currPerson = new Member(input[0], int.Parse(input[1]));
                family.Add(currPerson);
            }
            family = family.OrderByDescending(x => x.Age).ToList();
            Console.WriteLine(family[0].ToString());
        }
    }
    class Member
    {
        public Member(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} {Age}";
        }
    }
}
