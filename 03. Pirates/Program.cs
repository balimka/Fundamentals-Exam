using System;
using System.Linq;
using System.Collections.Generic;

namespace _03._Pirates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Town> Targets = new List<Town>();

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "Sail")
                {
                    break;
                }

                string[] parts = line.Split("||", StringSplitOptions.RemoveEmptyEntries);

                string town = parts[0];
                int population = int.Parse(parts[1]);
                int gold = int.Parse(parts[2]);

                if (!(Targets.Any(x => x.Name == town)))
                {
                    Town newTown = new Town(town);
                    Targets.Add(newTown);
                }

                Town current = Targets.FirstOrDefault(x => x.Name == town);
                current.Gold += gold;
                current.Population += population;
            }

            while (true)
            {
                string line = Console.ReadLine();
                if (line == "End")
                {
                    break;
                }

                string[] parts = line.Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string action = parts[0];
                string town = parts[1];

                Town current = Targets.First(x => x.Name == town);

                if (action == "Plunder")
                {
                    int people = int.Parse(parts[2]);
                    int gold = int.Parse(parts[3]);

                    if (current.Gold - gold <= 0 || current.Population - people <= 0)
                    {
                        if (current.Gold - gold < 0)
                        {
                            gold = current.Gold;
                        }

                        if (current.Population - people < 0)
                        {
                            people = current.Population;
                        }

                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                        Console.WriteLine($"{town} has been wiped off the map!");

                        Targets.Remove(current);
                    }
                    else
                    {
                        current.Gold -= gold;
                        current.Population -= people;
                        Console.WriteLine($"{town} plundered! {gold} gold stolen, {people} citizens killed.");
                    }


                }
                else if (action == "Prosper")
                {
                    int gold = int.Parse(parts[2]);
                    if (gold >= 0)
                    {
                        current.Gold += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {town} now has {current.Gold} gold.");
                    }
                    else
                    {
                        Console.WriteLine($"Gold added cannot be a negative number!");
                    }

                }
            }

            if (Targets.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {Targets.Count} wealthy settlements to go to:");
                foreach (var item in Targets.OrderByDescending(x => x.Gold).ThenBy(x => x.Name))
                {
                    Console.WriteLine($"{item.Name} -> Population: {item.Population} citizens, Gold: {item.Gold} kg");
                }
            }
            else
            {
                Console.WriteLine($"Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}
