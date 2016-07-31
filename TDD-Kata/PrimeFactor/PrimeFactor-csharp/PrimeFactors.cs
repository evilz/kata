using System;
using System.Collections.Generic;
using System.Linq;

namespace PrimeFactor_csharp
{
    public static class PrimeFactors
    {
        public static IEnumerable<int> Generate(int number)
        {
            return Generate(number, new List<int>());
        }

        private static IEnumerable<int> Generate(int target, List<int> accumulator)
        {
            if (target.IsPrimeNumber())
            {
                accumulator.Add(target);
                return accumulator;
            }
            var primes = target.GetPrimes();

            foreach (var prime in primes.Where(prime => target%prime == 0))
            {
                accumulator.Add(prime);
                var next = target/prime;
                return Generate(next, accumulator);
            }

            return accumulator;
        }

        public static bool IsDivisibleBy(this int number, int divider)
        {
            return number%divider == 0;
        }
        
        public static bool IsPrimeNumber(this int number)
        {
            if (number <= 1) return false;
            for (var i = 2; i < number; i++)
            {
                if (number%i == 0)
                    return false;
            }
            return true;
        }

        public static List<int> GetPrimes(this int number)
        {
            if(number < 2) return new List<int>();
            return Enumerable.Range(2, number - 2)
                .Where(IsPrimeNumber)
                .ToList();
        }
    }
}