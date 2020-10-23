using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;

namespace _01.AdvertismentMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> prases = new List<string> 
            { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product."};
            List<string> events = new List<string> 
            { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!" };
            List<string> authors = new List<string> 
            { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            List<string> cities = new List<string>
            {"Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"};
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Random rnd = new Random();
                string prase = prases[rnd.Next(0, prases.Count)];
                string even = events[rnd.Next(0, events.Count)];
                string author = authors[rnd.Next(0, authors.Count)];
                string city = authors[rnd.Next(0, cities.Count)];
                Console.WriteLine($"{prase} {even} {author} – {city}.");
            }

        }
    }
}
