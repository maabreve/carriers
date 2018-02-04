using FleetTracker.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace FleetTracker.Data.Mappings
{
    internal partial class FreightMappings : EntityTypeConfiguration<Freight>
    {
        public FreightMappings()
        {
            ToTable("Freight");
            HasKey(e => e.Id);

            Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Description).HasColumnName("Description").IsUnicode(false).HasMaxLength(128).IsRequired();
            Property(t => t.Date).HasColumnName("Date").IsRequired();

            //.HasRequired(s => s.Driver)
            //    .WithRequiredPrincipal(ad => ad.);

        }
    }
}
