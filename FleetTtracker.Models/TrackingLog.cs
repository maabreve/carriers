using System;

namespace FleetTracker.Model
{
    public class TrackingLog
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }

        public int FreightId { get; set; }
        public Freight Freight;
    }
}
