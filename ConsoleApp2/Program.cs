using System;
using System.Linq;
using System.Text;

namespace Problem1
{
    class Program
    {
        static void Main(string[] args)
        {

            string username = Console.ReadLine();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);


                if (input[0] == "Sign" && input[1] == "up")
                {
                    break;
                }

                string command = input[0];

                if (command == "Case")
                {
                    string stringCase = input[1];

                    if (stringCase == "lower")
                    {
                        username = username.ToLower();
                    }
                    else if (stringCase == "upper")
                    {
                        username = username.ToUpper();
                    }
                    Console.WriteLine(username);
                }
                else if (command == "Reverse")
                {
                    int startIndex = int.Parse(input[1]);
                    int endIndex = int.Parse(input[2]);

                    if (startIndex < 0 && endIndex >= username.Length)
                    {
                        continue;
                    }

                    if (startIndex > endIndex)
                    {
                        continue;
                    }

                    char[] substringPart = username
                        .Substring(startIndex, endIndex - startIndex + 1)
                        .ToCharArray();

                    substringPart = substringPart.Reverse().ToArray();

                    Console.WriteLine(new string(substringPart));
                }
                else if (command == "Cut")
                {
                    string substring = input[1];

                    if (username.Contains(substring))
                    {
                        username = username.Replace(substring, "");
                        Console.WriteLine(username);
                    }
                    else
                    {
                        Console.WriteLine($"The word {username} doesn't contain {substring}.");
                    }
                }
                else if (command == "Replace")
                {
                    string replaceChar = input[1];
                    username = username.Replace(replaceChar, "*");
                    Console.WriteLine(username);
                }
                else if (command == "Check")
                {
                    string validChar = input[1];
                    if (username.Contains(validChar))
                    {
                        Console.WriteLine("Valid");
                    }
                    else
                    {
                        Console.WriteLine($"Your username must contain {validChar}.");
                    }
                }

            }

        }
    }
}