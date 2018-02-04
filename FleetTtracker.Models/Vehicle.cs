using System;
using System.Collections.Generic;

namespace FleetTracker.Model
{
    public class Vehicle
    {
        public Vehicle()
        {
            Freights = new HashSet<Freight>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Freight> Freights;
    }
}
