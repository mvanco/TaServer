using Microsoft.EntityFrameworkCore;

using TaServer.Models;

namespace sfx.Data
{
    public partial class TrainAlertDbContext : DbContext
    {
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Poi> Pois { get; set; }

        public TrainAlertDbContext(DbContextOptions<TrainAlertDbContext> options):base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //build the user tables

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("location");

                entity.Property(l => l.Id)
                    .HasColumnName("id");

                entity.Property(l => l.Longitude)
                    .HasColumnName("longitude");

                entity.Property(l => l.Latitude)
                    .HasColumnName("latitude");

                entity.Property(l => l.Time)
                    .HasColumnName("time");
            });

            modelBuilder.Entity<Poi>(entity =>
            {
                entity.ToTable("poi");

                entity.Property(l => l.Id)
                    .HasColumnName("id");

                entity.Property(l => l.Title)
                    .HasColumnName("title");

                entity.Property(l => l.Latitude)
                    .HasColumnName("latitude");

                entity.Property(l => l.Longitude)
                    .HasColumnName("longitude");

                entity.Property(l => l.Type)
                    .HasColumnName("type");
            });
        }
    }
}