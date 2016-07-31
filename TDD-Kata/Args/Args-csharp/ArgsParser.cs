using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Args_csharp
{
    public class ArgsParser
    {
        public Dictionary<string, Arg> Spec { get; }
        
        public ArgsParser(IEnumerable<Arg> spec)
        {
            Spec = spec.ToDictionary(argSpec => argSpec.Flag, argSpec => argSpec);
        }

        public IDictionary<string, Arg> Parse(IEnumerable<string> args)
        {
            var result = GetDefaultArgsValues();

            Arg currentSpec = null;

            foreach (var arg in args)
            {
                if (IsFlag(arg))
                {
                    currentSpec = GetSpecFor(arg);
                    result = SetTrueIfBoolean(currentSpec, result);
                }
                else
                {
                    try
                    {
                        var val = TypeDescriptor.GetConverter(currentSpec.Type).ConvertFromString(arg);
                        result[currentSpec.Flag].Value = val;
                    }
                    catch (Exception e)
                    {
                        throw new ArgumentException($"value {arg} is not valid for {currentSpec.Description}",e);
                    }
                    
                    currentSpec = null;
                }

            }
            
            return result;
        }

        private static IDictionary<string, Arg> SetTrueIfBoolean(Arg currentSpec, IDictionary<string, Arg> currentValues)
        {
            if (currentSpec.Type == typeof (bool))
            {
                currentValues[currentSpec.Flag].Value = true;
            }
            return currentValues;
        }

        private Arg GetSpecFor(string flag)
        {
            flag = flag.Substring(1);
            if (!Spec.ContainsKey(flag))
            {
                throw new ArgumentException($"Unknown flag {flag}");
            }
            return Spec[flag];
        }

        private static bool IsFlag(string arg)
        {
            return arg.StartsWith("-");
        }

        private IDictionary<string, Arg> GetDefaultArgsValues()
        {
            return Spec.Values
                .ToDictionary(arg => arg.Flag, arg => arg);
        }
    }
}