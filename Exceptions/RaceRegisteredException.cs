using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasCorridas.Exception
{
    public class RaceRegisteredException : FormatException
    {
        public RaceRegisteredException()
            : base("Está corrida já está cadastrada") { }
    }
}
