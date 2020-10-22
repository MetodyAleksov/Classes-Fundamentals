using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreBoxes
{
    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
    class Box
    {
        public int SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public double TotalPrice { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            string[] description = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            while (description[0] != "end")
            {
                Box box = new Box();
                box.Item = new Item();
                box.SerialNumber = int.Parse(description[0]);
                box.Item.Name = description[1];
                box.Item.Price = double.Parse(description[3]);
                box.ItemQuantity = int.Parse(description[2]);
                box.TotalPrice = box.Item.Price * box.ItemQuantity;
                boxes.Add(box);
                description = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            foreach (Box item in boxes.OrderByDescending(x => x.TotalPrice))
            {
                Console.WriteLine($"{item.SerialNumber}\n-- {item.Item.Name} - ${item.Item.Price:f2}: {item.ItemQuantity}\n-- ${item.TotalPrice:f2}");
            }
        }
    }
}
