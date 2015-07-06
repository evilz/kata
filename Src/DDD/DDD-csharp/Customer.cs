using System;

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

    }
}
