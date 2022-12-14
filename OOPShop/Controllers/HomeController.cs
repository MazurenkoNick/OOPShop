using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using OOPShop.Repositories.Interfaces;
using OOPShop.Models;

namespace OOPShop.Controllers
{
    public class HomeController : Controller
    {
        private ILogger<HomeController> logger;
        private AbstractApplicationDbContext db;
        private AuthUser authUser;

        // DI
        public HomeController(AuthUser authUser, ILogger<HomeController> logger, AbstractApplicationDbContext db)
        {
            this.authUser = authUser;
            this.logger = logger;
            this.db = db;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            if (authUser.IsAuthenticated())
                return View();
            return RedirectPermanent("~/user/login");
        }
    }
}
