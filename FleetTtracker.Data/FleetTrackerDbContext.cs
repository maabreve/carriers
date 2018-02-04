using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using FleetTracker.Model;
using FleetTracker.Data.Mappings;

namespace FleetTracker.Data
{
    public class FleetTrackerDbContext : DbContext

    {
        public FleetTrackerDbContext()
            : base(nameOrConnectionString: "DefaultConnection")
        {
           Configuration.ProxyCreationEnabled = false;
        }

        public static FleetTrackerDbContext Create()
        {
            return new FleetTrackerDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new DriverMappings());
            modelBuilder.Configurations.Add(new FreightMappings());
            modelBuilder.Configurations.Add(new TrackingCurrentPositionMappings());
            modelBuilder.Configurations.Add(new TrackingLogMappings());
            modelBuilder.Configurations.Add(new VehicleMappings());

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

        }

        public virtual DbSet<Driver> Drivers{ get; set; }
        public virtual DbSet<Freight> Freights { get; set; }
        public virtual DbSet<TrackingCurrentPosition> TrackingCurrentPositions { get; set; }
        public virtual DbSet<TrackingLog> TrackingLogs { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }

    }
}