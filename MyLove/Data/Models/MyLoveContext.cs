using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Data.Models.Mapping;

namespace Data.Models
{
    public partial class MyLoveContext : DbContext
    {
        static MyLoveContext()
        {
            Database.SetInitializer<MyLoveContext>(null);
        }

        public MyLoveContext()
            : base("Name=MyLoveContext")
        {
        }

        public DbSet<MemberShip> MemberShips { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Tracking> Trackings { get; set; }
        public DbSet<TrackingType> TrackingTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wish> Wishs { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MemberShipMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TrackingMap());
            modelBuilder.Configurations.Add(new TrackingTypeMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new WishMap());
            modelBuilder.Configurations.Add(new LocationMap());
        }
    }
}
