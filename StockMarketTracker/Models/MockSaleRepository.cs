namespace StockMarketTracker.Models
{
    public class MockSaleRepository : ISaleRepository
    {
        public List<Sale> MockSales =>
            new List<Sale> {
                new Sale() { Id = 1, Symbol = "T.TO", BoughtPrice = 22, SoldPrice = 25, Shares = 10, DividendAmt = 0, SoldDate = DateTime.Now},
                new Sale() { Id = 2, Symbol = "DIV.TO", BoughtPrice = 2.85m, SoldPrice = 3.0m, Shares = 11, DividendAmt = 0, SoldDate = DateTime.Now},
                new Sale() { Id = 3, Symbol = "L.TO", BoughtPrice = 115, SoldPrice = 117, Shares = 12, DividendAmt = 0, SoldDate = DateTime.Now},
            };
        public void Add(Sale sale)
        {
            MockSales.Add(sale);
        }

        public void Delete(Sale sale)
        {
            Sale saleToDelete = this.GetById(sale.Id);
            if (saleToDelete != null)
                MockSales.Remove(MockSales.Where(t => t.Id == sale.Id).First());
        }

        public List<Sale> GetAll()
        {
            return MockSales;
        }

        public Sale GetById(int id)
        {
            return MockSales.FirstOrDefault(t => t.Id == id);
        }

        public void Update(Sale ticker)
        {
            throw new NotImplementedException();
        }
    }
}
