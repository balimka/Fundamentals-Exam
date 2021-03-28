using System;
using System.Numerics;
using System.Text.RegularExpressions;

namespace _02._Emoji
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string digits = @"(?<digits>\d)";
            string emojis = @"(\:{2}|\*{2})(?<emoji>[A-Z][a-z]{2,})\1";

            MatchCollection allDigits = Regex.Matches(input, digits);
            MatchCollection Emojies = Regex.Matches(input, emojis);

            BigInteger treshhold = GetSum(allDigits);
            Console.WriteLine($"Cool threshold: {treshhold}");
            

            Console.WriteLine($"{Emojies.Count} emojis found in the text. The cool ones are:");
            
            GetCharSum(Emojies, treshhold);
            
        }

        private static void GetCharSum(MatchCollection matchCollection, BigInteger treshhold)
        {
            BigInteger sum = 0;
            BigInteger treshholdSum = treshhold;

            foreach (Match match in matchCollection)
            {
                string word = match.Groups["emoji"].Value;
                for (int i = 0; i < word.Length; i++)
                {
                    sum += word[i];
                }
                if(sum > treshholdSum)
                {
                    Console.WriteLine(match.ToString().Trim());
                    sum = 0;
                }
                else
                {
                    sum = 0;
                }
            }
        }

        private static BigInteger GetSum(MatchCollection matchCollection)
        {
            BigInteger sum = 1;
            foreach (Match match in matchCollection)
            {
                sum *= int.Parse(match.Value);
            }
            return sum;
        }
    }
}
