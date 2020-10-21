using System;
using System.Collections.Generic;
using System.Text;

namespace Classes_Fundamentals
{
    class Dice
    {
        public Dice(int sides)
        { 
            Sides = sides;
        }
        public int Sides { get; set; }

        public string Type { get; set; }

        public void Roll()
        {
            Random rnd = new Random();
            Console.WriteLine(rnd.Next(1, Sides + 1));
        }
    }
}
