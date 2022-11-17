using Simple_CQRS_POC.Domain.Base;
using Simple_CQRS_POC.Domain.Enums;

namespace Simple_CQRS_POC.Domain.Entities
{
    public class Item : EntityBase
    {
        protected Item() { }

        public Item(
            string name, 
            string description, 
            Category category,
            Auction auction,
            bool isNew,
            long id)
        {
          //  this.Auction = auction;
            this.AuctionId = auction.Id;
            this.Name = name;
            this.Description = description;
            this.Category = (int)category;
            this.IsNew = isNew;
            Id = id;
        }

        public string Name { get; protected set; } = null!;
        public string Description { get; protected set; } = null!;
        public int Category { get; protected set; }
        public bool IsNew { get; protected set; }
        public long AuctionId { get; protected set; }

        public virtual Auction Auction { get; protected set; } = null!;
    }
}
