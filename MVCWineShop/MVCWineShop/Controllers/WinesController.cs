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
    public class WinesController : Controller
    {
        private WineDBContext db = new WineDBContext();

        // GET: Wines
        public ActionResult Index()
        {
            var wine = db.Wine.Include(w => w.Winery);
            return View(wine.ToList());
        }

        // GET: Wines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wine wine = db.Wine.Find(id);
            if (wine == null)
            {
                return HttpNotFound();
            }
            return View(wine);
        }

        // GET: Wines/Create
        public ActionResult Create()
        {
            ViewBag.WineryId = new SelectList(db.Winery, "Id", "Name");
            return View();
        }

        // POST: Wines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Price,YearOfBottling,AlcoholPercentage,ImagePath,Description,WineType,WineryId")] Wine wine)
        {
            if (ModelState.IsValid)
            {
                db.Wine.Add(wine);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WineryId = new SelectList(db.Winery, "Id", "Name", wine.WineryId);
            return View(wine);
        }

        // GET: Wines/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wine wine = db.Wine.Find(id);
            if (wine == null)
            {
                return HttpNotFound();
            }
            ViewBag.WineryId = new SelectList(db.Winery, "Id", "Name", wine.WineryId);
            return View(wine);
        }

        // POST: Wines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Price,YearOfBottling,AlcoholPercentage,ImagePath,Description,WineType,WineryId")] Wine wine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wine).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WineryId = new SelectList(db.Winery, "Id", "Name", wine.WineryId);
            return View(wine);
        }

        // GET: Wines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wine wine = db.Wine.Find(id);
            if (wine == null)
            {
                return HttpNotFound();
            }
            return View(wine);
        }

        // POST: Wines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wine wine = db.Wine.Find(id);
            db.Wine.Remove(wine);
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
