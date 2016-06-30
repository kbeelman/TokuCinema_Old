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
    public class SubtitleTracksController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: SubtitleTracks
        public ActionResult Index()
        {
            var subtitleTracks = db.SubtitleTracks.Include(s => s.Language).Include(s => s.VideoRelease);
            return View(subtitleTracks.ToList());
        }

        // GET: SubtitleTracks/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubtitleTrack subtitleTrack = db.SubtitleTracks.Find(id);
            if (subtitleTrack == null)
            {
                return HttpNotFound();
            }
            return View(subtitleTrack);
        }

        // GET: SubtitleTracks/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "LanguageName");
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode");
            return View();
        }

        // POST: SubtitleTracks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubtitleTrackId,VideoReleaseId,LanguageId,SubtitleTrackName,SubtitleTrackDescription")] SubtitleTrack subtitleTrack)
        {
            if (ModelState.IsValid)
            {
                subtitleTrack.SubtitleTrackId = Guid.NewGuid();
                db.SubtitleTracks.Add(subtitleTrack);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "LanguageName", subtitleTrack.LanguageId);
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", subtitleTrack.VideoReleaseId);
            return View(subtitleTrack);
        }

        // GET: SubtitleTracks/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubtitleTrack subtitleTrack = db.SubtitleTracks.Find(id);
            if (subtitleTrack == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "LanguageName", subtitleTrack.LanguageId);
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", subtitleTrack.VideoReleaseId);
            return View(subtitleTrack);
        }

        // POST: SubtitleTracks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubtitleTrackId,VideoReleaseId,LanguageId,SubtitleTrackName,SubtitleTrackDescription")] SubtitleTrack subtitleTrack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subtitleTrack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "LanguageName", subtitleTrack.LanguageId);
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", subtitleTrack.VideoReleaseId);
            return View(subtitleTrack);
        }

        // GET: SubtitleTracks/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubtitleTrack subtitleTrack = db.SubtitleTracks.Find(id);
            if (subtitleTrack == null)
            {
                return HttpNotFound();
            }
            return View(subtitleTrack);
        }

        // POST: SubtitleTracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            SubtitleTrack subtitleTrack = db.SubtitleTracks.Find(id);
            db.SubtitleTracks.Remove(subtitleTrack);
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
