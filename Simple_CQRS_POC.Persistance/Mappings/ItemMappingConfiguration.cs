using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Simple_CQRS_POC.Domain.Entities;

namespace Simple_CQRS_POC.Persistance.Mappings
{
    public class ItemMappingConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Item")
                .HasKey(x => x.Id);

            builder.HasOne(x => x.Auction).WithOne(x => x.AuctionItem);
        }
    }
}
