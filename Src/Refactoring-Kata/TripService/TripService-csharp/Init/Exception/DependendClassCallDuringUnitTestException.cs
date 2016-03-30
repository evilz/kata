using System;
using System.Runtime.Serialization;

namespace TripService_csharp.Init.Exception
{
    [Serializable]
    public class DependendClassCallDuringUnitTestException : System.Exception
    {
        public DependendClassCallDuringUnitTestException() : base() { }

        public DependendClassCallDuringUnitTestException(string message, System.Exception innerException) : base(message, innerException) { }

        public DependendClassCallDuringUnitTestException(string message) : base(message) { }

        private DependendClassCallDuringUnitTestException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
