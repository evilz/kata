namespace FizzBuzz.csharp
{
    public static class FizzBuzzHelper
    {
        public static string FizzBuzz(this int val)
        {
            if (val % 3 == 0 && val % 5 == 0)
            {
                return "FizzBuzz";
            }
            if (val%3 == 0)
            {
                return "Fizz";
            }
            if (val%5 == 0)
            {
                return "Buzz";
            }
            
            return val.ToString();
        }
    }
}
