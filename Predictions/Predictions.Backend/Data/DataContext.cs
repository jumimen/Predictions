using Microsoft.EntityFrameworkCore;
using Predictions.Shared.Entities;

namespace Predictions.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>()
            .HasIndex(c => c.Name)
            .IsUnique();
        }
    }
}