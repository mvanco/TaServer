using Microsoft.EntityFrameworkCore;

using TAServer.Models;

namespace sfx.Data
{
    public partial class TrainAlertDBContext : DbContext
    {
        public virtual DbSet<Location> Location { get; set; }

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

        }
    }
}