using System;
using System.Linq;
using System.Threading.Tasks;

namespace MiniPricer_csharp
{

    public enum VolatilityChangeTypes
    {
        Up = 0,
        Down = 1,
        None = 2
    }

    public class Pricer
    {
        private readonly Func<double, double> _getVolatility = GetNextRandomVolatility;
        private readonly Func<DateTime, bool> _isDayOff = IsWeekEndDayOffChecker;

        public Pricer()
        {
        }

        public Pricer(Func<DateTime, bool> isDayOff)
        {
            if (isDayOff != null)
            {
                _isDayOff = isDayOff;
            }
        }

        public Pricer(Func<DateTime, bool> isDayOff, Func<double, double> getVolatility)
        {
            if (getVolatility != null) { _getVolatility = getVolatility; }
            if (isDayOff != null) { _isDayOff = isDayOff; }
        }

        public double GetPriceFor(DateTime today, DateTime futureDate, double currentPrice, double averageVolatility)
        {
            var numberOfDays = futureDate.Subtract(today).Days;
            var currentDay = today;
            var newPrice = currentPrice;
            for (int i = 0; i < numberOfDays; i++)
            {
                currentDay = currentDay.AddDays(1);
                if (!_isDayOff(currentDay))
                {
                    newPrice *= (1 + _getVolatility(averageVolatility) / 100);
                }
            }
            return newPrice;
        }

        public static bool IsWeekEndDayOffChecker(DateTime currentDay)
        {
            return currentDay.DayOfWeek == DayOfWeek.Saturday || currentDay.DayOfWeek == DayOfWeek.Sunday;
        }


        static readonly Random _randomForVolatility = new Random();
        public static double GetNextRandomVolatility(double currentVolatility)
        {
            var nextVolatilityChange = (VolatilityChangeTypes)_randomForVolatility.Next(3);

            switch (nextVolatilityChange)
            {
                case VolatilityChangeTypes.Up:
                    return Math.Abs(currentVolatility);
                case VolatilityChangeTypes.Down:
                    return 0 - Math.Abs(currentVolatility);
                case VolatilityChangeTypes.None:
                    return 0;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static Func<double, double> GetMonteCarloVolatilityFor(int times, Func<double, double> getVolatility)
        {
            return volatility =>
            {
                var volatilities = new double[times];
                var result = Parallel.For(0, times, i =>
                {
                    volatilities[i] = getVolatility(volatility);
                });


                
                return volatilities.Average();
            };
        }
    }
}