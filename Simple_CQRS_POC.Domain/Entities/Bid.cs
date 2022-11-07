using Simple_CQRS_POC.Domain.Base;

namespace Simple_CQRS_POC.Domain.Entities
{
    public class Bid : EntityBase
    {
        protected Bid() { }

        public Bid(Auction auction, string bidder, decimal bidAmount, DateTime biddingDate)
        {
            this.Auction = auction;
            this.Bidder = bidder;
            this.BidAmount = bidAmount;
            this.BiddingDate = biddingDate;
        }
        
        public long AuctionId { get; set; }

        public virtual Auction Auction { get; } = default!;

        public string Bidder { get; protected set; } = default!;

        public decimal BidAmount { get; protected set; }

        public DateTime BiddingDate { get; protected set; }
    }
}
