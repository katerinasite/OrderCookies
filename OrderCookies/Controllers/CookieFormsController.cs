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
    public class CookieFormsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CookieForms
        public ActionResult Index()
        {
            return View(db.CookieForms.ToList());
        }

        // GET: CookieForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CookieForm cookieForm = db.CookieForms.Find(id);
            if (cookieForm == null)
            {
                return HttpNotFound();
            }
            return View(cookieForm);
        }

        // GET: CookieForms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CookieForms/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CookieFormId,CookieFormName")] CookieForm cookieForm)
        {
            if (ModelState.IsValid)
            {
                db.CookieForms.Add(cookieForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cookieForm);
        }

        // GET: CookieForms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CookieForm cookieForm = db.CookieForms.Find(id);
            if (cookieForm == null)
            {
                return HttpNotFound();
            }
            return View(cookieForm);
        }

        // POST: CookieForms/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CookieFormId,CookieFormName")] CookieForm cookieForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cookieForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cookieForm);
        }

        // GET: CookieForms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CookieForm cookieForm = db.CookieForms.Find(id);
            if (cookieForm == null)
            {
                return HttpNotFound();
            }
            return View(cookieForm);
        }

        // POST: CookieForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CookieForm cookieForm = db.CookieForms.Find(id);
            db.CookieForms.Remove(cookieForm);
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
