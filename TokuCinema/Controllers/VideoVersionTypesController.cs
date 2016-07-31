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
    public class VideoVersionTypesController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: VideoVersionTypes
        public ActionResult Index()
        {
            return View(db.VideoVersionTypes.ToList());
        }

        // GET: SearchIndex
        public ActionResult SearchIndex(string id)
        {
            ViewBag.queryId = id;

            List<VideoVersionType> searchResults = new List<VideoVersionType>();
            searchResults = TokuCinema.Services.SearchingService.MovieSearch(db.VideoVersionTypes.ToList(), id);

            return View(searchResults.OrderBy(t => Math.Abs(t.VideoVersionTitle.Length - id.Length)));
        }

        // GET: VideoVersionTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoVersionType videoVersionType = db.VideoVersionTypes.Find(id);
            if (videoVersionType == null)
            {
                return HttpNotFound();
            }
            return View(videoVersionType);
        }

        // GET: VideoVersionTypes/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // GET: VideoVersionTypes/Create/5
        public ActionResult Create(Guid? id)
        {
            // bool will allow for dynamically passed ids or manual entry
            ViewBag.idPassed = false;

            if (id.HasValue)
            {
                ViewBag.VideoMediaId = id;
                ViewBag.idPassed = true;
                return View();
            }
            else
            {
                ViewBag.VideoMediaId = new SelectList(db.VideoMedias, "VideoMediaId", "Medium.MediaOfficialTitle");
                ViewBag.idPassed = false;
                return View();
            }
        }

        // POST: VideoVersionTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoVersionTypeId,VideoMediaId,VideoVersionTitle,VideoVersionDescription,AspectRatio,Runtime,ChapterStops")] VideoVersionType videoVersionType)
        {
            if (ModelState.IsValid)
            {
                videoVersionType.VideoVersionTypeId = Guid.NewGuid();
                db.VideoVersionTypes.Add(videoVersionType);
                db.SaveChanges();
                return RedirectToAction("Index", "Media");
            }

            return View(videoVersionType);
        }

        // GET: VideoVersionTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoVersionType videoVersionType = db.VideoVersionTypes.Find(id);
            if (videoVersionType == null)
            {
                return HttpNotFound();
            }
            return View(videoVersionType);
        }

        // POST: VideoVersionTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoVersionTypeId,VideoMediaId,VideoVersionTitle,VideoVersionDescription,AspectRatio,Runtime,ChapterStops")] VideoVersionType videoVersionType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoVersionType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Media");
            }
            return View(videoVersionType);
        }

        // GET: VideoVersionTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // Get number of child records - used to let view know not to allow the user to attempt a delete
            int childRecords = 0;
            foreach (var videoVersionItem in db.VideoVersions.Where(v => v.VideoVersionTypeId == id))
            {
                childRecords++;
            }
            ViewBag.ChildRecords = childRecords;

            VideoVersionType videoVersionType = db.VideoVersionTypes.Find(id);
            if (videoVersionType == null)
            {
                return HttpNotFound();
            }
            return View(videoVersionType);
        }

        // POST: VideoVersionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            VideoVersionType videoVersionType = db.VideoVersionTypes.Find(id);
            db.VideoVersionTypes.Remove(videoVersionType);
            db.SaveChanges();
            return RedirectToAction("Index", "Media");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public JsonResult GetVideoVersionTypeTitleList()
        {
            List<string> titleList = new List<string>();
            foreach (var item in db.VideoVersionTypes)
            {
                titleList.Add(item.VideoVersionTitle);
            }

            return Json(titleList.Distinct(), JsonRequestBehavior.AllowGet);
        }
    }
}
