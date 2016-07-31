using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace DDD_csharp
{
    public class CutomerRepositoryTests
    {
        [Test]
        [Ignore("TODO !!!!!")]
        public void Should_Return_XXXX_When_YYYY()
        {
            var customer = new Customer("lastname","firstname",new DateTime(1982,10,08),2000,-1000, null);

            var lines = new List<string> { "lastname,firstname,1982/10/08,2000,1000" };

            TextReader reader = new StringReader(string.Join(Environment.NewLine,lines));
        
            // Arrange
            var su = new TxtCutomerRepository(reader);

            // Act
            var result = su.All.First();

            // Assert
            Assert.AreEqual(customer.Lastname, result.Lastname);
        }
    }

    public class TxtCutomerRepository : ICutomerRepository
    {
        private TextReader reader;
        
        public TxtCutomerRepository(TextReader reader, bool hasHeader = false)
        {
            this.reader = reader;
            if (hasHeader)
                reader.ReadLine();
        }

        public IEnumerable<Customer> All
        {
            get
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {

                    yield return new Customer("","",DateTime.Today,0,0 ,"");
                }
                
            }
        }

        //private Customer ParseCustomLine(string line)
        //{
        //    var values = line.Split(',');
        //    return new Customer(
        //        values[0], 
        //        values[1], 
        //        DateTime.ParseExact("YYYY/MM/DD",values[2]), values[0], values[0], values[0], values[0]);
        //}
    }

    public interface ICutomerRepository
    {
        IEnumerable<Customer> All { get; }
    }
}
