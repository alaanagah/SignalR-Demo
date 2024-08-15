using Resturant.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resturant.Client.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderServices _OrderServices;
        public OrdersController()
        {
            _OrderServices = new OrderServices();
        }
        // GET: Orders
        public ActionResult Index()
        {
            var ordersList = _OrderServices.GetAllOrders();
            return View(ordersList);
        }
    }
}