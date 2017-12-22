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
    public class SpecialDesignsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SpecialDesigns
        public ActionResult Index()
        {
            return View(db.SpecialDesigns.ToList());
        }

        // GET: SpecialDesigns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialDesign specialDesign = db.SpecialDesigns.Find(id);
            if (specialDesign == null)
            {
                return HttpNotFound();
            }
            return View(specialDesign);
        }

        // GET: SpecialDesigns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpecialDesigns/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpecialDesignId,Design")] SpecialDesign specialDesign)
        {
            if (ModelState.IsValid)
            {
                db.SpecialDesigns.Add(specialDesign);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(specialDesign);
        }

        // GET: SpecialDesigns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialDesign specialDesign = db.SpecialDesigns.Find(id);
            if (specialDesign == null)
            {
                return HttpNotFound();
            }
            return View(specialDesign);
        }

        // POST: SpecialDesigns/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpecialDesignId,Design")] SpecialDesign specialDesign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specialDesign).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(specialDesign);
        }

        // GET: SpecialDesigns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpecialDesign specialDesign = db.SpecialDesigns.Find(id);
            if (specialDesign == null)
            {
                return HttpNotFound();
            }
            return View(specialDesign);
        }

        // POST: SpecialDesigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SpecialDesign specialDesign = db.SpecialDesigns.Find(id);
            db.SpecialDesigns.Remove(specialDesign);
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
