using Carriers.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Carriers.Data.Mappings
{
    internal partial class RatingMappings : EntityTypeConfiguration<Rating>
    {
        public RatingMappings()
        {
            ToTable("Rating");
            HasKey(e => e.Id);

            Property(t => t.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.CarrierId).HasColumnName("CarrierId").IsRequired();
            Property(t => t.UserId).HasColumnName("UserId").IsRequired();
            Property(t => t.UserName).HasColumnName("UserName").IsRequired().IsUnicode(false).HasMaxLength(512);
            Property(t => t.RatingValue).HasColumnName("RatingValue").IsRequired();
            Property(t => t.Comment).HasColumnName("Comment").IsRequired().IsUnicode(false).HasMaxLength(512);
            
            HasRequired(p => p.Carrier).WithMany(p => p.Ratings).HasForeignKey(p => p.CarrierId);

        }

    }
}
