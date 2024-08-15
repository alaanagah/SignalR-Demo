using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using Resturant.Server.hubs;
using Resturant.Services.Models;
using Resturant.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Resturant.Server.Controllers
{
    public class HomeController : Controller
    {
        private readonly OrderServices _OrderServices;
        public HomeController()
        {
            _OrderServices = new OrderServices();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Order NewOrder)
        {
            _OrderServices.AddOrder(NewOrder);
            var jsonObj = JsonConvert.SerializeObject(NewOrder);
            var hubcontext = GlobalHost.ConnectionManager.GetHubContext<OrdersHub>();
            hubcontext.Clients.All.UpdateOrdersList(NewOrder);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}