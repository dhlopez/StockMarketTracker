using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockMarketTracker.Models;
using System.Net;

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

        [HttpPost]
        public IActionResult Edit(Ticker ticker)
        {
            if (ModelState.IsValid)
            { 
                tickerRepository.Update(ticker);
            }

            return RedirectToAction("List");
        }
        
        [ValidateAntiForgeryToken]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            Ticker ticker = tickerRepository.GetById(id);

            tickerRepository.Delete(ticker.Id);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            Ticker ticker = tickerRepository.GetById((int)id);
            if (ticker == null)
            {
                return NotFound();
            }
            return View(ticker);
        }
    }
}
