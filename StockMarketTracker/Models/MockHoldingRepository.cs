namespace StockMarketTracker.Models
{
    public class MockHoldingRepository : IHoldingRepository
    {
        public List<Holding> MockHoldings =>
            new List<Holding> {
                new Holding() { Id = 1, Shares = 467, Average = 6.4m, Ticker = new Ticker{ Id = 1, Symbol = "TNT", Price = 2.46m, DateLastUpdated = DateTime.Now  }},           
                new Holding() { Id = 2, Shares = 11, Average = 30, Ticker = new Ticker{ Id = 2, Symbol = "DIV.TO", Price = 2.85m, DateLastUpdated = DateTime.Now} },
                new Holding() { Id = 3, Shares = 12, Average = 40, Ticker = new Ticker() { Id = 3, Symbol = "L.TO", Price = 115, DateLastUpdated = DateTime.Now} },
            };

        public void Add(Holding holding)
        {
            MockHoldings.Add(holding);
        }

        public void Delete(Holding holding)
        {
            Holding holdingToDelete = this.GetById(holding.Id);
            if (holdingToDelete != null)
                MockHoldings.Remove(MockHoldings.Where(t => t.Id == holding.Id).First());
        }

        public List<Holding> GetAll()
        {
            return MockHoldings;
        }

        public Holding GetById(int id)
        {
            return MockHoldings.FirstOrDefault(t => t.Id == id);
        }

        public void Update(Holding holding)
        {
            throw new NotImplementedException();
        }
    }
}
