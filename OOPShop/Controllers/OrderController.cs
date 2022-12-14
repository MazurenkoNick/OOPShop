using Microsoft.AspNetCore.Mvc;
using OOPShop.Services.Interfaces;
using OOPShop.Models;

namespace OOPShop.Controllers
{
    public class OrderController : Controller
    {
        ILogger<OrderController> logger;
        IOrderService orderService;
        IUserService userService;
        AuthUser authUser;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService, IUserService userService, AuthUser authUser)
        {
            this.logger = logger;
            this.orderService = orderService;
            this.userService = userService;
            this.authUser = authUser;
        }

        [HttpGet]
        [Route("order/info/orderId={orderId:int}")]
        public IActionResult Info(int orderId)
        {
            Order? order = orderService.GetById(orderId);

            if (verifyOrderAuth(order) is false)
            {
                return RedirectPermanent("~/");
            }

            List<OrderItem> items = orderService.GetAllItems(order);
            ViewBag.order = order;
            ViewBag.items = items;

            return View();
        }

        [HttpPost]
        [Route("/order/cancel/orderId={orderId:int}")]
        public IActionResult Cancel(int orderId)
        {
            Order? order = orderService.GetById(orderId);

            if (verifyOrderAuth(order) is false)
            {
                return RedirectPermanent("~/");
            }

            orderService.Cancel(order);

            return RedirectPermanent(String.Format("~/order/info/orderId={0}", order.Id));
        }

        [HttpPost]
        [Route("/order/complete/orderId={orderId:int}")]
        public IActionResult Complete(int orderId)
        {
            Order? order = orderService.GetById(orderId);

            if (verifyOrderAuth(order) is false)
            {
                return RedirectPermanent("~/");
            }

            orderService.Complete(order);
            userService.WithdrawFromBalance(authUser.User, order.TotalSum);

            return RedirectPermanent(String.Format("~/order/info/orderId={0}", order.Id));
        }

        private bool verifyOrderAuth(Order? order)
        {
            if (order == null || authUser.IsNotAuthenticated() || order.UserId != authUser.User.Id)
            {
                return false;
            }
            return true;
        }
    }
}
