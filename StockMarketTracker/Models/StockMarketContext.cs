using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace StockMarketTracker
{
    public class StockMarketContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public StockMarketContext(IConfiguration configuration)
        {
                Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

        }

        public DbSet<Sale> Sales { get; set; }
        public DbSet<Holding> Holdings { get; set; }
        public DbSet<Ticker> Tickers { get; set; }
    }
}