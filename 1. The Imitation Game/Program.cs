using System;
using System.Linq;

namespace _1._The_Imitation_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            string encrypted = Console.ReadLine();
          

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Decode")
                {
                    break;
                }

                string[] commands = input.Split('|').ToArray();
                string order = commands[0];

                if (order == "ChangeAll")
                {
                    char wanted = Convert.ToChar(commands[1]);
                    char change = Convert.ToChar(commands[2]);

                    while (encrypted.Contains(wanted))
                    {
                        encrypted = encrypted.Replace(wanted, change);
                    }
                }
                
                else if (order == "Insert")
                {
                    int index = int.Parse(commands[1]);
                    
                    encrypted = encrypted.Insert(index, commands[2]);
                }
                else if (order == "Move")
                {
                    int characterCoount = int.Parse(commands[1]);
                    string characters = encrypted.Substring(0, characterCoount);
                    encrypted = encrypted.Substring(characterCoount) + characters;
                }
            }

            Console.WriteLine($"The decrypted message is: {encrypted}");
        }
    }
}
