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
    public class StandardsController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: Standards
        public ActionResult Index()
        {
            var standards = db.Standards.Include(s => s.StandardType).Include(s => s.VideoRelease);
            return View(standards.ToList());
        }

        // GET: Standards/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Standard standard = db.Standards.Find(id);
            if (standard == null)
            {
                return HttpNotFound();
            }
            return View(standard);
        }

        // GET: Standards/Create
        public ActionResult Create()
        {
            ViewBag.StandardTypeID = new SelectList(db.StandardTypes, "StandardTypeId", "StandardName");
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode");
            return View();
        }

        // POST: Standards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StandardId,VideoReleaseId,StandardTypeID")] Standard standard)
        {
            if (ModelState.IsValid)
            {
                standard.StandardId = Guid.NewGuid();
                db.Standards.Add(standard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StandardTypeID = new SelectList(db.StandardTypes, "StandardTypeId", "StandardName", standard.StandardTypeID);
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", standard.VideoReleaseId);
            return View(standard);
        }

        // GET: Standards/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Standard standard = db.Standards.Find(id);
            if (standard == null)
            {
                return HttpNotFound();
            }
            ViewBag.StandardTypeID = new SelectList(db.StandardTypes, "StandardTypeId", "StandardName", standard.StandardTypeID);
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", standard.VideoReleaseId);
            return View(standard);
        }

        // POST: Standards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StandardId,VideoReleaseId,StandardTypeID")] Standard standard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(standard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StandardTypeID = new SelectList(db.StandardTypes, "StandardTypeId", "StandardName", standard.StandardTypeID);
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", standard.VideoReleaseId);
            return View(standard);
        }

        // GET: Standards/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Standard standard = db.Standards.Find(id);
            if (standard == null)
            {
                return HttpNotFound();
            }
            return View(standard);
        }

        // POST: Standards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Standard standard = db.Standards.Find(id);
            db.Standards.Remove(standard);
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
