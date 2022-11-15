//using Simple_CQRS_POC.Domain.Entities;
//using Simple_CQRS_POC.Domain.Enums;
//using Simple_CQRS_POC.Domain.Repositories;
//using Simple_CQRS_POC.Persistance.DatabaseInitializer.Constants;
//using Simple_CQRS_POC.Persistance.Repository;

//namespace Simple_CQRS_POC.Persistance.DatabaseInitializer
//{
//    public static class SampleDataInitilizer
//    {
        
//        public static IEnumerable<Auction> DataFeed()
//        {
//            return new Auction[3]
//            {
//                new Auction("Opel Astra III",
//                    new Item("Opel Astra III 1.5 LPG", "Nice car", Category.CARS, false),
//                    "Michael Scott",
//                    DateTime.Now,
//                    DateTime.Now.AddDays(7),
//                    "Przedmiotem aukcji jest stary gruz opel astra",
//                    2000m,
//                    false);
//            new Auction("Opel Astra III",
//                    new Item("Opel Astra III 1.5 LPG", "Nice car", Category.CARS, false),
//                    "Michael Scott",
//                    DateTime.Now,
//                    DateTime.Now.AddDays(7),
//                    "Przedmiotem aukcji jest stary gruz opel astra",
//                    2000m,
//                    false);
//            new Auction("Opel Astra III",
//                    new Item("Opel Astra III 1.5 LPG", "Nice car", Category.CARS, false),
//                    "Michael Scott",
//                    DateTime.Now,
//                    DateTime.Now.AddDays(7),
//                    "Przedmiotem aukcji jest stary gruz opel astra",
//                    2000m,
//                    false);

//        }
//        }

//        private async Task CreateItems()
//        {
//            var auction1 = new Auction("Opel Astra III",
//                    new Item("Opel Astra III 1.5 LPG", "Nice car", Category.CARS, false),
//                    "Michael Scott",
//                    DateTime.Now,
//                    DateTime.Now.AddDays(7),
//                    "Przedmiotem aukcji jest stary gruz opel astra",
//                    2000m,
//                    false);
//            var auction2 = new Auction("Nike shoes",
//                    new Item("Nike AirMax 44", "Nicey shoes", Category.FASHION, true),
//                    "Joe Biden",
//                    DateTime.Now,
//                    DateTime.Now.AddDays(7),
//                    "Mam do sprzedania buty",
//                    199m,
//                    true);
//            auction2.SetBuyNowValue(249m);

//            var auction3 = new Auction("Laptop ASUS",
//                    new Item("Laptop ASUS X54H", "8 GB RAM, 25 GB HDD", Category.ELECTRONICS, true),
//                    "Sven Hannavald",
//                    DateTime.Now,
//                    DateTime.Now.AddDays(10),
//                    "Super laptop dla graczy",
//                    1488m,
//                    true);
//            auction3.SetBuyNowValue(1800m);

//            var auctions = new Auction[]
//            {
//                auction1, auction2, auction3
//            };

//            var existingAuctions = this.repository.GetAll();
//            if (existingAuctions.Count() < 3)
//            {
//                foreach (var auction in auctions)
//                {
//                    await this.repository.CreateAsync(auction);
//                }

//                await this.repository.SaveChangesAsync();
//            }
//        }
//    }
//}
