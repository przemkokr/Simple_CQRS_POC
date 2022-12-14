using Simple_CQRS_POC.Application.Configuration.Queries;
using Simple_CQRS_POC.Domain.Entities;
namespace Simple_CQRS_POC.Application.QueryHandlers.Bids
{
    public class GetAuctionBidsQuery : IQuery<IEnumerable<Bid>>
    {
        public long AuctionId { get; set; }
    }
}