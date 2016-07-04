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
    public class VideoReviewsController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: VideoReviews
        public ActionResult Index()
        {
            var videoReviews = db.VideoReviews.Include(v => v.VideoRelease);
            return View(videoReviews.ToList());
        }

        // GET: VideoReviews/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoReview videoReview = db.VideoReviews.Find(id);
            if (videoReview == null)
            {
                return HttpNotFound();
            }
            return View(videoReview);
        }

        // GET: VideoReviews/Create
        public ActionResult Create()
        {
            ViewBag.VideoreleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode");
            return View();
        }

        // POST: VideoReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoReviewId,VideoreleaseId,Introduction,PresentationComments,PresentationScore,VideoComments,VideoScore,AudioComments,AudioScore,BonusFeatureComments,BonusFeatureScore,VerdictComments,VerdictScore")] VideoReview videoReview)
        {
            if (ModelState.IsValid)
            {
                videoReview.VideoReviewId = Guid.NewGuid();
                db.VideoReviews.Add(videoReview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VideoreleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", videoReview.VideoreleaseId);
            return View(videoReview);
        }

        // GET: VideoReviews/CreateReview
        public ActionResult CreateReview(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.VideoreleaseId = id;
            return View();
        }

        // POST: VideoReviews/CreateReview
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateReview(/*[Bind(Include = "VideoReviewId,VideoreleaseId,Introduction,PresentationComments,PresentationScore,VideoComments,VideoScore,AudioComments,AudioScore,BonusFeatureComments,BonusFeatureScore,VerdictComments,VerdictScore")]*/ VideoReview videoReview)
        {
            if (ModelState.IsValid)
            {
                videoReview.VideoReviewId = Guid.NewGuid();
                db.VideoReviews.Add(videoReview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VideoreleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", videoReview.VideoreleaseId);
            return View(videoReview);
        }

        // GET: VideoReviews/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoReview videoReview = db.VideoReviews.Find(id);
            if (videoReview == null)
            {
                return HttpNotFound();
            }
            ViewBag.VideoreleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", videoReview.VideoreleaseId);
            return View(videoReview);
        }

        // POST: VideoReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoReviewId,VideoreleaseId,Introduction,PresentationComments,PresentationScore,VideoComments,VideoScore,AudioComments,AudioScore,BonusFeatureComments,BonusFeatureScore,VerdictComments,VerdictScore")] VideoReview videoReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VideoreleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", videoReview.VideoreleaseId);
            return View(videoReview);
        }

        // GET: VideoReviews/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoReview videoReview = db.VideoReviews.Find(id);
            if (videoReview == null)
            {
                return HttpNotFound();
            }
            return View(videoReview);
        }

        // POST: VideoReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            VideoReview videoReview = db.VideoReviews.Find(id);
            db.VideoReviews.Remove(videoReview);
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
