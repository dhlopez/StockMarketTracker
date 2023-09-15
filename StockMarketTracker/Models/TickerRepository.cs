namespace StockMarketTracker.Models
{
    public class TickerRepository : ITickerRepository
    {
        private readonly StockMarketContext stockMarketContext;

        public TickerRepository(StockMarketContext stockMarketContext)
        {
            this.stockMarketContext = stockMarketContext;
        }

        public void Add(Ticker ticker)
        {
            stockMarketContext.Tickers.Add(ticker);
            stockMarketContext.SaveChanges();
        }

        public void Delete(int id)
        {
            Ticker ticker = GetById(id);
            stockMarketContext.Tickers.Remove(ticker);
            stockMarketContext.SaveChanges();
        }

        public List<Ticker> GetAll()
        {
            return stockMarketContext.Tickers.OrderBy(t=>t.Symbol).ToList();
        }

        public Ticker GetById(int id)
        {
            return stockMarketContext.Tickers.Where(t => t.Id == id).First();
        }

        public void Update(Ticker ticker)
        {
            stockMarketContext.Update(ticker);
            stockMarketContext.SaveChanges();
        }
    }
}
