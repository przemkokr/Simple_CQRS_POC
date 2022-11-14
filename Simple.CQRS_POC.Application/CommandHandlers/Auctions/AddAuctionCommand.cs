using Simple_CQRS_POC.Application.Configuration.Commands;
using Simple_CQRS_POC.Application.Models;

namespace Simple_CQRS_POC.Application.CommandHandlers.Auctions
{
    public class AddAuctionCommand : ICommand<AddAuctionResult>
    {
        public Guid Id => new Guid();        

        public AuctionItemModel Item { get; set; }

        public string Username { get; set; } = default!;

        public string Title { get; set; } = default!;

        public DateTime EndDate { get; set; }

        public string Description { get; set; } = default!;

        public bool IsBuyNow { get; set; }

        public decimal? BuyNowValue { get; set; }

        public decimal InitialValue { get; set; }
    }
}
