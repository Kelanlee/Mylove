using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class WishStateMap : EntityTypeConfiguration<WishState>
    {
        public WishStateMap()
        {
            // Primary Key
            this.HasKey(t => t.WishStateId);

            // Properties
            this.Property(t => t.Description)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("WishState");
            this.Property(t => t.WishStateId).HasColumnName("WishStateId");
            this.Property(t => t.Description).HasColumnName("Description");
        }
    }
}
