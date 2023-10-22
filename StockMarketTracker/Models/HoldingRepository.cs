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
            return stockMarketContext.Holdings.Include(h => h.Ticker).ToList();
        }

        public Holding GetById(int id)
        {
            return stockMarketContext.Holdings.Where(t => t.Id == id).Include(h => h.Ticker).First();
        }

        public void Update(Holding holding)
        {
            stockMarketContext.Attach(holding).State = EntityState.Modified;
            stockMarketContext.Holdings.Update(holding);
            stockMarketContext.SaveChanges();
        }
    }
}
