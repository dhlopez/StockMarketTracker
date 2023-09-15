using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockMarketTracker.Models;

namespace StockMarketTracker.Controllers
{
    public class TickerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITickerRepository tickerRepository;


        //public TickerController(ILogger<HomeController> logger, StockMarketContext dbContext)
        //{
        //    _logger = logger;
        //   

        //}

        public TickerController(ITickerRepository tickerRepository)
        {
            this.tickerRepository = tickerRepository; 
        }

        public IActionResult List()
        {
            var tickers = tickerRepository.GetAll();

            //var tickers = tickerRepository.GetAll();

            return View(tickers);
        }

        public IActionResult Create() //(Ticker ticker)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Index(); //TODO validation
            //}


            //if (ticker != null) dbContext.Add(ticker);
            //dbContext.SaveChangesAsync();
            return View();
            
        }

        [HttpPost]
        public IActionResult Create(Ticker ticker) 
        {
            tickerRepository.Add(ticker);

            return RedirectToAction("List");
        }

        public IActionResult Edit(int id)
        { 
            var ticker = tickerRepository.GetById(id);

            return View(ticker);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            tickerRepository.Delete(id);
            return RedirectToAction("List");
        }
    }
}
