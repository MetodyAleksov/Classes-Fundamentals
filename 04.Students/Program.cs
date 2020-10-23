using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>(n);
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                Student currentStudent = new Student(input[0], input[1], double.Parse(input[2]));
                students.Add(currentStudent);
            }
            students = students.OrderByDescending(x => x.Grade).ToList();
            foreach (Student item in students)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
    class Student
    {
        public Student(string fisrtname, string lastname, double grade)
        {
            FirstName = fisrtname;
            LastName = lastname;
            Grade = grade;
        }
        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }
    }
}
