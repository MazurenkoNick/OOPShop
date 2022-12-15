using Microsoft.AspNetCore.Mvc;
using OOPShop.Services.Interfaces;

namespace OOPShop.Controllers
{
    public class ProductController : Controller
    {
        IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        [Route("/product/all")]
        public IActionResult GetAllProducts()
        {
            ViewBag.products = productService.GetAll();
            return View();
        }
    }
}
