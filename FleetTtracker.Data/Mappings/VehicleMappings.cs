using FleetTracker.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FleetTracker.Data.Mappings
{
    internal partial class VehicleMappings : EntityTypeConfiguration<Vehicle>
    {
        public VehicleMappings()
        {
            ToTable("Vehicle");
            HasKey(e => e.Id);

            Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).HasColumnName("Name").IsRequired().IsUnicode(false).HasMaxLength(128);
        }

    }
}
