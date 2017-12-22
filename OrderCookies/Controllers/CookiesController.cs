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
    public class CookiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cookies
        public ActionResult Index()
        {
            var cookies = db.Cookies.Include(c => c.CookieForm).Include(c => c.CookieSize).Include(c => c.Filling).Include(c => c.Glaze).Include(c => c.Pastry);
            return View(cookies.ToList());
        }

        // GET: Cookies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cookies cookies = db.Cookies.Find(id);
            if (cookies == null)
            {
                return HttpNotFound();
            }
            return View(cookies);
        }

        // GET: Cookies/Create
        public ActionResult Create()
        {
            ViewBag.CookieFormId = new SelectList(db.CookieForms, "CookieFormId", "CookieFormName");
            ViewBag.CookieSizeId = new SelectList(db.CookieSizes, "CookieSizeId", "CookieSizeId");
            ViewBag.FillingId = new SelectList(db.Fillings, "FillingId", "FillingName");
            ViewBag.GlazeId = new SelectList(db.Glazes, "GlazeId", "GlazeName");
            ViewBag.PastryId = new SelectList(db.Pastries, "PastryId", "PastryName");
            return View();
        }

        // POST: Cookies/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CookiesId,CookiesName,CookieFormId,CookieSizeId,PastryId,FillingId,GlazeId,Price")] Cookies cookies)
        {
            if (ModelState.IsValid)
            {
                db.Cookies.Add(cookies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CookieFormId = new SelectList(db.CookieForms, "CookieFormId", "CookieFormName", cookies.CookieFormId);
            ViewBag.CookieSizeId = new SelectList(db.CookieSizes, "CookieSizeId", "CookieSizeId", cookies.CookieSizeId);
            ViewBag.FillingId = new SelectList(db.Fillings, "FillingId", "FillingName", cookies.FillingId);
            ViewBag.GlazeId = new SelectList(db.Glazes, "GlazeId", "GlazeName", cookies.GlazeId);
            ViewBag.PastryId = new SelectList(db.Pastries, "PastryId", "PastryName", cookies.PastryId);
            return View(cookies);
        }

        // GET: Cookies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cookies cookies = db.Cookies.Find(id);
            if (cookies == null)
            {
                return HttpNotFound();
            }
            ViewBag.CookieFormId = new SelectList(db.CookieForms, "CookieFormId", "CookieFormName", cookies.CookieFormId);
            ViewBag.CookieSizeId = new SelectList(db.CookieSizes, "CookieSizeId", "CookieSizeId", cookies.CookieSizeId);
            ViewBag.FillingId = new SelectList(db.Fillings, "FillingId", "FillingName", cookies.FillingId);
            ViewBag.GlazeId = new SelectList(db.Glazes, "GlazeId", "GlazeName", cookies.GlazeId);
            ViewBag.PastryId = new SelectList(db.Pastries, "PastryId", "PastryName", cookies.PastryId);
            return View(cookies);
        }

        // POST: Cookies/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CookiesId,CookiesName,CookieFormId,CookieSizeId,PastryId,FillingId,GlazeId,Price")] Cookies cookies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cookies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CookieFormId = new SelectList(db.CookieForms, "CookieFormId", "CookieFormName", cookies.CookieFormId);
            ViewBag.CookieSizeId = new SelectList(db.CookieSizes, "CookieSizeId", "CookieSizeId", cookies.CookieSizeId);
            ViewBag.FillingId = new SelectList(db.Fillings, "FillingId", "FillingName", cookies.FillingId);
            ViewBag.GlazeId = new SelectList(db.Glazes, "GlazeId", "GlazeName", cookies.GlazeId);
            ViewBag.PastryId = new SelectList(db.Pastries, "PastryId", "PastryName", cookies.PastryId);
            return View(cookies);
        }

        // GET: Cookies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cookies cookies = db.Cookies.Find(id);
            if (cookies == null)
            {
                return HttpNotFound();
            }
            return View(cookies);
        }

        // POST: Cookies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cookies cookies = db.Cookies.Find(id);
            db.Cookies.Remove(cookies);
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
