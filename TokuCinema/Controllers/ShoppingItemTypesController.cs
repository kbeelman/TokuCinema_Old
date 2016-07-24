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
    public class ShoppingItemTypesController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: ShoppingItemTypes
        public ActionResult Index()
        {
            var shoppingItemTypes = db.ShoppingItemTypes.Include(s => s.Company);
            return View(shoppingItemTypes.ToList());
        }

        // GET: ShoppingItemTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingItemType shoppingItemType = db.ShoppingItemTypes.Find(id);
            if (shoppingItemType == null)
            {
                return HttpNotFound();
            }
            return View(shoppingItemType);
        }

        // GET: ShoppingItemTypes/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName");
            return View();
        }

        // POST: ShoppingItemTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShoppingItemTypeId,CompanyId,ShoppingItemName,PurchaseLink")] ShoppingItemType shoppingItemType)
        {
            if (ModelState.IsValid)
            {
                shoppingItemType.ShoppingItemTypeId = Guid.NewGuid();
                db.ShoppingItemTypes.Add(shoppingItemType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", shoppingItemType.CompanyId);
            return View(shoppingItemType);
        }

        // GET: ShoppingItemTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingItemType shoppingItemType = db.ShoppingItemTypes.Find(id);
            if (shoppingItemType == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", shoppingItemType.CompanyId);
            return View(shoppingItemType);
        }

        // POST: ShoppingItemTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShoppingItemTypeId,CompanyId,ShoppingItemName,PurchaseLink")] ShoppingItemType shoppingItemType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoppingItemType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", shoppingItemType.CompanyId);
            return View(shoppingItemType);
        }

        // GET: ShoppingItemTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingItemType shoppingItemType = db.ShoppingItemTypes.Find(id);
            if (shoppingItemType == null)
            {
                return HttpNotFound();
            }
            return View(shoppingItemType);
        }

        // POST: ShoppingItemTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ShoppingItemType shoppingItemType = db.ShoppingItemTypes.Find(id);
            db.ShoppingItemTypes.Remove(shoppingItemType);
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
