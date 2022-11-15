using Simple_CQRS_POC.Application.Configuration.Commands;
using Simple_CQRS_POC.Domain.Entities;
using Simple_CQRS_POC.Domain.Repositories;

namespace Simple_CQRS_POC.Application.CommandHandlers.Auctions
{
    public class AddAuctionCommandHandler : ICommandHandler<AddAuctionCommand, AddAuctionResult>
    {
        private readonly IRepository<Auction> repository;

        public AddAuctionCommandHandler(IRepository<Auction> repository)
        {
            this.repository = repository;
        }

        public async Task<AddAuctionResult> Handle(AddAuctionCommand request, CancellationToken cancellationToken)
        {
            var item = new Item(request.Item.Name, request.Item.Description, request.Item.Category, request.Item.IsNew);

            var auction = new Auction(
                    request.Title,
                    item,
                    request.Username,
                    DateTime.Now,
                    request.EndDate,
                    request.Description,
                    request.InitialValue,
                    request.IsBuyNow
                );

            if (request.IsBuyNow)
            {
                auction.SetBuyNowValue(request.BuyNowValue!.Value);
            }

            await repository.CreateAsync(auction);
            await repository.SaveChangesAsync();

            return new AddAuctionResult() { Id = auction.Id };
        }
    }
}
