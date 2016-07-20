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
    public class ShoppingItemsController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: ShoppingItems
        public ActionResult Index()
        {
            var shoppingItems = db.ShoppingItems.Include(s => s.Company);
            return View(shoppingItems.ToList());
        }

        // GET: ShoppingItems/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingItem shoppingItem = db.ShoppingItems.Find(id);
            if (shoppingItem == null)
            {
                return HttpNotFound();
            }
            return View(shoppingItem);
        }

        // GET: ShoppingItems/Create
        public ActionResult Create(Guid? id)
        {
            ViewBag.idPassed = false;

            if (id.HasValue)
            {
                ViewBag.CompanyId = id;
                ViewBag.idPassed = true; 
                return View();
            }
            else
            {
                ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName");
                ViewBag.idPassed = false;
                return View();
            }
        }

        // POST: ShoppingItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShoppingItemId,CompanyId,PurchaseLink")] ShoppingItem shoppingItem)
        {
            if (ModelState.IsValid)
            {
                shoppingItem.ShoppingItemId = Guid.NewGuid();
                db.ShoppingItems.Add(shoppingItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", shoppingItem.CompanyId);
            return View(shoppingItem);
        }

        // GET: ShoppingItems/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingItem shoppingItem = db.ShoppingItems.Find(id);
            if (shoppingItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", shoppingItem.CompanyId);
            return View(shoppingItem);
        }

        // POST: ShoppingItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShoppingItemId,CompanyId,PurchaseLink")] ShoppingItem shoppingItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shoppingItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", shoppingItem.CompanyId);
            return View(shoppingItem);
        }

        // GET: ShoppingItems/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShoppingItem shoppingItem = db.ShoppingItems.Find(id);
            if (shoppingItem == null)
            {
                return HttpNotFound();
            }
            return View(shoppingItem);
        }

        // POST: ShoppingItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            ShoppingItem shoppingItem = db.ShoppingItems.Find(id);
            db.ShoppingItems.Remove(shoppingItem);
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
