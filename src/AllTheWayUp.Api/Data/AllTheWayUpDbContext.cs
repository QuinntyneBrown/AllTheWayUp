using AllTheWayUp.Api.Models;
using AllTheWayUp.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AllTheWayUp.Api.Data
{
    public class AllTheWayUpDbContext : DbContext, IAllTheWayUpDbContext
    {
        public DbSet<Artist> Artists { get; private set; }
        public DbSet<Track> Tracks { get; private set; }
        public AllTheWayUpDbContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AllTheWayUpDbContext).Assembly);
        }

    }
}
