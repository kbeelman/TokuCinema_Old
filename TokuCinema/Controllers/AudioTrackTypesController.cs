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
    public class AudioTrackTypesController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: AudioTrackTypes
        public ActionResult Index()
        {
            var audioTrackTypes = db.AudioTrackTypes.Include(a => a.Language);
            return View(audioTrackTypes.ToList());
        }

        // GET: AudioTrackTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AudioTrackType audioTrackType = db.AudioTrackTypes.Find(id);
            if (audioTrackType == null)
            {
                return HttpNotFound();
            }
            return View(audioTrackType);
        }

        // GET: AudioTrackTypes/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "LanguageName");
            return View();
        }

        // POST: AudioTrackTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AudioTrackTypeId,LanguageId,AudioTrackName,AudioTrackDescription,Channel")] AudioTrackType audioTrackType)
        {
            if (ModelState.IsValid)
            {
                audioTrackType.AudioTrackTypeId = Guid.NewGuid();
                db.AudioTrackTypes.Add(audioTrackType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "LanguageName", audioTrackType.LanguageId);
            return View(audioTrackType);
        }

        // GET: AudioTrackTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AudioTrackType audioTrackType = db.AudioTrackTypes.Find(id);
            if (audioTrackType == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "LanguageName", audioTrackType.LanguageId);
            return View(audioTrackType);
        }

        // POST: AudioTrackTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AudioTrackTypeId,LanguageId,AudioTrackName,AudioTrackDescription,Channel")] AudioTrackType audioTrackType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(audioTrackType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "LanguageName", audioTrackType.LanguageId);
            return View(audioTrackType);
        }

        // GET: AudioTrackTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AudioTrackType audioTrackType = db.AudioTrackTypes.Find(id);
            if (audioTrackType == null)
            {
                return HttpNotFound();
            }
            return View(audioTrackType);
        }

        // POST: AudioTrackTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            AudioTrackType audioTrackType = db.AudioTrackTypes.Find(id);
            db.AudioTrackTypes.Remove(audioTrackType);
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
