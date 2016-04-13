using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Microsoft.AspNet.Identity.EntityFramework;
using Carriers.Model;
using Carriers.Data.Mappings;

namespace Carriers.Data
{
    public class CarriersDbContext : DbContext
    {
        public CarriersDbContext()
            : base(nameOrConnectionString: "DefaultConnection")
        {
           Configuration.ProxyCreationEnabled = false;
        }

        public static CarriersDbContext Create()
        {
            return new CarriersDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new CarrierMappings());
            modelBuilder.Configurations.Add(new RatingMappings());

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

        }

        public virtual DbSet<Carrier> Carriers { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
    }
}