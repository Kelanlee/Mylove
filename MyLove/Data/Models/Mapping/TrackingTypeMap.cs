using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class TrackingTypeMap : EntityTypeConfiguration<TrackingType>
    {
        public TrackingTypeMap()
        {
            // Primary Key
            this.HasKey(t => t.TrackingTypeId);

            // Properties
            this.Property(t => t.Description)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TrackingType");
            this.Property(t => t.TrackingTypeId).HasColumnName("TrackingTypeId");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
