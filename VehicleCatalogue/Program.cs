using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace VehicleCatalogue
{
    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
    }
    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }
    }
    class Catalogue
    {
        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Catalogue catalogue = new Catalogue();
            catalogue.Cars = new List<Car>();
            catalogue.Trucks = new List<Truck>();
            string[] catalogueEntry = Console.ReadLine()
                .Split("/", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            while (catalogueEntry[0] != "end")
            {
                if (catalogueEntry[0] == "Car")
                {
                    Car currentCar = new Car();
                    currentCar.Brand = catalogueEntry[1];
                    currentCar.Model = catalogueEntry[2];
                    currentCar.HorsePower = int.Parse(catalogueEntry[3]);
                    catalogue.Cars.Add(currentCar);
                }
                else if (catalogueEntry[0] == "Truck")
                {
                    Truck currenTruck = new Truck();
                    currenTruck.Brand = catalogueEntry[1];
                    currenTruck.Model = catalogueEntry[2];
                    currenTruck.Weight = int.Parse(catalogueEntry[3]);
                    catalogue.Trucks.Add(currenTruck);
                }
                catalogueEntry = Console.ReadLine()
                .Split("/", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            if (catalogue.Cars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car item in catalogue.Cars.OrderBy(x => x.Model))
                {
                    Console.WriteLine($"{item.Brand}: {item.Model} - {item.HorsePower}hp");
                }
            }
            if (catalogue.Trucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach  (Truck item in catalogue.Trucks.OrderBy(x => x.Model))
                {
                    Console.WriteLine($"{item.Brand}: {item.Model} - {item.Weight}kg");
                }
            }    
        }
    }
}
