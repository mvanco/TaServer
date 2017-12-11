using Microsoft.EntityFrameworkCore;

using TAServer.Models;

namespace sfx.Data
{
    public partial class TrainAlertDBContext : DbContext
    {
        public virtual DbSet<Location> Location { get; set; }
        
        public virtual DbSet<POI> POI { get; set; }

        public TrainAlertDBContext(DbContextOptions<TrainAlertDBContext> options):base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //build the user tables

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("location");

                entity.Property(l => l.id)
                    .HasColumnName("id");

                entity.Property(l => l.longitude)
                    .HasColumnName("longitude");

                entity.Property(l => l.latitude)
                    .HasColumnName("latitude");

            });

            modelBuilder.Entity<POI>(entity =>
            {
                entity.ToTable("poi");

                entity.Property(l => l.id)
                    .HasColumnName("id");

                entity.Property(l => l.title)
                    .HasColumnName("title");

                entity.Property(l => l.latitude)
                    .HasColumnName("latitude");

                entity.Property(l => l.longitude)
                    .HasColumnName("longitude");

                entity.Property(l => l.type)
                    .HasColumnName("type");
            });

        }
    }
}