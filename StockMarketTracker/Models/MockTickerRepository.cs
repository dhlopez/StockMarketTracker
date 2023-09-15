namespace StockMarketTracker.Models
{
    public class MockTickerRepository : ITickerRepository
    {
        private List<Ticker> MockTickers;
        public MockTickerRepository()
        {
                MockTickers =
                    new List<Ticker> {
                        new Ticker() { Id = 1, Symbol = "T.TO", Price = 22, DateLastUpdated = DateTime.Now},
                        new Ticker() { Id = 2, Symbol = "DIV.TO", Price = 2.85m, DateLastUpdated = DateTime.Now},
                        new Ticker() { Id = 3, Symbol = "L.TO", Price = 115, DateLastUpdated = DateTime.Now},
                    };
        }
         

        public void Add(Ticker ticker)
        {
            ticker.Id = 4;
            MockTickers.Add(ticker);
        }

        public void Delete(int id)
        {
            Ticker tickerToDelete = this.GetById(id);
            if(tickerToDelete != null)
                MockTickers.Remove(MockTickers.Where(t=>t.Id==id).First());
        }

        public List<Ticker> GetAll()
        {
            return MockTickers;
        }

        public Ticker GetById(int id)
        {
            Ticker ticker = MockTickers.FirstOrDefault(t => t.Id==id);
            return ticker;
        }

        public void Update(Ticker ticker)
        {
            var tickerToUpdate = MockTickers.FirstOrDefault(t=>t.Id == ticker.Id);
            if (tickerToUpdate != null)
            {
                tickerToUpdate.Symbol = ticker.Symbol;
                tickerToUpdate.Price = ticker.Price;
                tickerToUpdate.DateLastUpdated = ticker.DateLastUpdated;
            }
        }
    }
}
