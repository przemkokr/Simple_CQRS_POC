using Simple_CQRS_POC.Domain.Base;
using System.ComponentModel.DataAnnotations;

namespace Simple_CQRS_POC.Domain.Entities
{
    public class Auction : EntityBase
    {
        protected Auction() 
        {
            this.Bids = new List<Bid>();
            this.IsSold = false;
        }

        public Auction(
            string title, 
            Item auctionItem, 
            string auctionOwner,
            DateTime startDate,
            DateTime endDate,
            string description,
            decimal currentValue,
            bool isBuyNow)
            : this()
        {
            this.Title = title;
            AuctionItem = auctionItem;
            AuctionOwner = auctionOwner;
            StartDate = startDate;
            EndDate = endDate;
            Description = description;
            CurrentValue = currentValue;
            IsBuyNow = isBuyNow;
        }

        public string Title { get; protected set; } = default!;

        public Item AuctionItem { get; protected set; } = default!;

        public string AuctionOwner { get; protected set; } = default!;

        public string Winner { get; protected set; } = default!;

        public DateTime StartDate { get; protected set; }

        public DateTime EndDate { get; protected set; }

        public string Description { get; protected set; } = default!;

        public decimal CurrentValue { get; protected set; }

        public bool IsBuyNow { get; protected set; }

        public bool IsSold { get; protected set; }

        public decimal? BuyNowValue { get; protected set; }

        public ICollection<Bid> Bids { get; protected set; }

        public void SetBuyNowValue(decimal buyNowValue)
        {
            this.BuyNowValue = buyNowValue;
        }

        public void AddBid(string bidder, decimal bidAmount)
        {            
            this.Bids.Add(new Bid(this, bidder, bidAmount, DateTime.Now));

            Winner = bidder;
            CurrentValue = bidAmount;
        }

        public void BuyNow(string bidder)
        {
            this.Winner = bidder;

            // refactor to domain validation service
            CurrentValue = BuyNowValue ?? throw new ValidationException("This auction does not allow for Buy Now.");
            IsSold = true;
        }

        public void EditAuction()
        {
            /* Just to show, how all changes and state of the entity should be modified
             * Add any parameters needed to be change on this entity
             * Assign method parameters to entity properties to modify its state 
             */
        }
    }
}
