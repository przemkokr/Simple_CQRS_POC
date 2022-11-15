using Simple_CQRS_POC.Domain.Entities;
using Simple_CQRS_POC.Domain.Enums;

namespace Simple_CQRS_POC.Persistance.DatabaseInitializer
{
    public static class SampleDataInitilizer
    {

        public static IEnumerable<Auction> DataFeed()
        {
            return new Auction[3]
            {
                new Auction("Opel Astra III",
                    new Item("Opel Astra III 1.5 LPG", "Nice car", Category.CARS, false) { AuctionId = 1},
                    "Michael Scott",
                    DateTime.Now,
                    DateTime.Now.AddDays(7),
                    "Przedmiotem aukcji jest stary gruz opel astra",
                    2000m,
                    false) { Id = 1 },
            new Auction("Opel Astra III",
                    new Item("Opel Astra III 1.5 LPG", "Nice car", Category.CARS, false) { AuctionId = 2},
                    "Michael Scott",
                    DateTime.Now,
                    DateTime.Now.AddDays(7),
                    "Przedmiotem aukcji jest stary gruz opel astra",
                    2000m,
                    false) { Id = 2 },
            new Auction("Opel Astra III",
                    new Item("Opel Astra III 1.5 LPG", "Nice car", Category.CARS, false) { AuctionId = 3},
                    "Michael Scott",
                    DateTime.Now,
                    DateTime.Now.AddDays(7),
                    "Przedmiotem aukcji jest stary gruz opel astra",
                    2000m,
                    false) { Id = 3 }
        };
        }
    }
}
