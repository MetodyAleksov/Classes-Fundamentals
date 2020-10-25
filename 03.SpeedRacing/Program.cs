using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace _03.SpeedRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> garage = new List<Car>(n);
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();
                Car car = new Car(input[0], double.Parse(input[1]), double.Parse(input[2]));
                garage.Add(car);
            }
            string[] input2 = Console.ReadLine().Split().ToArray();
            while(input2[0] != "End")
            {
                Car currCar = garage.Find(x => x.Model == input2[1]);
                currCar.Drive(currCar, double.Parse(input2[2]));
                input2 = Console.ReadLine().Split().ToArray();
            }
            StringBuilder sb = new StringBuilder();
            foreach (Car item in garage)
            {
                sb.AppendLine($"{item.Model} {item.FuelAmount:f2} {item.TraveledDistance}");
            }
            Console.WriteLine(sb.ToString());
        }
    }
    class Car
    {
        public Car(string model, double fuelAmount, double fuelPerKilo)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelPerKilo = fuelPerKilo;
            TraveledDistance = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelPerKilo { get; set; }
        public double TraveledDistance { get; set; }

        public void Drive(Car car, double distanceTraveled)
        {
            double fuelConsumed = distanceTraveled * car.FuelPerKilo;
            if (fuelConsumed > car.FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                car.FuelAmount -= fuelConsumed;
                car.TraveledDistance += distanceTraveled;
            }
        }
    }
}
