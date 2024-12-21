using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class TreasureHuntDbContext : DbContext
    {
        public bool UseRealtimeModel { get; set; }

        public TreasureHuntDbContext(DbContextOptions<TreasureHuntDbContext> options) : base(options)
        {

        }

        public DbSet<TreasureHuntRequestEntity> TreasureHuntRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}