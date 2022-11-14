using Simple_CQRS_POC.Application.Configuration.Queries;
using Simple_CQRS_POC.Domain.Entities;
using Simple_CQRS_POC.Domain.Repositories;

namespace Simple_CQRS_POC.Application.QueryHandlers.Bids
{
    public class GetAuctionBidsQueryHandler : IQueryHandler<GetAuctionBidsQuery, IEnumerable<Bid>>
    {
        private readonly IRepository<Bid> _bidRepository;

        public GetAuctionBidsQueryHandler(IRepository<Bid> bidRepository)
        {
            _bidRepository = bidRepository;
        }

        public async Task<IEnumerable<Bid>> Handle(GetAuctionBidsQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var auctionBids = _bidRepository.Find(b => b.AuctionId == request.AuctionId);

            return auctionBids.AsEnumerable();
        }
    }
}
