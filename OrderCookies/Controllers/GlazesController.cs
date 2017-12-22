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
    public class GlazesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Glazes
        public ActionResult Index()
        {
            return View(db.Glazes.ToList());
        }

        // GET: Glazes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Glaze glaze = db.Glazes.Find(id);
            if (glaze == null)
            {
                return HttpNotFound();
            }
            return View(glaze);
        }

        // GET: Glazes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Glazes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GlazeId,GlazeName")] Glaze glaze)
        {
            if (ModelState.IsValid)
            {
                db.Glazes.Add(glaze);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(glaze);
        }

        // GET: Glazes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Glaze glaze = db.Glazes.Find(id);
            if (glaze == null)
            {
                return HttpNotFound();
            }
            return View(glaze);
        }

        // POST: Glazes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GlazeId,GlazeName")] Glaze glaze)
        {
            if (ModelState.IsValid)
            {
                db.Entry(glaze).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(glaze);
        }

        // GET: Glazes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Glaze glaze = db.Glazes.Find(id);
            if (glaze == null)
            {
                return HttpNotFound();
            }
            return View(glaze);
        }

        // POST: Glazes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Glaze glaze = db.Glazes.Find(id);
            db.Glazes.Remove(glaze);
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
