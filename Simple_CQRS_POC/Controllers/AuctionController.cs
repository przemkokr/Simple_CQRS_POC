using MediatR;
using Microsoft.AspNetCore.Mvc;
using Simple_CQRS_POC.Application.CommandHandlers.Auctions;
using Simple_CQRS_POC.Application.QueryHandlers.Auctions;
using Simple_CQRS_POC.Application.QueryHandlers.Bids;
using Simple_CQRS_POC.Domain.Entities;

namespace Simple_CQRS_POC.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuctionController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuctionController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Auction>> Auctions(bool activeOnly = false)
        {
            var auctions = await mediator.Send(new GetAuctionsQuery() { ActiveOnly = activeOnly });

            return auctions;
        }

        [HttpPost]
        public async Task<long> Create([FromBody] AddAuctionCommand command)
        {
            var response = await this.mediator.Send(command);

            return response.Id > 0 ? response.Id : 0;
        }


        [HttpGet]
        [Route("bids/{auctionId:long}")]
        public async Task<IEnumerable<Bid>> AuctionBids(long auctionId)
        {
            var auctionBids = await mediator.Send(new GetAuctionBidsQuery() { AuctionId= auctionId });

            return auctionBids;
        }

        [HttpPost]
        [Route("bids/{auctionId:long}")]
        public async Task<IEnumerable<Bid>> Bid(long auctionId)
        {
            var auctionBids = await mediator.Send(new GetAuctionBidsQuery() { AuctionId = auctionId });

            return auctionBids;
        }
    }
}
