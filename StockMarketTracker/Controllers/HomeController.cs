using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StockMarketTracker.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;

namespace StockMarketTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StockMarketContext dbContext;

        public HomeController(ILogger<HomeController> logger, StockMarketContext dbContext)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {

            //string ticker = "\"Time Series (Daily)\": {{\"2023-08-11\": {\"open\": \"143.1200\",\"high\": \"143.4500\",\"low\": \"142.2050\",\"close\": \"143.1200\",\"volume\": \"2526433\"}}";
            
            //TickerRoot ticker =
            //    new TickerRoot() {
            //        TickerDate = "2023-08-11",
            //        TickerDetails = new List<TickerDetails>() {
            //            new TickerDetails() { Open = "143.1200", High = "143.4500", Low = "142.2050", Close = "143.1200", Volume = 2526433 }
            //        }
            //    };

            var json = new HttpClient().GetStringAsync("https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol=L.TO&apikey=CXCUIZFHI6FOM1C4");
            var results = await json;

            JObject jo = JObject.Parse(results);
            var tickerDetails = jo.SelectToken("['Time Series (Daily)']").ToObject<Dictionary<string, TickerDetails>>(); //.['2023-08-11']
                                                                                                                         //TickerRoot tickerDetails = JsonConvert.DeserializeObject<TickerRoot>(ticker);
                                                                                                                         //var tickerDetails = JsonConvert.DeserializeObject<Dictionary<string, TickerDetails>>(results);

            //return View(tickerDetails);
            return RedirectToAction("List", "Ticker");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}