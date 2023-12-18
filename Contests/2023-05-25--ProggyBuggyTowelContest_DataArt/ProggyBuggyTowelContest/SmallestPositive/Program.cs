using System;
using System.Linq;

namespace SmallestPositive
{
    /// <summary>
    /// Given a sequence of N integers, finds the smallest positive element of it.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var min = Console.ReadLine()
                .Split(' ')
                .Skip(1)
                .Select(s => int.Parse(s))
                .Where(i => i > 0)
                .DefaultIfEmpty()
                .Min();

            Console.WriteLine(min);
        }
    }
}
