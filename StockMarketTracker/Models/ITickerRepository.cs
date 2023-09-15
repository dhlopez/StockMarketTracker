namespace StockMarketTracker.Models
{
    public interface ITickerRepository
    {
        public List<Ticker> GetAll();
        public Ticker GetById(int id);
        public void Add(Ticker ticker);
        public void Update(Ticker ticker);
        public void Delete(int id);
        
    }
}
