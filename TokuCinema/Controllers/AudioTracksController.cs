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
    public class AudioTracksController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: AudioTracks
        public ActionResult Index()
        {
            var audioTracks = db.AudioTracks.Include(a => a.Language).Include(a => a.VideoRelease);
            return View(audioTracks.ToList());
        }

        // GET: AudioTracks/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AudioTrack audioTrack = db.AudioTracks.Find(id);
            if (audioTrack == null)
            {
                return HttpNotFound();
            }
            return View(audioTrack);
        }

        // GET: AudioTracks/Create
        public ActionResult Create(/*Guid? id*/)
        {
            // Implement Once Database is updated to reflect AudioTrack belonging to VideoVersions
            // bool will allow for dynamically passed ids or manual entry
            //ViewBag.idPassed = false;

            //if (id.HasValue)
            //{
            //    ViewBag.VideoVersionId = id;
            //    ViewBag.idPassed = true;
            //    return View();
            //}

            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "LanguageName");
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode");
            return View();
        }

        // POST: AudioTracks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AudioTrackid,VideoReleaseId,LanguageId,AudioTrackName,AudioTrackDescription,Channel")] AudioTrack audioTrack)
        {
            if (ModelState.IsValid)
            {
                audioTrack.AudioTrackid = Guid.NewGuid();
                db.AudioTracks.Add(audioTrack);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "LanguageName", audioTrack.LanguageId);
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", audioTrack.VideoReleaseId);
            return View(audioTrack);
        }

        // GET: AudioTracks/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AudioTrack audioTrack = db.AudioTracks.Find(id);
            if (audioTrack == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "LanguageName", audioTrack.LanguageId);
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", audioTrack.VideoReleaseId);
            return View(audioTrack);
        }

        // POST: AudioTracks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AudioTrackid,VideoReleaseId,LanguageId,AudioTrackName,AudioTrackDescription,Channel")] AudioTrack audioTrack)
        {
            if (ModelState.IsValid)
            {
                db.Entry(audioTrack).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "LanguageName", audioTrack.LanguageId);
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", audioTrack.VideoReleaseId);
            return View(audioTrack);
        }

        // GET: AudioTracks/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AudioTrack audioTrack = db.AudioTracks.Find(id);
            if (audioTrack == null)
            {
                return HttpNotFound();
            }
            return View(audioTrack);
        }

        // POST: AudioTracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AudioTrack audioTrack = db.AudioTracks.Find(id);
            db.AudioTracks.Remove(audioTrack);
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
