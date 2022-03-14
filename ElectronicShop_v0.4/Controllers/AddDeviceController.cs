using ElectronicShop_v0._4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicShop_v0._4.Controllers
{
    public class AddDeviceController : Controller
    {
        // GET: AddDevice
        [HttpGet]
        public ActionResult AddDevice()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDevice(Products device)
        {
            var db = new ElectronicShopContext();

            var checkDevice = db.Products.Select(x => x.name == device.name).FirstOrDefault();

            List<string> categoryList = new List<string>
            {
                "Computer and Tablets", 
                "Headphones",
                "Monitors",
                "Mouse and keyboards",
                "Video game consoles"
            };         

            bool isStringContainedInList = categoryList.Contains(device.category);

            if (isStringContainedInList == true)
            {
                if (checkDevice == false)
                {
                    db.Products.Add(device);
                    db.SaveChanges();
                    ViewBag.Succes = "Product has been added";
                    return View();
                }
                else
                {
                    ViewBag.Error = "This item already exist";
                    return View();
                }
            }
            else
            {
                ViewBag.Error = "You have to choose one category from the list: Computer and Tablets, Headphones, Monitors, Mouse and keyboards, Video game consoles";
                return View();
            }
        }

        [HttpGet]
        public ActionResult LogInEmployee()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogInEmployee(Employees checkEmployee)
        {
            var db = new ElectronicShopContext();

            var isEmployeeMatch = db.Employees.Where(x => x.userName == checkEmployee.userName &&
                                                           x.password == checkEmployee.password).FirstOrDefault();
            bool adminCheck = isEmployeeMatch.position.StartsWith("admin");

            if (adminCheck == true)
            {

                if (isEmployeeMatch != null)
                {
                    Session["SessionEmployee"] = isEmployeeMatch;
                    Session.Timeout = 15;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Wrong username or password";
                }
                return View();
            }
            else
            {
                if (isEmployeeMatch != null)
                {
                    ViewBag.Error = "Welcome, if you want to make a order you have to create a customer account";
                }
                else
                {
                    ViewBag.Error = "Wrong username or password";
                }
                return View();
            }
        }

    }
}