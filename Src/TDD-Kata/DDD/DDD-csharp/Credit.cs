namespace DDD_csharp
{
    public class Credit
    {
        public Credit(double amount, int monthlyPaymentCount)
        {
            Amount = amount;
            MonthlyPaymentCount = monthlyPaymentCount;
        }

        public double Mensuality => Amount/ MonthlyPaymentCount;


        public double Amount { get; private set; }
        public int MonthlyPaymentCount { get; set; }
    }
}