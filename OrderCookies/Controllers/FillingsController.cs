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
    public class FillingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Fillings
        public ActionResult Index()
        {
            return View(db.Fillings.ToList());
        }

        // GET: Fillings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filling filling = db.Fillings.Find(id);
            if (filling == null)
            {
                return HttpNotFound();
            }
            return View(filling);
        }

        // GET: Fillings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fillings/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FillingId,FillingName")] Filling filling)
        {
            if (ModelState.IsValid)
            {
                db.Fillings.Add(filling);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(filling);
        }

        // GET: Fillings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filling filling = db.Fillings.Find(id);
            if (filling == null)
            {
                return HttpNotFound();
            }
            return View(filling);
        }

        // POST: Fillings/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FillingId,FillingName")] Filling filling)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filling).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(filling);
        }

        // GET: Fillings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Filling filling = db.Fillings.Find(id);
            if (filling == null)
            {
                return HttpNotFound();
            }
            return View(filling);
        }

        // POST: Fillings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Filling filling = db.Fillings.Find(id);
            db.Fillings.Remove(filling);
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
