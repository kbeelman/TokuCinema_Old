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
    public class VideoShoppingItemsController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: VideoShoppingItems
        public ActionResult Index()
        {
            var videoShoppingItems = db.VideoShoppingItems.Include(v => v.ShoppingItemType).Include(v => v.VideoRelease);
            return View(videoShoppingItems.ToList());
        }

        // GET: VideoShoppingItems/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoShoppingItem videoShoppingItem = db.VideoShoppingItems.Find(id);
            if (videoShoppingItem == null)
            {
                return HttpNotFound();
            }
            return View(videoShoppingItem);
        }

        // GET: VideoShoppingItems/Create
        public ActionResult Create()
        {
            ViewBag.ShoppingItemTypeId = new SelectList(db.ShoppingItemTypes, "ShoppingItemTypeId", "ShoppingItemTypeId");
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode");
            return View();
        }

        // POST: VideoShoppingItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VideoShoppingItemId,ShoppingItemTypeId,VideoReleaseId")] VideoShoppingItem videoShoppingItem)
        {
            if (ModelState.IsValid)
            {
                videoShoppingItem.VideoShoppingItemId = Guid.NewGuid();
                db.VideoShoppingItems.Add(videoShoppingItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ShoppingItemTypeId = new SelectList(db.ShoppingItemTypes, "ShoppingItemTypeId", "ShoppingItemTypeId", videoShoppingItem.ShoppingItemTypeId);
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", videoShoppingItem.VideoReleaseId);
            return View(videoShoppingItem);
        }

        // GET: VideoShoppingItems/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoShoppingItem videoShoppingItem = db.VideoShoppingItems.Find(id);
            if (videoShoppingItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ShoppingItemTypeId = new SelectList(db.ShoppingItemTypes, "ShoppingItemTypeId", "ShoppingItemTypeId", videoShoppingItem.ShoppingItemTypeId);
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", videoShoppingItem.VideoReleaseId);
            return View(videoShoppingItem);
        }

        // POST: VideoShoppingItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VideoShoppingItemId,ShoppingItemTypeId,VideoReleaseId")] VideoShoppingItem videoShoppingItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoShoppingItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ShoppingItemTypeId = new SelectList(db.ShoppingItemTypes, "ShoppingItemTypeId", "ShoppingItemTypeId", videoShoppingItem.ShoppingItemTypeId);
            ViewBag.VideoReleaseId = new SelectList(db.VideoReleases, "VideoReleaseId", "CatalogCode", videoShoppingItem.VideoReleaseId);
            return View(videoShoppingItem);
        }

        // GET: VideoShoppingItems/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoShoppingItem videoShoppingItem = db.VideoShoppingItems.Find(id);
            if (videoShoppingItem == null)
            {
                return HttpNotFound();
            }
            return View(videoShoppingItem);
        }

        // POST: VideoShoppingItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            VideoShoppingItem videoShoppingItem = db.VideoShoppingItems.Find(id);
            db.VideoShoppingItems.Remove(videoShoppingItem);
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
