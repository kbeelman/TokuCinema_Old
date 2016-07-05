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
    public class VideoVersionsController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: VideoVersions
        public ActionResult Index()
        {
            var videoVersions = db.VideoVersions.Include(v => v.VideoRelease).Include(v => v.VideoVersionType);
            return View(videoVersions.ToList());
        }

        // GET: VideoVersions/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoVersion videoVersion = db.VideoVersions.Find(id);
            if (videoVersion == null)
            {
                return HttpNotFound();
            }
            return View(videoVersion);
        }

        // GET: VideoVersions/Create
        public ActionResult Create()
        {
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode");
            ViewBag.VideoVersionTypeId = new SelectList(db.VideoVersionTypes, "VideoVersionTypeId", "VideoVersionTitle");
            return View();
        }

        // POST: VideoVersions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoVersionId,VideoVersionTypeId,VideoReleaseId")] VideoVersion videoVersion)
        {
            if (ModelState.IsValid)
            {
                videoVersion.VideoVersionId = Guid.NewGuid();
                db.VideoVersions.Add(videoVersion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", videoVersion.VideoReleaseId);
            ViewBag.VideoVersionTypeId = new SelectList(db.VideoVersionTypes, "VideoVersionTypeId", "VideoVersionTitle", videoVersion.VideoVersionTypeId);
            return View(videoVersion);
        }

        // GET: VideoVersions/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoVersion videoVersion = db.VideoVersions.Find(id);
            if (videoVersion == null)
            {
                return HttpNotFound();
            }
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", videoVersion.VideoReleaseId);
            ViewBag.VideoVersionTypeId = new SelectList(db.VideoVersionTypes, "VideoVersionTypeId", "VideoVersionTitle", videoVersion.VideoVersionTypeId);
            return View(videoVersion);
        }

        // POST: VideoVersions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoVersionId,VideoVersionTypeId,VideoReleaseId")] VideoVersion videoVersion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoVersion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", videoVersion.VideoReleaseId);
            ViewBag.VideoVersionTypeId = new SelectList(db.VideoVersionTypes, "VideoVersionTypeId", "VideoVersionTitle", videoVersion.VideoVersionTypeId);
            return View(videoVersion);
        }

        // GET: VideoVersions/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoVersion videoVersion = db.VideoVersions.Find(id);
            if (videoVersion == null)
            {
                return HttpNotFound();
            }
            return View(videoVersion);
        }

        // POST: VideoVersions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            VideoVersion videoVersion = db.VideoVersions.Find(id);
            db.VideoVersions.Remove(videoVersion);
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
