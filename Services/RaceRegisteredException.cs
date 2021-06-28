using System;
using System.Runtime.Serialization;

namespace DatasCorridas.Services
{
    [Serializable]
    internal class RaceRegisteredException : Exception
    {
        public RaceRegisteredException()
        {
        }

        public RaceRegisteredException(string message) : base(message)
        {
        }

        public RaceRegisteredException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RaceRegisteredException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}