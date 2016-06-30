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
    public class StandardTypesController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: StandardTypes
        public ActionResult Index()
        {
            return View(db.StandardTypes.ToList());
        }

        // GET: StandardTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StandardType standardType = db.StandardTypes.Find(id);
            if (standardType == null)
            {
                return HttpNotFound();
            }
            return View(standardType);
        }

        // GET: StandardTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StandardTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StandardTypeId,StandardName,StandardDescription")] StandardType standardType)
        {
            if (ModelState.IsValid)
            {
                standardType.StandardTypeId = Guid.NewGuid();
                db.StandardTypes.Add(standardType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(standardType);
        }

        // GET: StandardTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StandardType standardType = db.StandardTypes.Find(id);
            if (standardType == null)
            {
                return HttpNotFound();
            }
            return View(standardType);
        }

        // POST: StandardTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StandardTypeId,StandardName,StandardDescription")] StandardType standardType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(standardType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(standardType);
        }

        // GET: StandardTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StandardType standardType = db.StandardTypes.Find(id);
            if (standardType == null)
            {
                return HttpNotFound();
            }
            return View(standardType);
        }

        // POST: StandardTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            StandardType standardType = db.StandardTypes.Find(id);
            db.StandardTypes.Remove(standardType);
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
