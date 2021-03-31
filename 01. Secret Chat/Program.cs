using System;
using System.Linq;

namespace _01._Secret_Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();

            while (true)
            {
                string input = Console.ReadLine();

                if(input == "Reveal")
                {
                    break;
                }

                string[] tokens = input.Split(":|:");
                string command = tokens[0];

                switch (command)
                {
                    case "InsertSpace":
                        string insertSpace = " ";
                        int index = int.Parse(tokens[1]);
                        message = message.Insert(index, insertSpace);
                        Console.WriteLine(message);
                        break;
                    case "Reverse":
                        string substringReverse = tokens[1];
                        if(message.Contains(substringReverse))
                        {
                            int indexR = message.IndexOf(substringReverse);
                            message = message.Remove(indexR, substringReverse.Length);
                            substringReverse = string.Concat(substringReverse.Reverse());
                            message = message.Insert(message.Length, substringReverse);
                            Console.WriteLine(message);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "ChangeAll":
                        string substring = tokens[1];
                        string replacement = tokens[2];
                        message = message.Replace(substring, replacement);
                        Console.WriteLine(message);
                        break;
                }
            }

            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
