using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02._Mirror_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([#|@])(?<word>[A-Za-z]{3,})\1\1(?<reversed>[A-Za-z]{3,})\1";

            string input = Console.ReadLine();

            MatchCollection allwords = Regex.Matches(input, pattern);

            if(allwords.Count > 0)
            {
                Console.WriteLine($"{allwords.Count} word pairs found!");
            }
            else
            {
                Console.WriteLine("No word pairs found!");
            }

            Dictionary<string, string> validPairs = new Dictionary<string, string>();

            foreach (Match match in allwords)
            {

                GroupCollection groups = match.Groups;
                string nameOne = groups["word"].Value;
                string nameTwo = groups["reversed"].Value;
                string nameTwoReversed = string.Empty;

                for (int i = nameTwo.Length - 1; i >= 0; i--)
                {
                    nameTwoReversed += nameTwo[i];
                }
                if (nameOne == nameTwoReversed)
                {
                    validPairs.Add(nameOne, nameTwo);
                }

            }

            if (validPairs.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }
            else
            {
                Console.WriteLine($"The mirror words are:");
                int count = 1;
                foreach (var item in validPairs)
                {
                    if (count < validPairs.Count)
                    {
                        Console.Write($"{item.Key} <=> {item.Value}, ");
                    }
                    else
                    {
                        Console.WriteLine($"{item.Key} <=> {item.Value}");
                    }
                    count++;
                }
            }
        }
    }
}
