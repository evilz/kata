using System;

namespace Args_csharp
{
    public class Arg
    {
        public Arg(string description, string flag, object value)
        {
            Description = description;
            Flag = flag;
            Value = value;
        }

        public string Description { get; }
        public string Flag { get; }
        public object Value { get; set; }

        public Type Type => Value.GetType();
    }
}