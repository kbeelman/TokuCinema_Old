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
    public class RegionTypesController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: RegionTypes
        public ActionResult Index()
        {
            return View(db.RegionTypes.ToList());
        }

        // GET: RegionTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegionType regionType = db.RegionTypes.Find(id);
            if (regionType == null)
            {
                return HttpNotFound();
            }
            return View(regionType);
        }

        // GET: RegionTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegionTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegionTypeId,RegionName,RegionDescription")] RegionType regionType)
        {
            if (ModelState.IsValid)
            {
                regionType.RegionTypeId = Guid.NewGuid();
                db.RegionTypes.Add(regionType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(regionType);
        }

        // GET: RegionTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegionType regionType = db.RegionTypes.Find(id);
            if (regionType == null)
            {
                return HttpNotFound();
            }
            return View(regionType);
        }

        // POST: RegionTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegionTypeId,RegionName,RegionDescription")] RegionType regionType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(regionType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(regionType);
        }

        // GET: RegionTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegionType regionType = db.RegionTypes.Find(id);
            if (regionType == null)
            {
                return HttpNotFound();
            }
            return View(regionType);
        }

        // POST: RegionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            RegionType regionType = db.RegionTypes.Find(id);
            db.RegionTypes.Remove(regionType);
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
