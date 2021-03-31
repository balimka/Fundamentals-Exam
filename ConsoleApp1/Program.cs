using System.Linq;
using System.Collections.Generic;
using System.Text;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> numbers1 = Console.ReadLine().Split(',').Select(int.Parse).ToList();

            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                result.Add(numbers[i]);
                result.Add(numbers1[i]);
            }
            Console.Write(String.Join(',', result));
        }
    }
}