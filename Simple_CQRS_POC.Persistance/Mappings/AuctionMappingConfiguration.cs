using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simple_CQRS_POC.Domain.Entities;

namespace Simple_CQRS_POC.Persistance.Mappings
{
    public class AuctionMappingConfiguration : IEntityTypeConfiguration<Auction>
    {
        public void Configure(EntityTypeBuilder<Auction> builder)
        {
            builder.ToTable("Auction")
                .HasKey(x => x.Id);
            builder.Property(t => t.Title)
              .HasMaxLength(100)
              .IsRequired();
            builder.HasIndex(x => x.Id)
                .IsUnique(true);
            builder.HasOne(x => x.AuctionItem)
                .WithOne(x => x.Auction)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Bids)
                .WithOne(x => x.Auction)
                .HasForeignKey(x => x.AuctionId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
