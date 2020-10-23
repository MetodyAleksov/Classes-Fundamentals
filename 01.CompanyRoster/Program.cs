using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CompanyRoster
{
    class Roster
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                Roster employee = new Roster();

            }
            List<string> departments = new List<string>();
        }
    }
}
