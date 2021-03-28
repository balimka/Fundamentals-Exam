using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Pirates
{
    public class Town
    {
        public Town()
        {
        }

        public Town(string name, int population = 0, int gold = 0)
        {
            this.Name = name;
            this.Population = population;
            this.Gold = gold;
        }

        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }
    }
}
