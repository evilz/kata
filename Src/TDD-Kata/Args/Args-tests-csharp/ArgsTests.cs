using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Args_csharp
{
    public class ArgsTests
    {
        [Fact]
        public void Should_take_spec_when_instanced()
        {
            var parser = new ArgsParser(new List<Arg>());
            Assert.Equal(0,parser.Spec.Count());
        }

        [Theory]
        [InlineData("Int Test", "i", -1, typeof(int))]
        [InlineData("Int Test", "i", -1.0, typeof(double))]
        //[TestCase("Int Test", "i", -1.0M, typeof(decimal))] f*cking decimal ...
        [InlineData("Int Test", "i", -1.0f, typeof(float))]
        [InlineData("String Test", "s", "", typeof(string))]
        [InlineData("bool test", "b", false, typeof(bool))]
        public void Should_give_spec_of_many_types(string desc, string flag, object val, Type expectedType)
        {
            var specs = new List<Arg> {new Arg(desc, flag, val)};
            var parser = new ArgsParser(specs);
            Assert.Equal(1, parser.Spec.Count());
            Assert.Equal(expectedType, parser.Spec[flag].Type);
        }


        [Fact]
         public void Should_return_default_values_from_specs()
        {
            var specs = new List<Arg> { new Arg("Port", "p", 80 ) };
            
            var parser = new ArgsParser(specs);

            var argsResult = parser.Parse(new string[]{});

            Assert.True(argsResult.ContainsKey("p"));
            Assert.Equal(specs[0].Value, argsResult["p"].Value);
        }

        [Fact]
        public void Should_return_parsed_arg_value()
        {
            var specs = new List<Arg> { new Arg("Port", "p", 0) };

            var parser = new ArgsParser(specs);

            var argsResult = parser.Parse(new string[] {"-p", "8080" });

            Assert.True(argsResult.ContainsKey("p"));
            Assert.Equal(8080, argsResult["p"].Value);
        }

        [Fact]
        public void Should_return_true_when_boolean_flag_is_present()
        {
            var specs = new List<Arg> { new Arg("Logging", "l", false) };

            var parser = new ArgsParser(specs);

            var argsResult = parser.Parse(new string[] { "-l"});

            Assert.True(argsResult.ContainsKey("l"));
            Assert.Equal(true, argsResult["l"].Value);
        }

        [Fact]
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

            Assert.Equal(true, argsResult["l"].Value);
            Assert.Equal(8080, argsResult["p"].Value);
            Assert.Equal("/usr/logs", argsResult["d"].Value);
        }

        [Fact]
        public void Should_throw_argexecption_when_type_is_incorrect()
        {
            var specs = new List<Arg>
            {
                new Arg("Port", "p", 0)
            };

            var parser = new ArgsParser(specs);

            Assert.Throws<ArgumentException>(() => parser.Parse("-p une_string!".Split(' '))); 
        }

        [Fact]
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
