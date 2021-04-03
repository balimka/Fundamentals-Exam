using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Need_for_Speed_III
{
    class Car
    {
        public Car(string name, int mileage = 0, int fuel = 0)
        {
            this.Name = name;
            this.Mileage = mileage;
            this.Fuel = fuel;
        }
        public string Name { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }
    }
}
