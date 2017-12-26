using OrderCookies.Models;
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
            TempData["Model"] = null;
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
            MiddleOrder(model, User.Identity.Name);
            return View("Index");
        }
        public ActionResult Cookie1()
        {
            return View();
        }

        public ActionResult Cookie2()
        {
            return View();
        }

        public void MiddleOrder(MiddleOrder model, string username)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            FinalOrder finalOrder = new FinalOrder();
            finalOrder.Date = DateTime.Now;
            List<ApplicationUser> listuser = context.Users.ToList();
            List<FinalOrder> listfo = context.FinalOrders.ToList();
            FinalOrder lastfinal = listfo.Last();
            ApplicationUser user = listuser.Find(m => m.Email.Equals(username));
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

        public ActionResult FinalOrder()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            List<ApplicationUser> listuser = context.Users.ToList();
            ApplicationUser user = listuser.Find(m => m.Email.Equals(User.Identity.Name));
            List<FinalOrder> listfo = context.FinalOrders.ToList();
            List<Cookies> listcookies = context.Cookies.ToList();
            IEnumerable<MiddleOrder> listmi = context.MiddleOrders.ToList();
            foreach(MiddleOrder middle in listmi)
            {
                middle.Cookies = listcookies.Last(m=>m.CookiesId.Equals(middle.CookiesId));
            }
            FinalOrder final = listfo.Last(m => m.ApplicationUserId.Equals(user.Id));
            IEnumerable<MiddleOrder> listmiddle = listmi.Where(m => m.FinalOrderId.Equals(final.FinalOrderId));

            ViewBag.ListMiddle = listmiddle;
            ViewBag.FinalOrder = final;

            return View();
        }
    }
}
