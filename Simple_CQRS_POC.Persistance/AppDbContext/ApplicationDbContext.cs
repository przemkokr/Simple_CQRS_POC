using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Simple_CQRS_POC.Domain.Entities;
using Simple_CQRS_POC.Persistance.DatabaseInitializer;

namespace Simple_CQRS_POC.Persistance.AppDbContext
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auction> Auctions { get; set; } = null!;
        public virtual DbSet<Bid> Bids { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=SampleApp;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var auctionFeed = SampleDataInitilizer.DataFeed();
            var itemsFeed = SampleDataInitilizer.ItemDataFeed(auctionFeed);
            var bidsFeed = SampleDataInitilizer.BidDataFeed(auctionFeed);

            modelBuilder.Entity<Auction>(entity =>
            {
                entity.ToTable("Auction");

                entity.HasIndex(e => e.Id, "IX_Auction_Id")
                    .IsUnique();

                entity.Property(e => e.BuyNowValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CurrentValue).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Title).HasMaxLength(1006);

                //foreach (var item in SampleDataInitilizer.DataFeed())
                //{
                //    entity.HasData(item);
                //}
            });

            modelBuilder.Entity<Bid>(entity =>
            {
                entity.ToTable("Bid");

                entity.HasIndex(e => e.AuctionId, "IX_Bid_AuctionId");

                entity.Property(e => e.BidAmount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Auction)
                    .WithMany(p => p.Bids)
                    .HasForeignKey(d => d.AuctionId);

                //foreach (var item in bidsFeed)
                //{
                //    entity.HasData(item);
                //}
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Item");

                entity.HasIndex(e => e.AuctionId, "IX_Item_AuctionId")
                    .IsUnique();

                entity.HasOne(d => d.Auction)
                    .WithOne(p => p.Item)
                    .HasForeignKey<Item>(d => d.AuctionId);


                //foreach (var item in itemsFeed)
                //{
                //    entity.HasData(item);
                //}
            }
            );



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
