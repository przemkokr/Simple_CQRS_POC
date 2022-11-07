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
            bool isNew)
        {
            this.Name = name;
            this.Description = description;
            this.Category = category;
            this.IsNew = isNew;
        }

        public string Name { get; protected set; } = default!;

        public string Description { get; protected set; } = default!;

        public Category Category { get; protected set; }

        public bool IsNew { get; protected set; }

        public long AuctionId { get; protected set; }

        public virtual Auction Auction { get; protected set; } = default!;
    }
}
