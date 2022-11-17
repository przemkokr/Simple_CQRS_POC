using Simple_CQRS_POC.Domain.Entities;
using Simple_CQRS_POC.Domain.Enums;
using System.Diagnostics.Metrics;

namespace Simple_CQRS_POC.Persistance.DatabaseInitializer
{
    public static class SampleDataInitilizer
    {
        public static IEnumerable<Item> ItemDataFeed(IEnumerable<Auction> auctions)
        {
            List<Item> result = new List<Item>();
            for (int i = 0; i < 1000; i++)
            {
                result.Add(new Item(GetString(i + 1), GetString(1000), Category.CARS, auctions.ElementAt(i), true, i + 1));
            }

            return result;
        }

        public static IEnumerable<Auction> DataFeed()
        {
            List<Auction> result = new List<Auction>();
            for(int i = 0; i < 1000; i++)
            {
                result.Add(new Auction(GetString(i),  GetString(10), DateTime.FromBinary(10000), DateTime.FromBinary(200001), GetString(100), 10, i % 2 == 0, i+1));
            }

            return result;
        }


        public static IEnumerable<Bid> BidDataFeed(IEnumerable<Auction> auctions)
        {
            List<Bid> result = new List<Bid>();
            for (int i = 0; i < 10000; i++)
            {
                result.Add(new Bid(auctions.ElementAt(i % 10), GetString(100), i * 10, DateTime.FromBinary(10000 + i), i + 1));
            }

            return result;
        }

        private static string GetString(int size)
        {
            string x = "x";
            for (int i = 0; i < size; i++)
                x += "x";
            return x;
        }
    }
}
