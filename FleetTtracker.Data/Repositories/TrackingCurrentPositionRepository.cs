using System.Data.Entity;
using System.Linq;
using FleetTracker.Model;
using FleetTracker.Data.Contract;
using System.Threading.Tasks;

namespace FleetTracker.Data
{
    public class TrackingCurrentPositionRepository : EfRepository<TrackingCurrentPosition>, ITrackingCurrentPositionRepository
    {
        public TrackingCurrentPositionRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public IQueryable<TrackingCurrentPosition> GetAll()
        {
            return DbSet;
        }
    }
}