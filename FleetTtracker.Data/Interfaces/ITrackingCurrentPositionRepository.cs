using FleetTracker.Model;
using System.Data.Entity;
using System.Linq;

namespace FleetTracker.Data.Contract
{
    public interface ITrackingCurrentPositionRepository  : IRepository<TrackingCurrentPosition>
    {
        IQueryable<TrackingCurrentPosition> GetAll();
    }
}
