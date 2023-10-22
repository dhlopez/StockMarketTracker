using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.Internal;
using StockMarketTracker.Models;
using StockMarketTracker.ViewModels;

namespace StockMarketTracker.Controllers
{
    public class HoldingController : Controller
    {
        private readonly IHoldingRepository holdingRepository;
        private readonly ITickerRepository tickerRepository;

        public HoldingController(IHoldingRepository holdingRepository, ITickerRepository tickerRepository)
        {
            this.holdingRepository = holdingRepository;
            this.tickerRepository = tickerRepository;
        }
        public IActionResult List()
        {
            return View(holdingRepository.GetAll());
        }

        public IActionResult Create()
        {
            //return View();
            List<Ticker> tickers = tickerRepository.GetAll();
            Holding holding = new Holding(); //holdingRepository.GetById(id);

            var model = new HoldingViewModel(tickers, holding);

            foreach (Ticker ticker in tickers)
            {
                model.TickersSelectList.Add(new SelectListItem { Text = ticker.Symbol, Value = ticker.Id.ToString() });
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Holding holding)
        {
            holdingRepository.Add(holding);
            return RedirectToAction("List");
        }

        public IActionResult Edit(int id)
        {
            List<Ticker> tickers = tickerRepository.GetAll();
            Holding holding = holdingRepository.GetById(id);

            var model = new HoldingViewModel(tickers, holding);

            foreach (Ticker ticker in tickers)
            {
                model.TickersSelectList.Add(new SelectListItem { Text = ticker.Symbol, Value = ticker.Id.ToString() });
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(HoldingViewModel holdingViewModel)
        {
            string ticker = holdingViewModel.SelectedTicker;

            if (!ModelState.IsValid)
            {
                return View(holdingViewModel.holding);
                
            }

            holdingRepository.Update(holdingViewModel.holding);

            return RedirectToAction("List");
        }
    }
}
