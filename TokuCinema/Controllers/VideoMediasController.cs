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
    public class VideoMediasController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: VideoMedias
        public ActionResult Index()
        {
            var videoMedias = db.VideoMedias.Include(v => v.Medium);
            return View(videoMedias.OrderBy(v => v.ReleaseDate).ToList());
        }

        // GET: VideoMedias/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoMedia videoMedia = db.VideoMedias.Find(id);
            if (videoMedia == null)
            {
                return HttpNotFound();
            }
            return View(videoMedia);
        }

        // GET: VideoMedias/Create
        public ActionResult Create()
        {
            ViewBag.MediaId = new SelectList(db.Media, "MediaId", "MediaOfficialTitle");
            return View();
        }

        // POST: VideoMedias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoMediaId,MediaId,ReleaseDate,OriginalAspectRatio,OriginalRuntime")] VideoMedia videoMedia)
        {
            if (ModelState.IsValid)
            {
                videoMedia.VideoMediaId = Guid.NewGuid();
                db.VideoMedias.Add(videoMedia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MediaId = new SelectList(db.Media, "MediaId", "MediaOfficialTitle", videoMedia.MediaId);
            return View(videoMedia);
        }

        // GET: VideoMedias/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoMedia videoMedia = db.VideoMedias.Find(id);
            if (videoMedia == null)
            {
                return HttpNotFound();
            }
            ViewBag.MediaId = new SelectList(db.Media, "MediaId", "MediaOfficialTitle", videoMedia.MediaId);
            return View(videoMedia);
        }

        // POST: VideoMedias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoMediaId,MediaId,OriginalAspectRatio,OriginalRuntime")] VideoMedia videoMedia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoMedia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MediaId = new SelectList(db.Media, "MediaId", "MediaOfficialTitle", videoMedia.MediaId);
            return View(videoMedia);
        }

        // GET: VideoMedias/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoMedia videoMedia = db.VideoMedias.Find(id);
            if (videoMedia == null)
            {
                return HttpNotFound();
            }
            return View(videoMedia);
        }

        // POST: VideoMedias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            VideoMedia videoMedia = db.VideoMedias.Find(id);
            db.VideoMedias.Remove(videoMedia);
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
