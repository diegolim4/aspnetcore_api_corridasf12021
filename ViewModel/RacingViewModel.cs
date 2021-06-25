using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatasCorridas.ViewModel
{
    public class RacingViewModel
    {
        public Guid Id { get; set; }
        public string Country { get; set; }

        public string City { get; set; }

        public int Date { get; set; }

        public double Hour { get; set; }
    }
}
