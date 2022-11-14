using Simple_CQRS_POC.Application.Configuration.Queries;
using Simple_CQRS_POC.Domain.Entities;
using Simple_CQRS_POC.Domain.Repositories;

namespace Simple_CQRS_POC.Application.QueryHandlers.Auctions
{
    public class GetAuctionsQueryHandler : IQueryHandler<GetAuctionsQuery, IEnumerable<Auction>>
    {
        private readonly IRepository<Auction> auctionRepository;

        public GetAuctionsQueryHandler(IRepository<Auction> auctionRepository)
        {
            this.auctionRepository = auctionRepository;
        }

        public async Task<IEnumerable<Auction>> Handle(GetAuctionsQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var auctions = auctionRepository.GetAll();

            return auctions.Where(a => a.EndDate > DateTime.Now).AsEnumerable();
        }
    }
}
