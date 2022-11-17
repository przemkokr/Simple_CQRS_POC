using Simple_CQRS_POC.Domain.Base;

namespace Simple_CQRS_POC.Domain.Entities
{
    public class Bid : EntityBase
    {
        protected Bid() { }

        public Bid(Auction auction, string bidder, decimal bidAmount, DateTime biddingDate,
            long? id)
        {
            //this.Auction = auction;
            this.AuctionId = auction.Id;
            this.Bidder = bidder;
            this.BidAmount = bidAmount;
            this.BiddingDate = biddingDate;
            if(id!=null) Id = (long)id;
        }

        public long AuctionId { get; protected set; }
        public string Bidder { get; protected set; } = null!;
        public decimal BidAmount { get; protected set; }
        public DateTime BiddingDate { get; protected set; }

        public virtual Auction Auction { get; protected set; } = null!;
    }
}
