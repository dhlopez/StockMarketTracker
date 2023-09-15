namespace StockMarketTracker.Models
{
    public interface ISaleRepository
    {
        public List<Sale> GetAll();
        public Sale GetById(int id);
        public void Add(Sale ticker);
        public void Update(Sale ticker);
        public void Delete(Sale ticker);
    }
}
