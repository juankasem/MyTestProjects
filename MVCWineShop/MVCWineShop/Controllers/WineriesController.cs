using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCWineShop.Models;

namespace MVCWineShop.Controllers
{
    public class WineriesController : Controller
    {
        private WineDBContext db = new WineDBContext();

        // GET: Wineries
        public ActionResult Index()
        {
            return View(db.Winery.ToList());
        }

        // GET: Wineries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Winery winery = db.Winery.Find(id);
            if (winery == null)
            {
                return HttpNotFound();
            }
            return View(winery);
        }

        // GET: Wineries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wineries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Country")] Winery winery)
        {
            if (ModelState.IsValid)
            {
                db.Winery.Add(winery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(winery);
        }

        // GET: Wineries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Winery winery = db.Winery.Find(id);
            if (winery == null)
            {
                return HttpNotFound();
            }
            return View(winery);
        }

        // POST: Wineries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Country")] Winery winery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(winery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(winery);
        }

        // GET: Wineries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Winery winery = db.Winery.Find(id);
            if (winery == null)
            {
                return HttpNotFound();
            }
            return View(winery);
        }

        // POST: Wineries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Winery winery = db.Winery.Find(id);
            db.Winery.Remove(winery);
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
