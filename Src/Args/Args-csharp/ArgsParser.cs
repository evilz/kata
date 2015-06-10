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

        public Dictionary<string, Arg> Parse(IEnumerable<string> args)
        {
            // clone val
            var result = GetDefaultResult();

            Arg currentSpec = null;

            foreach (var arg in args)
            {
                if (IsFlag(arg))
                {
                    currentSpec = GetSpecFor(arg);
                    SetTrueIfBoolean(currentSpec, result);
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

        private static Arg SetTrueIfBoolean(Arg currentSpec, Dictionary<string, Arg> result)
        {
            if (currentSpec.Type == typeof (bool))
            {
                result[currentSpec.Flag].Value = true;
                currentSpec = null;
            }
            return currentSpec;
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

        private Dictionary<string, Arg> GetDefaultResult()
        {
            var defaultValues = new Arg[Spec.Count];
            Spec.Values.CopyTo(defaultValues, 0);
            var result = defaultValues.ToDictionary(arg => arg.Flag, arg => arg);
            return result;
        }
    }
}