﻿using System;
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
            var videoReleases = db.VideoReleases.Include(v => v.Distributor).Include(v => v.Packaging);
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
            ViewBag.VideoMediaId = new SelectList(db.VideoMedias, "VideoMediaId", "Medium.MediaOfficialTitle");
            return View();
        }

        public PartialViewResult GetVersions(string id)
        {
            List<VideoVersionType> videoVersionTypes = db.VideoVersionTypes.Where(v => v.VideoMediaId.ToString() == id).ToList();
            ViewBag.VideoVersionTypeId = new SelectList(db.VideoVersionTypes.Where(v => v.VideoMediaId.ToString() == id), "VideoVersionTypeId", "VideoVersionTitle");
            return PartialView("_VideoVersionTypeList");
        }

        // POST: VideoReleases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoReleaseId,DistributorId,PackagingId,CatalogCode,UPC,ReleaseDate,DiscCount")] VideoRelease videoRelease)
        {
            if (ModelState.IsValid)
            {
                videoRelease.VideoReleaseId = Guid.NewGuid();
                db.VideoReleases.Add(videoRelease);
                string stringNumOfVersions = Request["numberOfVersions"];
                int numberOfVersions = Int32.Parse(stringNumOfVersions);
                for(int i = 1; i <= numberOfVersions; i++)
                {
                    VideoVersion videoVersion = new VideoVersion();
                    videoVersion.VideoVersionId = Guid.NewGuid();
                    videoVersion.VideoReleaseId = videoRelease.VideoReleaseId;
                    videoVersion.VideoVersionTypeId = Guid.Parse(Request["selectedVersion" + i]);
                    db.VideoVersions.Add(videoVersion);
                }
                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistributorId = new SelectList(db.Distributors, "DistributorId", "DistributorName", videoRelease.DistributorId);
            ViewBag.PackagingId = new SelectList(db.Packagings, "PackagingId", "PackagingName", videoRelease.PackagingId);
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
            return View(videoRelease);
        }

        // POST: VideoReleases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoReleaseId,DistributorId,PackagingId,CatalogCode,UPC,ReleaseDate,DiscCount")] VideoRelease videoRelease)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoRelease).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistributorId = new SelectList(db.Distributors, "DistributorId", "DistributorName", videoRelease.DistributorId);
            ViewBag.PackagingId = new SelectList(db.Packagings, "PackagingId", "PackagingDescription", videoRelease.PackagingId);
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
