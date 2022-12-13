using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using OOPShop.Repositories.Interfaces;
using OOPShop.Models;

namespace OOPShop.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> logger;

        // DI
        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
