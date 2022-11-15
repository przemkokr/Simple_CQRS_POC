using Simple_CQRS_POC.Application.Configuration.Commands;

namespace Simple_CQRS_POC.Application.CommandHandlers.Bids
{
    public class AddBidCommand : ICommand
    {
        public Guid Id => new Guid();

        public long AuctionId { get; set; }

        public decimal BidAmount { get; set; }

        public string Bidder { get; set; } = default!;
    }
}
