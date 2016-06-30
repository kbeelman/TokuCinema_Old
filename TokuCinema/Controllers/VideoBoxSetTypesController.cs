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
    public class VideoBoxSetTypesController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: VideoBoxSetTypes
        public ActionResult Index()
        {
            return View(db.VideoBoxSetTypes.ToList());
        }

        // GET: VideoBoxSetTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoBoxSetType videoBoxSetType = db.VideoBoxSetTypes.Find(id);
            if (videoBoxSetType == null)
            {
                return HttpNotFound();
            }
            return View(videoBoxSetType);
        }

        // GET: VideoBoxSetTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideoBoxSetTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoBoxSetTypeId,VideoBoxSetTitle,VideoBoxSetDescription")] VideoBoxSetType videoBoxSetType)
        {
            if (ModelState.IsValid)
            {
                videoBoxSetType.VideoBoxSetTypeId = Guid.NewGuid();
                db.VideoBoxSetTypes.Add(videoBoxSetType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(videoBoxSetType);
        }

        // GET: VideoBoxSetTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoBoxSetType videoBoxSetType = db.VideoBoxSetTypes.Find(id);
            if (videoBoxSetType == null)
            {
                return HttpNotFound();
            }
            return View(videoBoxSetType);
        }

        // POST: VideoBoxSetTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoBoxSetTypeId,VideoBoxSetTitle,VideoBoxSetDescription")] VideoBoxSetType videoBoxSetType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoBoxSetType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(videoBoxSetType);
        }

        // GET: VideoBoxSetTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoBoxSetType videoBoxSetType = db.VideoBoxSetTypes.Find(id);
            if (videoBoxSetType == null)
            {
                return HttpNotFound();
            }
            return View(videoBoxSetType);
        }

        // POST: VideoBoxSetTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            VideoBoxSetType videoBoxSetType = db.VideoBoxSetTypes.Find(id);
            db.VideoBoxSetTypes.Remove(videoBoxSetType);
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
