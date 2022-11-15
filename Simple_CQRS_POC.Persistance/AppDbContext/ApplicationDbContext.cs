using Microsoft.EntityFrameworkCore;
using Simple_CQRS_POC.Domain.Entities;

namespace Simple_CQRS_POC.Persistance.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Auction> Auctions { get; set; } = default!;

        public DbSet<Item> Items { get; set; } = default!;

        public DbSet<Bid> Bids { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            //modelBuilder.Entity<Auction>(entity =>
            //{
            //    entity.HasData
            //})
        }
    }
}
