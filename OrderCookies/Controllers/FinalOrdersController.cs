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
    public class FinalOrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FinalOrders
        public ActionResult Index()
        {
            return View(db.FinalOrders.ToList());
        }

        // GET: FinalOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinalOrder finalOrder = db.FinalOrders.Find(id);
            if (finalOrder == null)
            {
                return HttpNotFound();
            }
            return View(finalOrder);
        }

        // GET: FinalOrders/Create
        [Authorize(Roles = "user")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: FinalOrders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "user")]
        public ActionResult Create([Bind(Include = "FinalOrderId,FinalAmount,Date,IsConfirmed")] FinalOrder finalOrder)
        {
            if (ModelState.IsValid)
            {
                db.FinalOrders.Add(finalOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(finalOrder);
        }

        // GET: FinalOrders/Edit/5
        [Authorize(Roles = "user")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinalOrder finalOrder = db.FinalOrders.Find(id);
            if (finalOrder == null)
            {
                return HttpNotFound();
            }
            return View(finalOrder);
        }

        // POST: FinalOrders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "user")]
        public ActionResult Edit([Bind(Include = "FinalOrderId,FinalAmount,Date,IsConfirmed")] FinalOrder finalOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(finalOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(finalOrder);
        }

        // GET: FinalOrders/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FinalOrder finalOrder = db.FinalOrders.Find(id);
            if (finalOrder == null)
            {
                return HttpNotFound();
            }
            return View(finalOrder);
        }

        // POST: FinalOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            FinalOrder finalOrder = db.FinalOrders.Find(id);
            db.FinalOrders.Remove(finalOrder);
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
