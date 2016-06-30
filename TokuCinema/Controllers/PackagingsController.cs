using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TokuCinema.Models;

namespace TokuCinema.Controllers
{
    public class PackagingsController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: Packagings
        public ActionResult Index()
        {
            return View(db.Packagings.ToList());
        }

        // GET: Packagings/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Packaging packaging = db.Packagings.Find(id);
            if (packaging == null)
            {
                return HttpNotFound();
            }
            return View(packaging);
        }

        // GET: Packagings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Packagings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PackagingId,PackagingDescription,PackagingName")] Packaging packaging)
        {
            if (ModelState.IsValid)
            {
                packaging.PackagingId = Guid.NewGuid();
                db.Packagings.Add(packaging);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(packaging);
        }

        // GET: Packagings/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Packaging packaging = db.Packagings.Find(id);
            if (packaging == null)
            {
                return HttpNotFound();
            }
            return View(packaging);
        }

        // POST: Packagings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PackagingId,PackagingDescription,PackagingName")] Packaging packaging)
        {
            if (ModelState.IsValid)
            {
                db.Entry(packaging).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(packaging);
        }

        // GET: Packagings/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Packaging packaging = db.Packagings.Find(id);
            if (packaging == null)
            {
                return HttpNotFound();
            }
            return View(packaging);
        }

        // POST: Packagings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Packaging packaging = db.Packagings.Find(id);
            db.Packagings.Remove(packaging);
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
