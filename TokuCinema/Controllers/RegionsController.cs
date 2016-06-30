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
    public class RegionsController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: Regions
        public ActionResult Index()
        {
            var regions = db.Regions.Include(r => r.RegionType).Include(r => r.VideoRelease);
            return View(regions.ToList());
        }

        // GET: Regions/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = db.Regions.Find(id);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // GET: Regions/Create
        public ActionResult Create()
        {
            ViewBag.RegionTypeId = new SelectList(db.RegionTypes, "RegionTypeId", "RegionName");
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode");
            return View();
        }

        // POST: Regions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RegionId,VideoReleaseId,RegionTypeId")] Region region)
        {
            if (ModelState.IsValid)
            {
                region.RegionId = Guid.NewGuid();
                db.Regions.Add(region);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RegionTypeId = new SelectList(db.RegionTypes, "RegionTypeId", "RegionName", region.RegionTypeId);
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", region.VideoReleaseId);
            return View(region);
        }

        // GET: Regions/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = db.Regions.Find(id);
            if (region == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionTypeId = new SelectList(db.RegionTypes, "RegionTypeId", "RegionName", region.RegionTypeId);
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", region.VideoReleaseId);
            return View(region);
        }

        // POST: Regions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegionId,VideoReleaseId,RegionTypeId")] Region region)
        {
            if (ModelState.IsValid)
            {
                db.Entry(region).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RegionTypeId = new SelectList(db.RegionTypes, "RegionTypeId", "RegionName", region.RegionTypeId);
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", region.VideoReleaseId);
            return View(region);
        }

        // GET: Regions/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Region region = db.Regions.Find(id);
            if (region == null)
            {
                return HttpNotFound();
            }
            return View(region);
        }

        // POST: Regions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Region region = db.Regions.Find(id);
            db.Regions.Remove(region);
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
