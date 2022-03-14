using ElectronicShop_v0._4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
//using System.Web.HttpContext.Current.Session;


namespace ElectronicShop_v0._4.Controllers
{
    public class CustomerRegisterController : Controller
    {
        // GET: CustomerRegister
        [HttpGet]
        public ActionResult CustomerRegister()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CustomerRegister(Customers newCustomer)
        {
            var db = new ElectronicShopContext();

            var checkCustomer = db.Customers.Select(x => x.nickName == newCustomer.nickName).FirstOrDefault();
            var checkCustomerMail = db.Customers.Select(x => x.emailAdress == newCustomer.emailAdress).FirstOrDefault();

            if (checkCustomer == false && checkCustomerMail == false)
            {
                db.Customers.Add(newCustomer);
                db.SaveChanges();
                ViewBag.Succes = "Customer has beed created";
                return View();
            }
            else if(checkCustomerMail != false)
            {
                ViewBag.Error = "This email adress is being used";
                return View();
            }
            else
            {
                ViewBag.Error = "This nickname is being used";
                return View();
            }
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(Customers checkCustomer)
        {
            var db = new ElectronicShopContext();

            var isCustomerMatch = db.Customers.Where(x => x.nickName == checkCustomer.nickName 
                                      && x.password == checkCustomer.password).FirstOrDefault();
            

            if (isCustomerMatch != null)
            {
                Session["SessionCustomer"] = isCustomerMatch;
                Session.Timeout = 15;
                return RedirectToAction("ShowCustomerProfile", "CustomerRegister");                
            }
            else
            {    
                ViewBag.Error = "Wrong nickname or password";
            }
            return View();
        }


        public ActionResult ShowCustomerProfile()
        {
            var customerProfile = Session["SessionCustomer"];    
            
            return View(customerProfile);
        }


        public ActionResult ShowCustomerOrders()
        {
            var db = new ElectronicShopContext();

            var customerProfile =  (Customers)Session["SessionCustomer"];
            var cutomerOrdersList = db.CustomerOrders.Where(x => x.customerID == customerProfile.customerID).ToList();                 

            return View(cutomerOrdersList);
        }

    }
}