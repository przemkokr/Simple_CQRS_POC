
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Simple_CQRS_POC.Application.QueryHandlers.Auctions;
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
        public async Task<IEnumerable<Auction>> Auctions()
        {
            var auctions = await mediator.Send(new GetAuctionsQuery());

            return auctions;
        }
    }
}
