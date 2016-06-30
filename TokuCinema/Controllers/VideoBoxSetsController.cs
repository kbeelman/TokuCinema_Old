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
    public class VideoBoxSetsController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: VideoBoxSets
        public ActionResult Index()
        {
            var videoBoxSets = db.VideoBoxSets.Include(v => v.VideoBoxSetType).Include(v => v.VideoRelease);
            return View(videoBoxSets.ToList());
        }

        // GET: VideoBoxSets/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoBoxSet videoBoxSet = db.VideoBoxSets.Find(id);
            if (videoBoxSet == null)
            {
                return HttpNotFound();
            }
            return View(videoBoxSet);
        }

        // GET: VideoBoxSets/Create
        public ActionResult Create()
        {
            ViewBag.VideoBoxSetTypeId = new SelectList(db.VideoBoxSetTypes, "VideoBoxSetTypeId", "VideoBoxSetTitle");
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode");
            return View();
        }

        // POST: VideoBoxSets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoBoxSetId,VideoBoxSetTypeId,VideoReleaseId")] VideoBoxSet videoBoxSet)
        {
            if (ModelState.IsValid)
            {
                videoBoxSet.VideoBoxSetId = Guid.NewGuid();
                db.VideoBoxSets.Add(videoBoxSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VideoBoxSetTypeId = new SelectList(db.VideoBoxSetTypes, "VideoBoxSetTypeId", "VideoBoxSetTitle", videoBoxSet.VideoBoxSetTypeId);
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", videoBoxSet.VideoReleaseId);
            return View(videoBoxSet);
        }

        // GET: VideoBoxSets/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoBoxSet videoBoxSet = db.VideoBoxSets.Find(id);
            if (videoBoxSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.VideoBoxSetTypeId = new SelectList(db.VideoBoxSetTypes, "VideoBoxSetTypeId", "VideoBoxSetTitle", videoBoxSet.VideoBoxSetTypeId);
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", videoBoxSet.VideoReleaseId);
            return View(videoBoxSet);
        }

        // POST: VideoBoxSets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoBoxSetId,VideoBoxSetTypeId,VideoReleaseId")] VideoBoxSet videoBoxSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoBoxSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VideoBoxSetTypeId = new SelectList(db.VideoBoxSetTypes, "VideoBoxSetTypeId", "VideoBoxSetTitle", videoBoxSet.VideoBoxSetTypeId);
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", videoBoxSet.VideoReleaseId);
            return View(videoBoxSet);
        }

        // GET: VideoBoxSets/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoBoxSet videoBoxSet = db.VideoBoxSets.Find(id);
            if (videoBoxSet == null)
            {
                return HttpNotFound();
            }
            return View(videoBoxSet);
        }

        // POST: VideoBoxSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            VideoBoxSet videoBoxSet = db.VideoBoxSets.Find(id);
            db.VideoBoxSets.Remove(videoBoxSet);
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
