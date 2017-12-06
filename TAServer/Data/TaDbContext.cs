using Microsoft.EntityFrameworkCore;

using TAServer.Models;

namespace sfx.Data
{
    public partial class TaDbContext : DbContext
    {
        public virtual DbSet<Location> Location { get; set; }
      


        public TaDbContext(DbContextOptions<TaDbContext> options):base(options){
        }

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

            });

        }
    }
}