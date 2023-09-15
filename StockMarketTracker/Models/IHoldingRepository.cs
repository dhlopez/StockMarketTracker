namespace StockMarketTracker.Models
{
    public interface IHoldingRepository
    {
        public List<Holding> GetAll();
        public Holding GetById(int id);
        public void Add(Holding holding);
        public void Update(Holding holding);
        public void Delete(Holding holding);
    }
}
