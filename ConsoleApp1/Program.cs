using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(',').Select(int.Parse).ToList();
            List<int> missing = new List<int>();

            for (int i = 1; i <= numbers.Count; i++)
            {
                if (numbers.Contains(i))
                {

                }
                else
                {
                    missing.Add(i);
                }
            }

            Console.Write(String.Join(",", missing));
        }
    }
}