using System;

namespace FleetTracker.Model
{
    public class TrackingCurrentPosition
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }

        public int FreightId { get; set; }
        public Freight Freight;
    }
}
