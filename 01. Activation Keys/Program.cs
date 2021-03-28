using System;
using System.Linq;

namespace _01._Activation_Keys
{
    class Program
    {
        static void Main(string[] args)
        {
            string activationKey = Console.ReadLine();

            int count = activationKey.Length;

            string input = Console.ReadLine();
            while (input != "Generate")
            {
                string[] commands = input.Split(">>>", StringSplitOptions.RemoveEmptyEntries);

                string operation = commands[0];

                if (operation == "Contains")
                {
                    string findKey = commands[1];

                    if (activationKey.Contains(findKey))
                    {
                        Console.WriteLine($"{activationKey} contains {findKey}");
                    }
                    else
                    {
                        Console.WriteLine("Substring not found!");
                    }
                }
                else if (operation == "Flip")
                {
                    string direction = commands[1];
                    int startIndex = int.Parse(commands[2]);
                    int endIndex = int.Parse(commands[3]);
                    int lenght = endIndex - startIndex;
                    string startPart = activationKey.Substring(0, startIndex);
                    string endPart = activationKey.Substring(endIndex);

                    if (direction == "Upper")
                    {
                        string toUpper = activationKey.Substring(startIndex, lenght).ToUpper();
                        activationKey = startPart + toUpper + endPart;
                    }
                    else if (direction == "Lower")
                    {
                        string toLower = activationKey.Substring(startIndex, lenght).ToLower();
                        activationKey = startPart + toLower + endPart;
                    }
                    Console.WriteLine(activationKey);
                }
                else if (operation == "Slice")
                {
                    int startIndex = int.Parse(commands[1]);

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }

                    int endIndex = int.Parse(commands[2]);

                    if (endIndex > count)
                    {
                        endIndex = count - 1;
                    }

                    string startPart = activationKey.Substring(0, startIndex);
                    string endPart = activationKey.Substring(endIndex);
                    activationKey = startPart + endPart;
                    Console.WriteLine(activationKey);

                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Your activation key is: {activationKey}");
        }
    }
}
