using Microsoft.AspNetCore.Mvc;

namespace OOPShop.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
