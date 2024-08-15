using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Resturant.Server.hubs

{
    [HubName("OrdersHub")]
    public class OrdersHub : Hub
    {
    }
}