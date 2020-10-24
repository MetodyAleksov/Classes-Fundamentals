using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _06.VehicleCatalogue
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Vehicle> catalogue = new List<Vehicle>();
			string[] model = Console.ReadLine().Split().ToArray();
			while (model[0] != "End")
            {
				Vehicle curVehicle = new Vehicle(model[0], model[1], model[2], int.Parse(model[3]));
				catalogue.Add(curVehicle);
				model = Console.ReadLine().Split().ToArray();
			}
			string command = Console.ReadLine();
			while(command != "Close the Catalogue")
            {
				Vehicle curVehicle = catalogue.First(x => x.Model == command);
                Console.WriteLine(curVehicle.ToString());
				command = Console.ReadLine();
			}
			List<Vehicle> onlyCars = catalogue.Where(x => x.Type == "car").ToList();
			List<Vehicle> onlyTrucks = catalogue.Where(x => x.Type == "truck").ToList();
			double avrgCarpow = 0.00;
			double carAvrg = 0;
			if (onlyCars.Count > 0)
            {
				avrgCarpow = onlyCars.Sum(x => x.HorsePower);
				carAvrg = avrgCarpow / onlyCars.Count;

			}
			double avrgTruckpow = 0.00;
			double trucksAvrg = 0;
			if (onlyTrucks.Count > 0)
            {
				avrgTruckpow = onlyTrucks.Sum(x => x.HorsePower);
				trucksAvrg = avrgTruckpow / onlyTrucks.Count;
			}
            Console.WriteLine($"Cars have average horsepower of: {carAvrg:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {trucksAvrg:f2}.");
		}
	}
	class Vehicle
	{
		public Vehicle(string type, string model, string color, int horsePower)
		{
			Type = type;
			Model = model;
			Color = color;
			HorsePower = horsePower;
		}
		public string Type { get; set; }
		public string Model { get; set; }
		public string Color { get; set; }
		public int HorsePower { get; set; }
		//Override for ToString();
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Type: {(Type == "car" ? "Car": "Truck")}");
			sb.AppendLine($"Model: {Model}");
			sb.AppendLine($"Color: {Color}");
			sb.AppendLine($"Horsepower: {HorsePower}");
			return sb.ToString().TrimEnd();
		}
	}
}
