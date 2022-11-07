using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simple_CQRS_POC.Domain.Entities;

namespace Simple_CQRS_POC.Persistance.Mappings
{
    public class BidMappingConfiguration : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> builder)
        {
            builder.ToTable("Bid")
                .HasKey(x => x.Id);

            builder.HasOne(x => x.Auction)
                .WithMany(x => x.Bids);
        }
    }
}
