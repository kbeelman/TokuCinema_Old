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
    public class FormatTypesController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: FormatTypes
        public ActionResult Index()
        {
            return View(db.FormatTypes.ToList());
        }

        // GET: FormatTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormatType formatType = db.FormatTypes.Find(id);
            if (formatType == null)
            {
                return HttpNotFound();
            }
            return View(formatType);
        }

        // GET: FormatTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormatTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FormatTypeId,FormatName,FormatDescription")] FormatType formatType)
        {
            if (ModelState.IsValid)
            {
                formatType.FormatTypeId = Guid.NewGuid();
                db.FormatTypes.Add(formatType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(formatType);
        }

        // GET: FormatTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormatType formatType = db.FormatTypes.Find(id);
            if (formatType == null)
            {
                return HttpNotFound();
            }
            return View(formatType);
        }

        // POST: FormatTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FormatTypeId,FormatName,FormatDescription")] FormatType formatType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formatType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formatType);
        }

        // GET: FormatTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormatType formatType = db.FormatTypes.Find(id);
            if (formatType == null)
            {
                return HttpNotFound();
            }
            return View(formatType);
        }

        // POST: FormatTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            FormatType formatType = db.FormatTypes.Find(id);
            db.FormatTypes.Remove(formatType);
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
