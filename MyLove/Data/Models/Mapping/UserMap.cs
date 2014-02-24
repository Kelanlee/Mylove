using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.UserId);

            // Properties
            this.Property(t => t.Username)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Gender)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.PhotoRef)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Username).HasColumnName("Username");
            this.Property(t => t.Gender).HasColumnName("Gender");
            this.Property(t => t.PhotoRef).HasColumnName("PhotoRef");
            this.Property(t => t.Relationship).HasColumnName("Relationship");

            // Relationships
            this.HasOptional(t => t.User1)
                .WithMany(t => t.Users1)
                .HasForeignKey(d => d.Relationship);

        }
    }
}
