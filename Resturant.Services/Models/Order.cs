using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Services.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrderNumber { get; set; }

        public double TotalPrice { get; set; }

        public string OrderType { get; set; }
    }
}
