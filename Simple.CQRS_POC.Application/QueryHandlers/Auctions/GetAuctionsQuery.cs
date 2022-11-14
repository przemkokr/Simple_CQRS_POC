using Simple_CQRS_POC.Application.Configuration.Queries;
using Simple_CQRS_POC.Domain.Entities;

namespace Simple_CQRS_POC.Application.QueryHandlers.Auctions
{
    public class GetAuctionsQuery : IQuery<IEnumerable<Auction>>
    {
        public bool ActiveOnly { get; set; }
    }
}
