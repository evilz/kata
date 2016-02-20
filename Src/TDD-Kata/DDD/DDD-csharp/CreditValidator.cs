using System;
using System.Collections.Generic;
using System.Linq;

namespace DDD_csharp
{
    public interface ICreditValidation
    {
        bool Validate(Customer customer, Credit credit);
    }

    public class CreditValidator : ICreditValidation
    {
        public CreditValidator(IEnumerable<ICreditValidation> rules)
        {
            Rules = rules;
        }

        public IEnumerable<ICreditValidation> Rules { get; set; } 
        
        public bool Validate(Customer customer, Credit credit)
        {
            return Rules.All(r => r.Validate(customer, credit));
            
        }
    }

    public class BalanceValidationRule : ICreditValidation
    {
        public int MinPercentBalanceNeeded { get; private set; }

        public BalanceValidationRule(int minPercentBalanceNeeded)
        {
            MinPercentBalanceNeeded = minPercentBalanceNeeded;
        }

        public bool Validate(Customer customer, Credit credit)
        {
            return customer.Balance > credit.Amount*MinPercentBalanceNeeded/100;
        }
    }

    public class SalaryValidationRule : ICreditValidation
    {
        public int GreaterMensualityCount { get; set; }

        public SalaryValidationRule(int greaterMensualityCount)
        {
            GreaterMensualityCount = greaterMensualityCount;
        }

        public bool Validate(Customer customer, Credit credit)
        {
            return customer.Salary > GreaterMensualityCount * credit.Mensuality;
        }
    }
}
