using System;
using System.Globalization;

namespace DDD_csharp
{
    public class Customer
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }

        public DateTime BirthDate { get; set; }
        
        public string Email { get; set; }

        public double Balance { get;  set; }
        public double Salary { get;  set; }
        
        public Customer(string lastname, string firstname, DateTime birthDate, double salary, double balance, string email)
        {
            Lastname = lastname;
            Firstname = firstname;
            BirthDate = birthDate;
            Salary = salary;
            Balance = balance;
            Email = email;
        }

        public static Customer FromCvs(string text)
        {
            string[] fields = text.Split(',');

            return new Customer(
                fields[0],
                fields[1],
                DateTime.ParseExact("YYYY/MM/dd", fields[2], CultureInfo.InvariantCulture),
                double.Parse(fields[3]),
                double.Parse(fields[4]),
                fields[5]
                );
        }

    }
}
