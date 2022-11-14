using MediatR;
using Simple_CQRS_POC.Application.Configuration.Commands;
using Simple_CQRS_POC.Domain.Entities;
using Simple_CQRS_POC.Domain.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Simple_CQRS_POC.Application.CommandHandlers.Bids
{
    public class AddBidCommandHandler : ICommandHandler<AddBidCommand>
    {
        private readonly IRepository<Auction> repository;

        public AddBidCommandHandler(IRepository<Auction> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(AddBidCommand request, CancellationToken cancellationToken)
        {
            var auction = repository
                .Find(a => a.Id == request.AuctionId)
                .FirstOrDefault();

            if (auction == null)
            {
                throw new ValidationException("No auction found");
            }

            auction.AddBid(request.Bidder, request.BidAmount);

            await repository.SaveChangesAsync();

            throw new NotImplementedException();
        }
    }
}
