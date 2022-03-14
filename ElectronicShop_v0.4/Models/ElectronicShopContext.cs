using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ElectronicShop_v0._4.Models
{
    public class ElectronicShopContext : DbContext
    {
        public ElectronicShopContext() : base("ElectronicShopDb") { }

        public virtual DbSet<CustomerOrders> CustomerOrders { get; set; }

        public virtual DbSet<Customers> Customers { get; set; }

        public virtual DbSet<Employees> Employees { get; set; }

        public virtual DbSet<Products> Products { get; set; }
    }
}