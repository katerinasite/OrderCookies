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
    public class CookieSizesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CookieSizes
        public ActionResult Index()
        {
            return View(db.CookieSizes.ToList());
        }

        // GET: CookieSizes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CookieSize cookieSize = db.CookieSizes.Find(id);
            if (cookieSize == null)
            {
                return HttpNotFound();
            }
            return View(cookieSize);
        }

        // GET: CookieSizes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CookieSizes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CookieSizeId,Size")] CookieSize cookieSize)
        {
            if (ModelState.IsValid)
            {
                db.CookieSizes.Add(cookieSize);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cookieSize);
        }

        // GET: CookieSizes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CookieSize cookieSize = db.CookieSizes.Find(id);
            if (cookieSize == null)
            {
                return HttpNotFound();
            }
            return View(cookieSize);
        }

        // POST: CookieSizes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CookieSizeId,Size")] CookieSize cookieSize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cookieSize).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cookieSize);
        }

        // GET: CookieSizes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CookieSize cookieSize = db.CookieSizes.Find(id);
            if (cookieSize == null)
            {
                return HttpNotFound();
            }
            return View(cookieSize);
        }

        // POST: CookieSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CookieSize cookieSize = db.CookieSizes.Find(id);
            db.CookieSizes.Remove(cookieSize);
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
