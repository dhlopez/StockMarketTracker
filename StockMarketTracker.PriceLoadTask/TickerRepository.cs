namespace StockMarketTracker.PriceLoadTask
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

        public void Delete(Ticker ticker)
        {
            stockMarketContext.Tickers.Remove(ticker);
            stockMarketContext.SaveChanges();
        }

        public List<Ticker> GetAll()
        {
            return stockMarketContext.Tickers.ToList();
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
