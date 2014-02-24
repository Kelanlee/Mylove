using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class TrackingMap : EntityTypeConfiguration<Tracking>
    {
        public TrackingMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Tracking");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Tracking1).HasColumnName("Tracking");
            this.Property(t => t.TrackingType).HasColumnName("TrackingType");
            this.Property(t => t.TrackingTime).HasColumnName("TrackingTime");
            // Relationships
            this.HasRequired(t => t.TrackingType1)
                .WithMany(t => t.Trackings)
                .HasForeignKey(d => d.TrackingType);
            this.HasOptional(t => t.User)
                .WithMany(t => t.Trackings)
                .HasForeignKey(d => d.UserId);

        }
    }
}
