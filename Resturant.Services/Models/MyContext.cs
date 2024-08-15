using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Services.Models
{
    public class MyContext : DbContext
    {
        public MyContext() : base("DefaultConnection") { }
        public virtual DbSet<Order> Order { get; set; }
    }
}
