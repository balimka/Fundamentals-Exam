using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Ad_Astra
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(#|\|)(?<food>[A-Za-z]+|\w+\s{1}\w+)\1(?<date>[\d]{2}\/[\d]{2}\/[\d]{2})\1(?<calories>[\d]+)\1";

            int kcalPerDay = 2000;
            
            string input = Console.ReadLine();

            var food = Regex.Matches(input, pattern);

            int callories = food.Select(m => int.Parse(m.Groups[4].ToString())).Sum();

            int daysLeft = callories / kcalPerDay;

            Console.WriteLine($"You have food to last you for: {daysLeft} days!");

            if (daysLeft > 0) {
                foreach (Match item in food)
                {
                    Console.WriteLine($"Item: {item.Groups["food"].Value}, Best before: {item.Groups["date"].Value}, Nutrition: {item.Groups["calories"].Value}");
                }
            }
            
        }
    }
}
