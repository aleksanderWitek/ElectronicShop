using ElectronicShop_v0._4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicShop_v0._4.Controllers
{
    public class ProductListController : Controller
    {
        // GET: Default
        public ActionResult ProductList(string sortOrder)
        {
            var db = new ElectronicShopContext();

            var products = db.Products.ToList();

            List<Products> list = new List<Products>();

            ViewBag.NameSortParameter = string.IsNullOrEmpty(sortOrder) ? "nameDesc" : "";
            ViewBag.CategorySortParameter = sortOrder == "category" ? "categoryDesc" : "category";
            ViewBag.PriceSortParameter = sortOrder == "price" ? "priceDesc" : "price";
            ViewBag.AmountSortParameter = sortOrder == "amount" ? "amountDesc" : "amount";

            switch (sortOrder)
            {
                case "nameDesc":
                    list = products.OrderByDescending(x => x.name).ToList();
                    break;

                case "categoryDesc":
                    list = products.OrderByDescending(x => x.category).ToList();
                    break;

                case "category":
                    list = products.OrderBy(x => x.category).ToList();
                    break;

                case "priceDesc":
                    list = products.OrderByDescending(x => x.price).ToList();
                    break;

                case "price":
                    list = products.OrderBy(x => x.price).ToList();
                    break;

                case "amountDesc":
                    list = products.OrderByDescending(x => x.amount).ToList();
                    break;

                case "amount":
                    list = products.OrderBy(x => x.amount).ToList();
                    break;

                default:
                    list = products.OrderBy(x => x.name).ToList();
                    break;

            }
            return View(list);
        }

        [HttpGet]
        public ActionResult AddToBasket(int choosenProductID)
        {
            var  db = new ElectronicShopContext();


            Session["choosenProduct"] = db.Products.Where(x => x.productID == choosenProductID).FirstOrDefault();

            

            return RedirectToAction("GetProductAmount", "ProductList", Session["choosenProduct"]);
        }

        [HttpGet]
        public ActionResult GetProductAmount()
        {
            return View();
        }


            [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GetProductAmount(int additionalAmount)
        {
            var db = new ElectronicShopContext();

            var customerProfile = (Customers)Session["SessionCustomer"];

            var choosenProduct = (Products)Session["choosenProduct"];
            var choosenProductID = choosenProduct.productID;

            var orderedProduct = from x in db.Products.Where(m => m.productID == choosenProductID)
                                 from z in db.Customers.Where(n => n.customerID == customerProfile.customerID)
                                 select new CustomerOrders
                                 {
                                     price = x.price * additionalAmount,
                                     productName = x.name,
                                     productID = x.productID,
                                     amount = additionalAmount,
                                     customerID = z.customerID
                                 };

            // spytac sie Huberta jak z obiektu LinQ[klasa DbSet] zrobic obiekt klasa DbSet


            CustomerOrders orderedProductConvertet = new CustomerOrders();
            orderedProductConvertet.price = choosenProduct.price * additionalAmount;
            orderedProductConvertet.productName = choosenProduct.name;
            orderedProductConvertet.productID = choosenProductID;
            orderedProductConvertet.amount = additionalAmount;
            orderedProductConvertet.customerID = customerProfile.customerID;

            db.CustomerOrders.Add(orderedProductConvertet);

            (from x in db.Products where x.productID == choosenProductID select x).ToList().ForEach(x => x.amount -= additionalAmount);

            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}