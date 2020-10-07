using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATOM_CTO_API.Models
{
    public class LocationPoint
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime DateAdded { get; set; }

        public LocationPoint()
        {
            DateAdded = DateTime.Now;
        }
    }
}
