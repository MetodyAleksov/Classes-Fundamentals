using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.CompanyRoster
{
    class Roster
    {
        public Roster(string name, double salary, string department)
        {
            Name = name;
            Salary = salary;
            Department = department;
        }

        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Roster> roster = new List<Roster>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                Roster employee = new Roster(input[0], double.Parse(input[1]), input[2]);
                roster.Add(employee);
            }
            double biggestAverage = double.MinValue;
            string biggestDep = String.Empty;
            foreach (Roster item in roster)
            {
                string currDepartment = item.Department;
                double currAvrg = 0;
                int depCounter = 0;
                foreach (Roster employee in roster)
                {
                    if (employee.Department == currDepartment)
                    {
                        depCounter++;
                        currAvrg += employee.Salary;
                    }
                }
                currAvrg /= depCounter;
                if (currAvrg > biggestAverage)
                {
                    biggestAverage = currAvrg;
                    biggestDep = currDepartment;
                }
            }
            Console.WriteLine($"Highest Average Salary: {biggestDep}");
            List<Roster> biggestAvrg = roster.Where(x => x.Department == biggestDep).ToList();
            biggestAvrg = biggestAvrg.OrderByDescending(x => x.Salary).ToList();
            StringBuilder sb = new StringBuilder();
            foreach (Roster item in biggestAvrg)
            {
                sb.AppendLine($"{item.Name} {item.Salary:f2}");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
