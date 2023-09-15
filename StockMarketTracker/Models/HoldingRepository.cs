using Microsoft.EntityFrameworkCore;

namespace StockMarketTracker.Models
{
    public class HoldingRepository : IHoldingRepository
    {
        private readonly StockMarketContext stockMarketContext;

        public HoldingRepository( StockMarketContext stockMarketContext)
        {
            this.stockMarketContext = stockMarketContext;
        }
        public void Add(Holding holding)
        {
            stockMarketContext.Holdings.Add(holding);
            stockMarketContext.SaveChanges();
        }

        public void Delete(Holding holding)
        {
            throw new NotImplementedException();
        }

        public List<Holding> GetAll()
        {
            return stockMarketContext.Holdings.Include("Ticker").ToList();
        }

        public Holding GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Holding holding)
        {
            throw new NotImplementedException();
        }
    }
}
