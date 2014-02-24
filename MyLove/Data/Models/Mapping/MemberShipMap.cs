using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Data.Models.Mapping
{
    public class MemberShipMap : EntityTypeConfiguration<MemberShip>
    {
        public MemberShipMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UserId, t.Password });

            // Properties
            this.Property(t => t.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Password)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("MemberShip");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.WrongTime).HasColumnName("WrongTime");

            // Relationships
            this.HasRequired(t => t.User)
                .WithMany(t => t.MemberShips)
                .HasForeignKey(d => d.UserId);

        }
    }
}
