using System;

namespace Comments
{
    class Program
    {
        static void Main(string[] args)
        {
            var primesNumber = PrimeGenerator.GeneratePrimes(100);
            foreach (var num in primesNumber)
                Console.WriteLine($"This is a prime number {num}");
        }
    }
}
