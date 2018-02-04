using FleetTracker.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FleetTracker.Data.Mappings
{
    internal partial class TrackingLogMappings : EntityTypeConfiguration<TrackingLog>
    {
        public TrackingLogMappings()
        {
            ToTable("TrackingLog");
            HasKey(e => e.Id);

            Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Lat).HasColumnName("Lat").IsUnicode(false).HasMaxLength(128).IsRequired();
            Property(t => t.Lat).HasColumnName("Lat").IsUnicode(false).HasMaxLength(128).IsRequired();
            Property(t => t.Timestamp).HasColumnName("Timestamp").IsRequired();
        }
    }
}
