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
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>()
            .HasIndex(c => c.Name)
            .IsUnique();
            modelBuilder.Entity<Team>().HasIndex(t => new { t.CountryId, t.Name }).IsUnique();
            DisableCascadeDelete(modelBuilder);
        }

        private void DisableCascadeDelete(ModelBuilder modelBuilder)
        {
            var relationships = modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys());
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}