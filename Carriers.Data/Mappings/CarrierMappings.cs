using Carriers.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Carriers.Data.Mappings
{
    internal partial class CarrierMappings : EntityTypeConfiguration<Carrier>
    {
        public CarrierMappings()
        {
            ToTable("Carrier");
            HasKey(e => e.Id);

            Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).HasColumnName("Name").IsRequired().IsUnicode(false).HasMaxLength(128);
            Property(t => t.Description).HasColumnName("Description").IsRequired().IsUnicode(false).HasMaxLength(512);


        }

    }
}
