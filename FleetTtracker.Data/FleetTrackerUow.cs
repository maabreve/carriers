using System;
using FleetTracker.Data.Contract;
using FleetTracker.Model;

namespace FleetTracker.Data
{
    public class FleetTrackerUow : IUow, IDisposable
    {
        public FleetTrackerUow(IRepositoryProvider repositoryProvider)
        {
            CreateDbContext();

            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }

        public IRepository<Driver> Drivers { get { return GetStandardRepo<Driver>(); } }
        public IRepository<Freight> Freights { get { return GetStandardRepo<Freight>(); } }
        public IRepository<TrackingCurrentPosition> Trackings { get { return GetStandardRepo<TrackingCurrentPosition>(); } }
        public IRepository<Vehicle> Vehicles { get { return GetStandardRepo<Vehicle>(); } }
        public ITrackingCurrentPositionRepository TrackingCurrentPositions { get { return GetRepo<ITrackingCurrentPositionRepository>(); } }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        protected void CreateDbContext()
        {
            DbContext = new FleetTrackerDbContext();
            DbContext.Configuration.ProxyCreationEnabled = false;
            DbContext.Configuration.LazyLoadingEnabled = false;
            DbContext.Configuration.ValidateOnSaveEnabled = false;
        }

        protected IRepositoryProvider RepositoryProvider { get; set; }

        private IRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        private FleetTrackerDbContext DbContext { get; set; }
        
        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        #endregion
    }
}