using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Args_csharp
{
    public class ArgsTests
    {
        [Test]
        public void Should_take_spec_when_instanced()
        {
            var parser = new ArgsParser(new List<Arg>());
            Assert.AreEqual(0,parser.Spec.Count());
        }

        [TestCase("Int Test", "i", -1, typeof(int))]
        [TestCase("Int Test", "i", -1.0, typeof(double))]
        //[TestCase("Int Test", "i", -1.0M, typeof(decimal))] f*cking decimal ...
        [TestCase("Int Test", "i", -1.0f, typeof(float))]
        [TestCase("String Test", "s", "", typeof(string))]
        [TestCase("bool test", "b", false, typeof(bool))]
        public void Should_give_spec_of_many_types(string desc, string flag, object val, Type expectedType)
        {
            var specs = new List<Arg> {new Arg(desc, flag, val)};
            var parser = new ArgsParser(specs);
            Assert.AreEqual(1, parser.Spec.Count());
            Assert.AreEqual(expectedType, parser.Spec[flag].Type);
        }


        [Test]
         public void Should_return_default_values_from_specs()
        {
            var specs = new List<Arg> { new Arg("Port", "p", 80 ) };
            
            var parser = new ArgsParser(specs);

            var argsResult = parser.Parse(new string[]{});

            Assert.IsTrue(argsResult.ContainsKey("p"));
            Assert.AreEqual(specs[0].Value, argsResult["p"].Value);
        }

        [Test]
        public void Should_return_parsed_arg_value()
        {
            var specs = new List<Arg> { new Arg("Port", "p", 0) };

            var parser = new ArgsParser(specs);

            var argsResult = parser.Parse(new string[] {"-p", "8080" });

            Assert.IsTrue(argsResult.ContainsKey("p"));
            Assert.AreEqual(8080, argsResult["p"].Value);
        }

        [Test]
        public void Should_return_true_when_boolean_flag_is_present()
        {
            var specs = new List<Arg> { new Arg("Logging", "l", false) };

            var parser = new ArgsParser(specs);

            var argsResult = parser.Parse(new string[] { "-l"});

            Assert.IsTrue(argsResult.ContainsKey("l"));
            Assert.AreEqual(true, argsResult["l"].Value);
        }

        [Test]
        public void Should_parsed_many_arg_values()
        {
            var specs = new List<Arg>
            {
                new Arg("Logging", "l", false),
                new Arg("Port", "p", 0),
                new Arg("Directory", "d", string.Empty)
            };

            var parser = new ArgsParser(specs);

            var argsResult = parser.Parse("-l -p 8080 -d /usr/logs".Split(' '));

            Assert.AreEqual(true, argsResult["l"].Value);
            Assert.AreEqual(8080, argsResult["p"].Value);
            Assert.AreEqual("/usr/logs", argsResult["d"].Value);
        }

        [Test]
        public void Should_throw_argexecption_when_type_is_incorrect()
        {
            var specs = new List<Arg>
            {
                new Arg("Port", "p", 0)
            };

            var parser = new ArgsParser(specs);

            Assert.Throws<ArgumentException>(() => parser.Parse("-p une_string!".Split(' '))); 
        }

        [Test]
        public void Should_throw_argexecption_when_flag_is_unknown()
        {
            var specs = new List<Arg>
            {
                new Arg("Port", "p", 0)
            };

            var parser = new ArgsParser(specs);

            Assert.Throws<ArgumentException>(() => parser.Parse("-u une_string!".Split(' ')));
        }
    }
}
