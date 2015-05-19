namespace FizzBuzz_csharp
{
    public static class FizzBuzzExtension
    {
        private static bool IsDivisibleBy(this int number, int divisor)
        {
            return number%divisor == 0;
        }
        public static string FizzBuzz(this int number)
        {
            if (number.IsDivisibleBy(15)) { return "FizzBuzz"; }
            if (number.IsDivisibleBy(3)) { return "Fizz"; }
            if (number.IsDivisibleBy(5)) { return "Buzz"; }
            
            return number.ToString();
        }
    }
}
