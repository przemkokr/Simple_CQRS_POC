using Simple_CQRS_POC.Domain.Enums;

namespace Simple_CQRS_POC.Application.Models
{
    public class AuctionItemModel
    {
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public Category Category { get; set; }

        public bool IsNew { get; set; }
    }
}
