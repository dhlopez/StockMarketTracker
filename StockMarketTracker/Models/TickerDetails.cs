using Newtonsoft.Json;

namespace StockMarketTracker.Models
{
    public class TickerDetails
    {
        [JsonProperty(PropertyName = "1. open")]
        public string Open { get; set; }
        [JsonProperty(PropertyName = "2. high")]
        public string High { get; set; }
        [JsonProperty(PropertyName = "3. low")]
        public string Low { get; set; }
        [JsonProperty(PropertyName = "4. close")]
        public string Close { get; set; }
        [JsonProperty(PropertyName = "5. volume")]
        public int Volume { get; set; }
    }

    public class TickerRoot
    { 
        public string TickerDate { get; set; }

        public List<TickerDetails> TickerDetails { get; set; }
    }
}
