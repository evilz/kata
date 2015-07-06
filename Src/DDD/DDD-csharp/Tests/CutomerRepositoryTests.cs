using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemInterface.IO;
using SystemWrapper.IO;
using NSubstitute;
using NUnit.Framework;

namespace DDD_csharp
{
    public class CutomerRepositoryTests
    {
        [Test]
        public void Should_Return_XXXX_When_YYYY()
        {
            var customer = new Customer("lastname","firstname",new DateTime(1982,10,08),2000,-1000, null);

            var lines = new List<string> { "lastname,firstname,1982/10/08,2000,1000" };

            IStreamReader reader = Substitute.For<IStreamReader>();

            var lineIndex = 0;
            reader.ReadLine().Returns(info => lines[lineIndex++]);
            //IFileStreamWrap fs = fi.Create();
            //fs.Close();
            //fi.Delete();

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
        private IStreamReader reader;
        
        public TxtCutomerRepository(IStreamReader reader, bool hasHeader = false)
        {
            this.reader = reader;
            if (hasHeader)
                reader.ReadLine();
        }

        public IEnumerable<Customer> All
        {
            get
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
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
