using Newtonsoft.Json.Linq;
using StockMarketTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketTracker.PriceLoadTask
{
    public  class RequestHandler
    {
        private string Token { get; set; }
        private string Symbol { get; set; }

        public RequestHandler(string token, string symbol)
        {
            this.Token = token;
            this.Symbol = symbol;   
        }

        //send the request to get those 5 prices
        public async Task<Dictionary<string, TickerDetails>> GetTickerDetailsAsync()
        {
           var tickerDetails = new Dictionary<string, TickerDetails>();

            try
            {
                var json = new HttpClient().GetStringAsync($"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={Symbol}&apikey={Token}");
                var results = await json;

                JObject jo = JObject.Parse(results);
                tickerDetails = jo.SelectToken("['Time Series (Daily)']").ToObject<Dictionary<string, TickerDetails>>(); //.['2023-08-11']

            }
            catch(Exception ex)
            {
                Console.WriteLine($"Couldn't get price for symbol: {Symbol}");
            }

            return tickerDetails;
        }
    }
}


