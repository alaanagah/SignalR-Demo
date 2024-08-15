using Resturant.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Services.Services
{
    public class OrderServices
    {
        public MyContext _myContext { get; set; }
        public OrderServices()
        {
            _myContext = new MyContext();
        }

        public bool AddOrder(Order order)
        {
            try
            {
                _myContext.Order.Add(order);
                _myContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<Order> GetAllOrders()
        {
            return _myContext.Order.ToList();
        }
    }
}
