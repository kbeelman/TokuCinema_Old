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
            List<Movie> movies = new List<Movie>();
            var videoMedias = db.VideoMedias.OrderBy(v => v.ReleaseDate);
            foreach (VideoMedia videoMedia in videoMedias)
            {
                movies.Add(new Movie(videoMedia.VideoMediaId));
            }

            return View(movies);
        }

        // GET: VideoMedias/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = new Movie(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: VideoMedias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideoMedias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            var videoMedia = movie.VideoMedia;
            var media = movie.Media;

            if (ModelState.IsValid)
            {
                // Add media
                media.MediaId = Guid.NewGuid();
                db.Media.Add(media);
                
                // Add video media
                videoMedia.VideoMediaId = Guid.NewGuid();
                videoMedia.MediaId = media.MediaId;
                db.VideoMedias.Add(videoMedia);

                // Add "original version"
                VideoVersionType originalVersion = new VideoVersionType();
                originalVersion.VideoVersionTypeId = Guid.NewGuid();
                originalVersion.VideoMediaId = videoMedia.VideoMediaId;
                originalVersion.VideoVersionTitle = media.MediaOfficialTitle;
                originalVersion.VideoVersionDescription = "Original Version";
                originalVersion.AspectRatio = videoMedia.OriginalAspectRatio;
                originalVersion.Runtime = videoMedia.OriginalRuntime;
                originalVersion.ChapterStops = 0; //Populate this with dummy values for now
                db.VideoVersionTypes.Add(originalVersion);

                db.SaveChanges();
                return RedirectToAction("Index", "Media");
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
            Movie movie = new Movie(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: VideoMedias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            if (ModelState.IsValid)
            {
                db.Entry(movie.Media).State = EntityState.Modified;
                db.Entry(movie.VideoMedia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Media");
            }
            return View(movie);
        }

        // GET: VideoMedias/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = new Movie(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: VideoMedias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Movie movie = new Movie(id);
            db.VideoMedias.Remove(db.VideoMedias.Find(movie.VideoMedia.VideoMediaId));
            db.Media.Remove(db.Media.Find(movie.Media.MediaId));
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
    }
}
