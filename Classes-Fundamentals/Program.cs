using System;
using System.Linq;
using System.Numerics;

namespace Classes_Fundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            Dice d6 = new Dice(int.Parse(Console.ReadLine()));
            d6.Roll();
        }
    }
}
