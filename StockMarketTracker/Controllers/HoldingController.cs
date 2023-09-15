using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using StockMarketTracker.Models;

namespace StockMarketTracker.Controllers
{
    public class HoldingController : Controller
    {
        private readonly IHoldingRepository holdingRepository;

        public HoldingController(IHoldingRepository holdingRepository)
        {
            this.holdingRepository = holdingRepository;
        }
        public IActionResult List()
        {
            return View(holdingRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Holding holding)
        {
            holdingRepository.Add(holding);
            return RedirectToAction("List");
        }
    }
}
