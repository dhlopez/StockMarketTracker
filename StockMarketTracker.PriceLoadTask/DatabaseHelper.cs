using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StockMarketTracker.Controllers;
using StockMarketTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketTracker.PriceLoadTask
{
    public class DatabaseHelper
    {
        //private readonly StockMarketContext dbContext;
        private readonly ITickerRepository tickerRepository;
        public DatabaseHelper(ITickerRepository tickerRepository)
        {
            //this.dbContext = dbContext;
            this.tickerRepository = tickerRepository;
        }

        //have tickers with empty price in database, empty last updated, or last updated > 1 hour
        //read from database to get first 5 where price is empty - EF
        public List<Ticker> GetTickerList(bool excludeCanadianTickers)
        {
            if(excludeCanadianTickers)
                return tickerRepository.GetAll().Where(t=>t.DateLastUpdated < (DateTime.Now.AddHours(-1)) 
                    && t.SkipPriceUpdate.Equals(false)).Take(5).ToList();

            return tickerRepository.GetAll().Where(t => t.DateLastUpdated < (DateTime.Now.AddHours(-1))).Take(5).ToList();
        }

        //update the database with those 5 prices - EF
        public void UpdateTicker(Ticker ticker)
        {
            tickerRepository.Update(ticker);
        }

    }
}
