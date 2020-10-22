using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace Classes_Fundamentals
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string[] id = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            while (id[0] != "end")
            {
                Student currentStudent = new Student();
                currentStudent.FirstName = id[0];
                currentStudent.LastName = id[1];
                currentStudent.Age = int.Parse(id[2]);
                currentStudent.City = id[3];
                bool exist = false;
                foreach (Student item in students)
                {
                    if (currentStudent.FirstName == item.FirstName && currentStudent.LastName == item.LastName)
                    {
                        item.Age = currentStudent.Age;
                        item.City = currentStudent.City;
                        exist = true;
                    }
                }
                if (!exist)
                {
                    students.Add(currentStudent);
                }
                id = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            string city = Console.ReadLine();
            foreach (Student item in students)
            {
                if (item.City == city)
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName} is {item.Age} years old.");
                }
            }
        }
    }
}
