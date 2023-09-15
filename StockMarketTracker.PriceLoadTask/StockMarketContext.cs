using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace StockMarketTracker.PriceLoadTask
{
    public class StockMarketContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public StockMarketContext(DbContextOptions<StockMarketContext> options):base(options)//IConfiguration configuration
        {
            //Configuration = configuration;
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=StockMarket"));

        //}

        public DbSet<Sale> Sales { get; set; }
        public DbSet<Holding> Holdings { get; set; }
        public DbSet<Ticker> Tickers { get; set; }
    }
}