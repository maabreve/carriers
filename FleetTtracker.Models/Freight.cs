using System;
using System.Collections.Generic;

namespace FleetTracker.Model
{
    public class Freight
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Vehicle Vehicle { get; set; }
        public Driver Drivers { get; set; }

        public ICollection<TrackingCurrentPosition> TrackingCurrentPositions;
    }
}
