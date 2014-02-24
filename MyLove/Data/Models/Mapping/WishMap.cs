using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class WishMap : EntityTypeConfiguration<Wish>
    {
        public WishMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Wishs");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Wishcontent).HasColumnName("Wishcontent");
            this.Property(t => t.WishTitle).HasColumnName("WishTitle");
            this.Property(t => t.WishStateId).HasColumnName("WishStateId");
            this.Property(t => t.WishTime).HasColumnName("WishTime");
            this.Property(t => t.ApprovalTime).HasColumnName("ApprovalTime");
            // Relationships
            this.HasRequired(t => t.WishState1)
                .WithMany(t => t.Wishes)
                .HasForeignKey(t => t.WishStateId);

            this.HasRequired(t => t.User)
                .WithMany(t => t.Wishs)
                .HasForeignKey(d => d.UserId);

        }
    }
}
