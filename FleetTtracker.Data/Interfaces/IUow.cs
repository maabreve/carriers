using FleetTracker.Model;

namespace FleetTracker.Data.Contract
{
    public interface IUow
    {
        void Commit();
        IRepository<Driver> Drivers { get; }
        IRepository<Freight> Freights { get; }
        ITrackingCurrentPositionRepository TrackingCurrentPositions  { get; }
        IRepository<Vehicle> Vehicles { get; }

    }
}