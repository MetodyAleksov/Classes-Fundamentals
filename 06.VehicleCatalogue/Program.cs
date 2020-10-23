using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace _06.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Catalogue> catalogue = new List<Catalogue>();
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            while (input[0] != "End")
            {
                Catalogue vehicle = new Catalogue(input[0], input[1], input[2], int.Parse(input[3]));
                catalogue.Add(vehicle);
                input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            string model = Console.ReadLine();
            while (model != "Close the Catalogue")
            {
                foreach (Catalogue item in catalogue)
                {
                    if (item.Model == model)
                    {
                        if (item.Type == "car")
                        {
                            Console.WriteLine("Type: Car");
                        }
                        else
                        {
                            Console.WriteLine("Type: Truck");
                        }
                        Console.WriteLine($"Model: {item.Model}\nColor: {item.Color}\nHorsepower: {item.HorsePower}");
                    }
                }
                model = Console.ReadLine();
            }
            List<int> trucks = new List<int>();
            List<int> cars = new List<int>();
            foreach (Catalogue item in catalogue)
            {
                if (item.Type == "truck")
                {
                    trucks.Add(item.HorsePower);
                }
                else if (item.Type == "car")
                {
                    cars.Add(item.HorsePower);
                }
            }
            double carsAvrg = cars.Sum() / cars.Count;
            double trucksAvrg = trucks.Sum() / trucks.Count;
            Console.WriteLine($"Cars have average horsepower of: {carsAvrg:f2}.\nTrucks have average horsepower of: {trucksAvrg:f2}.");
        }
    }
    class Catalogue
    {
        public Catalogue(string type, string model, string color, int horsepower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsepower;
        }
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
    }
}
