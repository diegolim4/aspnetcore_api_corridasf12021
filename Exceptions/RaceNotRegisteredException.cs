using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasCorridas.Exceptions
{
    public class RaceNotRegisteredException : FormatException
    {
        public RaceNotRegisteredException()
            : base("Esta corrida não está cadastrado") { }
    }
}
