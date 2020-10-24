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
            string[] currentVehicle = Console.ReadLine().Split(" ").ToArray();
            while (currentVehicle[0] != "End")
            {
                string type = currentVehicle[0];
                string model = currentVehicle[1];
                string color = currentVehicle[2];
                int horsepower = int.Parse(currentVehicle[3]);
                Catalogue newVehicle = new Catalogue(type, model, color, horsepower);
                catalogue.Add(newVehicle);
                currentVehicle = Console.ReadLine().Split(" ").ToArray();
            }
            string models = Console.ReadLine();
            while (models != "Close the Catalogue")
            {
                foreach (Catalogue item in catalogue)
                {
                    if (item.Model == models)
                    {
                        if (item.Type == "car")
                        {
                            Console.WriteLine($"Type: Car\nModel: {item.Model}\nColor: {item.Color}\nHorsepower: {item.HorsePower}");
                        }
                        else
                        {
                            Console.WriteLine($"Type: Truck\nModel: {item.Model}\nColor: {item.Color}\nHorsepower: {item.HorsePower}");
                        }
                        break;
                    }
                }
                models = Console.ReadLine();
            }
            double carsSum = 0;
            int carsCount = 0;
            double trucksSum = 0;
            int trucksCount = 0;
            foreach (Catalogue item in catalogue)
            {
                if (item.Type == "car")
                {
                    carsSum += item.HorsePower;
                    carsCount++;
                }
                else if (item.Type == "truck")
                {
                    trucksSum += item.HorsePower;
                    trucksCount++;
                }
            }
            double carsAvrg = carsSum / carsCount;
            double trucksAvrg = trucksSum / trucksCount;
            if (carsCount > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {carsAvrg:f2}.");
            }
            if (trucksCount > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {trucksAvrg:f2}.");
            }

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
