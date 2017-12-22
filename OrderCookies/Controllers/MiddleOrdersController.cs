using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrderCookies.Models;

namespace OrderCookies.Controllers
{
    public class MiddleOrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MiddleOrders
        public ActionResult Index()
        {
            var middleOrders = db.MiddleOrders.Include(m => m.Cookies).Include(m => m.FinalOrder);
            return View(middleOrders.ToList());
        }

        // GET: MiddleOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiddleOrder middleOrder = db.MiddleOrders.Find(id);
            if (middleOrder == null)
            {
                return HttpNotFound();
            }
            return View(middleOrder);
        }

        // GET: MiddleOrders/Create
        [Authorize(Roles = "user")]
        public ActionResult Create()
        {
            ViewBag.CookiesId = new SelectList(db.Cookies, "CookiesId", "CookiesName");
            ViewBag.FinalOrderId = new SelectList(db.FinalOrders, "FinalOrderId", "FinalOrderId");
            return View();
        }

        // POST: MiddleOrders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "user")]
        public ActionResult Create([Bind(Include = "MiddleOrderId,FinalOrderId,CookiesId,Number,MiddleAmount")] MiddleOrder middleOrder)
        {
            if (ModelState.IsValid)
            {
                db.MiddleOrders.Add(middleOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CookiesId = new SelectList(db.Cookies, "CookiesId", "CookiesName", middleOrder.CookiesId);
            ViewBag.FinalOrderId = new SelectList(db.FinalOrders, "FinalOrderId", "FinalOrderId", middleOrder.FinalOrderId);
            return View(middleOrder);
        }

        // GET: MiddleOrders/Edit/5
        [Authorize(Roles = "user")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiddleOrder middleOrder = db.MiddleOrders.Find(id);
            if (middleOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.CookiesId = new SelectList(db.Cookies, "CookiesId", "CookiesName", middleOrder.CookiesId);
            ViewBag.FinalOrderId = new SelectList(db.FinalOrders, "FinalOrderId", "FinalOrderId", middleOrder.FinalOrderId);
            return View(middleOrder);
        }

        // POST: MiddleOrders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "user")]
        public ActionResult Edit([Bind(Include = "MiddleOrderId,FinalOrderId,CookiesId,Number,MiddleAmount")] MiddleOrder middleOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(middleOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CookiesId = new SelectList(db.Cookies, "CookiesId", "CookiesName", middleOrder.CookiesId);
            ViewBag.FinalOrderId = new SelectList(db.FinalOrders, "FinalOrderId", "FinalOrderId", middleOrder.FinalOrderId);
            return View(middleOrder);
        }

        // GET: MiddleOrders/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiddleOrder middleOrder = db.MiddleOrders.Find(id);
            if (middleOrder == null)
            {
                return HttpNotFound();
            }
            return View(middleOrder);
        }

        // POST: MiddleOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            MiddleOrder middleOrder = db.MiddleOrders.Find(id);
            db.MiddleOrders.Remove(middleOrder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
