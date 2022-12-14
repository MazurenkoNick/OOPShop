using Microsoft.AspNetCore.Mvc;
using OOPShop.Services.Interfaces;
using OOPShop.Models;

namespace OOPShop.Controllers
{
    public class HomeController : Controller
    {
        private IUserService userService;
        private ILogger<HomeController> logger;
        private AbstractApplicationDbContext db;
        private AuthUser authUser;

        // DI
        public HomeController(IUserService userService, AuthUser authUser, ILogger<HomeController> logger, AbstractApplicationDbContext db)
        {
            this.userService = userService;
            this.authUser = authUser;
            this.logger = logger;
            this.db = db;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {
            if (authUser.IsAuthenticated())
            {
                ViewBag.orders = userService.getAllOrders(authUser.User);
                ViewBag.user = authUser.User;
                return View();
            }
            return RedirectPermanent("~/user/login");
        }
    }
}
