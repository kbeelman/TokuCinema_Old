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
    public class MediaFilesController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: MediaFiles
        public ActionResult Index()
        {
            var mediaFiles = db.MediaFiles.Include(m => m.VideoVersion);
            return View(mediaFiles.ToList());
        }

        // GET: MediaFiles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaFile mediaFile = db.MediaFiles.Find(id);
            if (mediaFile == null)
            {
                return HttpNotFound();
            }
            return View(mediaFile);
        }

        // GET: MediaFiles/Create
        public ActionResult Create()
        {
            ViewBag.VideoVersionId = new SelectList(db.VideoVersions, "VideoVersionId", "VideoVersionId");
            return View();
        }

        // POST: MediaFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(/*[Bind(Include = "MediaFielId,VideoReleaseId,MediaFile1,Image,Video,Location")]*/ MediaFile mediaFile)
        {
            if (ModelState.IsValid)
            {
                mediaFile.MediaFileId = Guid.NewGuid();
                db.MediaFiles.Add(mediaFile);
                db.SaveChanges();
                return RedirectToAction("Index", "VideoReleases");
            }

            ViewBag.VideoVersionId = new SelectList(db.VideoVersions, "VideoVersionId", "VideoVersion.VideoVersionType.VideoVersionTitle", mediaFile.VideoVersionId);
            return View(mediaFile);
        }

        /*New Post method for allowing picture uploads*/
        // Post: MediaFiles/Upload
        [HttpPost]
        public ActionResult Upload(MediaFile mediaFile)
        {
            //if (ModelState.IsValid)
            //{
            // Set mediafile Id
            mediaFile.MediaFileId = Guid.NewGuid();

            if (mediaFile.File != null)
            {
                /* Leaving this commented out till we know what sort of size / type limitations we want to enforce
                 * 
                // Validation - size limitations
                if(company.File.ContentLength > (2 * 1024 * 1024))
                {
                    ModelState.AddModelError("CustomError","File size must be less than 2 MB");
                    return View(company);
                }

                *Type resctritions 
                //if (product.File.ContentType == "image/jpeg" || product.File.ContentType == "image/gif")
                //{
                //    ModelState.AddModelError("CustomError", "File type allowed : jpeg and gif");
                //    return View();
                //}

                */

                string name = mediaFile.File.FileName;
                int fileSize = mediaFile.File.ContentLength;

                byte[] data = new byte[fileSize];
                mediaFile.File.InputStream.Read(data, 0, fileSize);

                mediaFile.MediaFile1 = data;
            }
            using (TokuCinema_DataEntities db = new TokuCinema_DataEntities())
            {
                db.MediaFiles.Add(mediaFile);
                db.SaveChanges();
            }
            //}

            return RedirectToAction("Index", "VideoReleases");
        }

        // GET: MediaFiles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaFile mediaFile = db.MediaFiles.Find(id);
            if (mediaFile == null)
            {
                return HttpNotFound();
            }
            ViewBag.VideoVersionId = new SelectList(db.VideoVersions, "VideoVersionId", "VideoVersionId", mediaFile.VideoVersionId);
            return View(mediaFile);
        }

        // POST: MediaFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MediaFileId,VideoVersionId,MediaFile1,Image,Video,Location,MediaLink,UseFileOverLink")] MediaFile mediaFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mediaFile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VideoVersionId = new SelectList(db.VideoVersions, "VideoVersionId", "VideoVersionId", mediaFile.VideoVersionId);
            return View(mediaFile);
        }

        // GET: MediaFiles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MediaFile mediaFile = db.MediaFiles.Find(id);
            if (mediaFile == null)
            {
                return HttpNotFound();
            }
            return View(mediaFile);
        }

        // POST: MediaFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            MediaFile mediaFile = db.MediaFiles.Find(id);
            db.MediaFiles.Remove(mediaFile);
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
