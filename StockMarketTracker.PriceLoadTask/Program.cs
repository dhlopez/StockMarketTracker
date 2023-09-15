using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using StockMarketTracker.Models;
using System.Timers;
using Timer = System.Timers.Timer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace StockMarketTracker.PriceLoadTask
{
    public class Program
    {
        private static Timer aTimer;

        private static ITickerRepository tickerRepository;
        public static StockMarketContext stockMarketContext;

        private static DatabaseHelper databaseHelper;

        public static void Main()
        {
            var services = new ServiceCollection();

            services.AddTransient<ITickerRepository, TickerRepository>();
            services.AddDbContext<StockMarketContext>(options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB; Initial Catalog=StockMarket"),ServiceLifetime.Transient);
                
                
                

            // create service provider 
            var serviceProvider = services.BuildServiceProvider();
            stockMarketContext = serviceProvider.GetService<StockMarketContext>();
            tickerRepository = serviceProvider.GetService<ITickerRepository>();


            databaseHelper = new DatabaseHelper(tickerRepository);
            SetTimer();

            Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
            Console.ReadLine();
            aTimer.Stop();
            aTimer.Dispose();

            Console.WriteLine("Terminating the application...");
        }

        private static void SetTimer()
        {
            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(80000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEventAsync;            
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private async static void OnTimedEventAsync(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("Starting pulse at {0:HH:mm:ss.fff}",e.SignalTime);

            //have tickers with empty price in database, empty last updated, or last updated > 1 hour
            //read from database to get first 5 where price is empty - EF
            //send the request to get those 5 prices
            //update the database with those 5 prices - EF
            //kill/stop/sleep the services for 1 minute before starting again

            //var json = new HttpClient().GetStringAsync("https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=L.TO&apikey=CXCUIZFHI6FOM1C4");
            Console.WriteLine("Starting tickers to update retrieval from local db");
            var tickersToUpdate = databaseHelper.GetTickerList();

            Console.WriteLine($"Found {tickersToUpdate.Count} tickers, if > 0 starting external api call");
            foreach (var ticker in tickersToUpdate)
            {
                Console.WriteLine($"Calling api for {ticker.Symbol}");
                RequestHandler requestHandler = new RequestHandler("CXCUIZFHI6FOM1C4", ticker.Symbol);
                var tickerResults = await requestHandler.GetTickerDetailsAsync();

                Console.WriteLine($"Setting received price for {ticker.Symbol} from external api");
                ticker.Price = Decimal.Parse(tickerResults[DateTime.Now.ToString("yyyy-MM-dd")].Close);
                ticker.DateLastUpdated = DateTime.Now;
                //tickerResults.Where(t => t.Key.Equals(DateTime.Now.ToShortDateString())).Select(V));

                databaseHelper.UpdateTicker(ticker);
                Console.WriteLine($"All done for {ticker.Symbol}, moving to next symbol if any");
            }
        }
    }
}