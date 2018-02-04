using PowerEvent.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace PowerEvent.Data.Mappings
{
    internal partial class EventTypeMappings : EntityTypeConfiguration<EventType>
    {
        public EventTypeMappings()
        {
            ToTable("EventType");
            HasKey(e => e.Id);

            Property(t => t.Name).HasColumnName("Name").IsRequired().IsUnicode(false).HasMaxLength(256);

            Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

    }
}
