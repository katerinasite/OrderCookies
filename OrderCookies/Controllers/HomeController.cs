﻿using OrderCookies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderCookies.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
        public ActionResult My(OrderCookies.Models.MiddleOrder model)
        {
            
            return View(model);
        }
        //Собственно выполнение заказа
        public ActionResult MiddleOrderNew(MiddleOrder model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                ViewBag.Model = model;

                TempData["Model"] = model;
                return RedirectToAction("Login", "Account", new { returnurl = "/Home/Index" });
            }
            MiddleOrder(model);
            return View();
        }
        public ActionResult Cookie1()
        {
            return View();
        }
        
        public void MiddleOrder(MiddleOrder model)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            FinalOrder finalOrder = new FinalOrder();
            finalOrder.Date = DateTime.Now;
            List<ApplicationUser> listuser = context.Users.ToList();
            List<FinalOrder> listfo = context.FinalOrders.ToList();
            FinalOrder lastfinal = listfo.Last();
            ApplicationUser user = listuser.Find(m => m.Email.Equals(User.Identity.Name));
            finalOrder.ApplicationUserId = user.Id;
            finalOrder.FinalAmount = 0;
            finalOrder.IsConfirmed = false;
            finalOrder.FinalOrderId = lastfinal.FinalOrderId + 1;

            context.FinalOrders.Add(finalOrder); 
            
            MiddleOrder middleOrder = new MiddleOrder();
            middleOrder.FinalOrderId = finalOrder.FinalOrderId;
            middleOrder.CookiesId = model.CookiesId;
            middleOrder.Number = model.Number;
            middleOrder.MiddleAmount = 0;
                       
            context.MiddleOrders.Add(middleOrder);
            context.SaveChanges();
        }
    }
}