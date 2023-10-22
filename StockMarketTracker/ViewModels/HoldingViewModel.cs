using Microsoft.AspNetCore.Mvc.Rendering;

namespace StockMarketTracker.ViewModels
{
   

    public class HoldingViewModel
    {
        public List<SelectListItem> TickersSelectList = new List<SelectListItem>();

        public string SelectedTicker;

        public List<Ticker> Tickers = new List<Ticker>();

        public Holding holding = new Holding();

        public HoldingViewModel(List<Ticker> tickers, Holding holding)
        {
            this.Tickers = tickers;
            this.holding = holding;
        }
    }
}
