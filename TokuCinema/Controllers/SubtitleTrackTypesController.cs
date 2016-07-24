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
    public class SubtitleTrackTypesController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: SubtitleTrackTypes
        public ActionResult Index()
        {
            var subtitleTrackTypes = db.SubtitleTrackTypes.Include(s => s.Language);
            return View(subtitleTrackTypes.ToList());
        }

        // GET: SubtitleTrackTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubtitleTrackType subtitleTrackType = db.SubtitleTrackTypes.Find(id);
            if (subtitleTrackType == null)
            {
                return HttpNotFound();
            }
            return View(subtitleTrackType);
        }

        // GET: SubtitleTrackTypes/Create
        public ActionResult Create()
        {
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "LanguageName");
            return View();
        }

        // POST: SubtitleTrackTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubtitleTrackTypeId,LanguageId,SubtitleTrackName,SubtitleTrackDescription")] SubtitleTrackType subtitleTrackType)
        {
            if (ModelState.IsValid)
            {
                subtitleTrackType.SubtitleTrackTypeId = Guid.NewGuid();
                db.SubtitleTrackTypes.Add(subtitleTrackType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "LanguageName", subtitleTrackType.LanguageId);
            return View(subtitleTrackType);
        }

        // GET: SubtitleTrackTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubtitleTrackType subtitleTrackType = db.SubtitleTrackTypes.Find(id);
            if (subtitleTrackType == null)
            {
                return HttpNotFound();
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "LanguageName", subtitleTrackType.LanguageId);
            return View(subtitleTrackType);
        }

        // POST: SubtitleTrackTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubtitleTrackTypeId,LanguageId,SubtitleTrackName,SubtitleTrackDescription")] SubtitleTrackType subtitleTrackType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subtitleTrackType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LanguageId = new SelectList(db.Languages, "LanguageId", "LanguageName", subtitleTrackType.LanguageId);
            return View(subtitleTrackType);
        }

        // GET: SubtitleTrackTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubtitleTrackType subtitleTrackType = db.SubtitleTrackTypes.Find(id);
            if (subtitleTrackType == null)
            {
                return HttpNotFound();
            }
            return View(subtitleTrackType);
        }

        // POST: SubtitleTrackTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            SubtitleTrackType subtitleTrackType = db.SubtitleTrackTypes.Find(id);
            db.SubtitleTrackTypes.Remove(subtitleTrackType);
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
