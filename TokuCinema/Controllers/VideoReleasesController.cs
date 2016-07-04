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
    public class VideoReleasesController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: VideoReleases
        public ActionResult Index()
        {
            var videoReleases = db.VideoReleases.Include(v => v.Distributor).Include(v => v.Packaging).Include(v => v.VideoMedia);
            return View(videoReleases.ToList());
        }

        // GET: VideoReleases/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoRelease videoRelease = db.VideoReleases.Find(id);
            if (videoRelease == null)
            {
                return HttpNotFound();
            }
            return View(videoRelease);
        }

        // GET: VideoReleases/Create
        public ActionResult Create()
        {
            ViewBag.DistributorId = new SelectList(db.Distributors, "DistributorId", "DistributorName");
            ViewBag.PackagingId = new SelectList(db.Packagings, "PackagingId", "PackagingName");
            ViewBag.VideoMediaId = new SelectList(db.VideoMedias, "VideoMediaId", "VideoMediaId");
            return View();
        }

        // POST: VideoReleases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoReleaseId,DistributorId,PackagingId,VideoMediaId,CatalogCode,UPC,ReleaseDate,DiscCount,AspectRatio,Runtime,ChapterStops")] VideoRelease videoRelease)
        {
            if (ModelState.IsValid)
            {
                videoRelease.VideoReleaseId = Guid.NewGuid();
                db.VideoReleases.Add(videoRelease);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistributorId = new SelectList(db.Distributors, "DistributorId", "DistributorName", videoRelease.DistributorId);
            ViewBag.PackagingId = new SelectList(db.Packagings, "PackagingId", "PackagingName", videoRelease.PackagingId);
            ViewBag.VideoMediaId = new SelectList(db.VideoMedias, "VideoMediaId", "VideoMediaId", videoRelease.VideoMediaId);
            return View(videoRelease);
        }

        // GET: VideoReleases/CreateRelease
        public ActionResult CreateRelease(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.VideoMediaId = id;
            
            ViewBag.DistributorId = new SelectList(db.Distributors, "DistributorId", "DistributorName");
            ViewBag.PackagingId = new SelectList(db.Packagings, "PackagingId", "PackagingName");
            return View();
        }

        // POST: VideoReleases/CreateRelease
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRelease(/*[Bind(Include = "VideoReleaseId,DistributorId,PackagingId,VideoMediaId,CatalogCode,UPC,ReleaseDate,DiscCount,AspectRatio,Runtime,ChapterStops")]*/ VideoRelease videoRelease)
        {
            if (ModelState.IsValid)
            {
                videoRelease.VideoReleaseId = Guid.NewGuid();
                db.VideoReleases.Add(videoRelease);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistributorId = new SelectList(db.Distributors, "DistributorId", "DistributorName", videoRelease.DistributorId);
            ViewBag.PackagingId = new SelectList(db.Packagings, "PackagingId", "PackagingName", videoRelease.PackagingId);
            ViewBag.VideoMediaId = new SelectList(db.VideoMedias, "VideoMediaId", "OriginalAspectRatio", videoRelease.VideoMediaId);
            return View(videoRelease);
        }

        // GET: VideoReleases/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoRelease videoRelease = db.VideoReleases.Find(id);
            if (videoRelease == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistributorId = new SelectList(db.Distributors, "DistributorId", "DistributorName", videoRelease.DistributorId);
            ViewBag.PackagingId = new SelectList(db.Packagings, "PackagingId", "PackagingDescription", videoRelease.PackagingId);
            ViewBag.VideoMediaId = new SelectList(db.VideoMedias, "VideoMediaId", "OriginalAspectRatio", videoRelease.VideoMediaId);
            return View(videoRelease);
        }

        // POST: VideoReleases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoReleaseId,DistributorId,PackagingId,VideoMediaId,CatalogCode,UPC,ReleaseDate,DiscCount,AspectRatio,Runtime,ChapterStops")] VideoRelease videoRelease)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoRelease).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistributorId = new SelectList(db.Distributors, "DistributorId", "DistributorName", videoRelease.DistributorId);
            ViewBag.PackagingId = new SelectList(db.Packagings, "PackagingId", "PackagingDescription", videoRelease.PackagingId);
            ViewBag.VideoMediaId = new SelectList(db.VideoMedias, "VideoMediaId", "OriginalAspectRatio", videoRelease.VideoMediaId);
            return View(videoRelease);
        }

        // GET: VideoReleases/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoRelease videoRelease = db.VideoReleases.Find(id);
            if (videoRelease == null)
            {
                return HttpNotFound();
            }
            return View(videoRelease);
        }

        // POST: VideoReleases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            VideoRelease videoRelease = db.VideoReleases.Find(id);
            db.VideoReleases.Remove(videoRelease);
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
