using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DDD_csharp
{
    public class CreditValidatorTests
    {

        Customer _customer;

        [SetUp]
        public void Setup()
        {
            _customer = new Customer("lastname","firstname",new DateTime(1982,01,15),1000,300,"email" );
        }

        [Test]
        public void Should_return_true_by_default()
        {
            // Arrange
            var credit = new Credit(1,1);
            var su = new CreditValidator(new List<ICreditValidation>() );
            // Act
            var result = su.Validate(_customer, credit);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Should_return_false_when_customer_balance_is_not_enough()
        {
            // Arrange
            _customer.Balance = 1000;
            var credit = new Credit(10000,1);
            var su = new CreditValidator(new List<ICreditValidation>
            {
                new BalanceValidationRule(10)
            });
            // Act
            var result = su.Validate(_customer, credit);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Should_return_true_when_customer_balance_is_enough()
        {
            // Arrange
            _customer.Balance = 10000;
            var credit = new Credit(10000, 1);
            var su = new CreditValidator(new List<ICreditValidation>
            {
                new BalanceValidationRule(1)
            });
            // Act
            var result = su.Validate(_customer, credit);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void Should_return_false_when_customer_salary_is_not_enough()
        {
            // Arrange
            _customer.Salary = 1;
            var credit = new Credit(10000,2);
            var su = new CreditValidator(new List<ICreditValidation>
            {
                new SalaryValidationRule(3)
            });
            // Act
            var result = su.Validate(_customer, credit);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void Should_return_true_when_customer_salary_is_enough()
        {
            // Arrange
            _customer.Salary = 1000;
            var credit = new Credit(10000, 15);
            var su = new CreditValidator(new List<ICreditValidation>
            {
                new SalaryValidationRule(1)
            });
            // Act
            var result = su.Validate(_customer, credit);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
