using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Need_for_Speed_III
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> MyCars = new List<Car>();

            AddCarToList(numberOfCars, MyCars);

            while (true)
            {
                string[] input = Console.ReadLine().Split(" : ").ToArray();

                if (input[0] == "Stop")
                {
                    break;
                }

                string command = input[0];
                string car = input[1];

                var current = MyCars.First(x => x.Name == car);

                if (command == "Drive")
                {
                    int distance = int.Parse(input[2]);
                    int fuel = int.Parse(input[3]);

                    if (fuel <= current.Fuel)
                    {
                        current.Mileage += distance;
                        current.Fuel -= fuel;

                        Console.WriteLine($"{car} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                    }
                    else
                    {
                        Console.WriteLine($"Not enough fuel to make that ride");
                    }

                    if (current.Mileage >= 100000)
                    {
                        Console.WriteLine($"Time to sell the {car}!");
                        MyCars.Remove(current);
                    }

                }
                else if (command == "Refuel")
                {
                    int fuel = int.Parse(input[2]);

                    if (current.Fuel + fuel > 75)
                    {
                        fuel = 75 - current.Fuel;
                    }
                    current.Fuel += fuel;
                    Console.WriteLine($"{car} refueled with {fuel} liters");
                }
                else if (command == "Revert")
                {
                    int mileage = int.Parse(input[2]);
                    current.Mileage -= mileage;
                    if(current.Mileage < 10000)
                    {
                        current.Mileage = 10000;
                        continue;
                    }
                    Console.WriteLine($"{car} mileage decreased by {mileage} kilometers");
                }

            }

            var ordered = MyCars.OrderByDescending(x => x.Mileage).ThenBy(x => x.Name);
            foreach (var item in ordered)
            {
                Console.WriteLine($"{item.Name} -> Mileage: {item.Mileage} kms, Fuel in the tank: {item.Fuel} lt.");
            }
        }

        private static void AddCarToList(int numberOfCars, List<Car> MyCars)
        {
            for (int i = 0; i < numberOfCars; i++)
            {
                string[] input = Console.ReadLine().Split("|").ToArray();

                string carName = input[0];
                int carMileage = int.Parse(input[1]);
                int carFuel = int.Parse(input[2]);

                Car newCar = new Car(carName, carMileage, carFuel);

                MyCars.Add(newCar);

            }
        }
    }
}
