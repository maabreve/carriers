using FleetTracker.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FleetTracker.Data.Mappings
{
    internal partial class DriverMappings : EntityTypeConfiguration<Driver>
    {
        public DriverMappings()
        {
            ToTable("Driver");
            HasKey(e => e.Id);

            Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).HasColumnName("Name").IsUnicode(false).HasMaxLength(128).IsRequired();

        }
    }
}
