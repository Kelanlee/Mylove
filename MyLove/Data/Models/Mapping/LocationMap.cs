using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Data.Models.Mapping
{
    public class LocationMap:EntityTypeConfiguration<Location>
    {
        public LocationMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Locations");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.AddressName).HasColumnName("AddressName");
            
            // Relationships

            this.HasRequired(t => t.User)
                .WithMany(t => t.Locations)
                .HasForeignKey(d => d.UserId);
        }

    }
}
