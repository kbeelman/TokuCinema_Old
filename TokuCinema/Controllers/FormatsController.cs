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
    public class FormatsController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: Formats
        public ActionResult Index()
        {
            var formats = db.Formats.Include(f => f.FormatType).Include(f => f.VideoRelease);
            return View(formats.ToList());
        }

        // GET: Formats/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Format format = db.Formats.Find(id);
            if (format == null)
            {
                return HttpNotFound();
            }
            return View(format);
        }

        // GET: Formats/Create
        public ActionResult Create()
        {
            ViewBag.FormatTypeId = new SelectList(db.FormatTypes, "FormatTypeId", "FormatName");
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode");
            return View();
        }

        // POST: Formats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormatId,VideoReleaseId,FormatTypeId")] Format format)
        {
            if (ModelState.IsValid)
            {
                format.FormatId = Guid.NewGuid();
                db.Formats.Add(format);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FormatTypeId = new SelectList(db.FormatTypes, "FormatTypeId", "FormatName", format.FormatTypeId);
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", format.VideoReleaseId);
            return View(format);
        }

        // GET: Formats/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Format format = db.Formats.Find(id);
            if (format == null)
            {
                return HttpNotFound();
            }
            ViewBag.FormatTypeId = new SelectList(db.FormatTypes, "FormatTypeId", "FormatName", format.FormatTypeId);
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", format.VideoReleaseId);
            return View(format);
        }

        // POST: Formats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormatId,VideoReleaseId,FormatTypeId")] Format format)
        {
            if (ModelState.IsValid)
            {
                db.Entry(format).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FormatTypeId = new SelectList(db.FormatTypes, "FormatTypeId", "FormatName", format.FormatTypeId);
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", format.VideoReleaseId);
            return View(format);
        }

        // GET: Formats/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Format format = db.Formats.Find(id);
            if (format == null)
            {
                return HttpNotFound();
            }
            return View(format);
        }

        // POST: Formats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Format format = db.Formats.Find(id);
            db.Formats.Remove(format);
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
