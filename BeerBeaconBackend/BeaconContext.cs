using BeerBeaconLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BeerBeaconBackend
{
    public class BeaconContext : DbContext
    {
        private DbContextOptionsBuilder<BeaconContext> optionsBuilder;
        private string ConnectionString = "Data Source=beerbeacondbserver.database.windows.net;Initial Catalog=BeerBeaconDB;Integrated Security=False;User ID=dbserverlogin;Password=P3tt3rN1kl45;Connect Timeout=60;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public BeaconContext(DbContextOptions<BeaconContext> options)
        : base(options)
        {
            if (optionsBuilder == null)
            {
                optionsBuilder = new DbContextOptionsBuilder<BeaconContext>();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        public BeaconContext() { }

        public DbSet<Beacon> Beacons { get; set; }
        public DbSet<Buddy> Buddies { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Beacon>().ToTable("Beacon");
            builder.Entity<Buddy>().ToTable("Buddy");
            builder.Entity<User>().ToTable("User");

            builder.Entity<Beacon>()
                .HasOne(b => b.User)
                .WithMany(b => b.Beacons)
                .HasForeignKey(k => k.UserId);

            builder.Entity<User>()
                .HasMany(u => u.Beacons)
                .WithOne(u => u.User)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Buddy>()
                .HasOne(b => b.User);
            builder.Entity<Buddy>()
                .HasOne(b => b.Beacon);
                
                


        }
    }
}
