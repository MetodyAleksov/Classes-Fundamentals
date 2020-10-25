using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.RawData
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>(n);
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                Engine carEngine = new Engine(int.Parse(input[1]), int.Parse(input[2]));
                Cargo carCargo = new Cargo(int.Parse(input[3]), input[4]);
                Car currCar = new Car(carEngine, carCargo, input[0]);
                cars.Add(currCar);
            }
            string type = Console.ReadLine();
            List<Car> valid = new List<Car>();
            if (type == "fragile")
            {
                valid = cars
                            .Where(x => x.CarCargo.CargoType == type && x.CarCargo.CargoWeight < 1000)
                            .ToList();
            }
            else if (type == "flamable")
            {
                valid = cars
                            .Where(x => x.CarCargo.CargoType == type && x.CarEngine.EnginePower > 250)
                            .ToList();
            }
            StringBuilder sb = new StringBuilder();
            foreach (Car item in valid)
            {
                sb.AppendLine(item.Model);
            }
            Console.WriteLine(sb.ToString());
        }
    }
    class Engine
    {
        public Engine(int engineSpeed, int enginePower)
        {
            EngineSpeed = engineSpeed;
            EnginePower = enginePower;
        }

        public int EngineSpeed { get; set; }
        public int EnginePower { get; set; }
    }
    class Cargo
    {
        public Cargo(int cargoWeight, string cargoType)
        {
            CargoWeight = cargoWeight;
            CargoType = cargoType;
        }

        public int CargoWeight { get; set; }
        public string CargoType { get; set; }
    }
    class Car
    {
        public Car(Engine carEngine, Cargo carCargo, string model)
        {
            CarEngine = carEngine;
            CarCargo = carCargo;
            Model = model;
        }

        public string Model { get; set; }
        public Engine CarEngine { get; set; }
        public Cargo CarCargo { get; set; }

        public override string ToString()
        {
            return $"{Model}";
        }
    }
}
