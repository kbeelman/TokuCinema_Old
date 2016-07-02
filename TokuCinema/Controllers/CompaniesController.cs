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
    public class CompaniesController : Controller
    {
        private TokuCinema_DataEntities db = new TokuCinema_DataEntities();

        // GET: Companies
        public ActionResult Index()
        {
            return View(db.Companies.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyId,CompanyName,Image")] Company company)
        {
            if (ModelState.IsValid)
            {
                company.CompanyId = Guid.NewGuid();
                db.Companies.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(company);
        }

        /*New Post method for allowing picture uploads*/
        // Post: Companies/Upload
        [HttpPost]
        public ActionResult Upload(Company company)
        {
            if (ModelState.IsValid)
            {
                // Set Company Id
                company.CompanyId = Guid.NewGuid();

                if (company.File != null)
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

                    string name = company.File.FileName;
                    int imageSize = company.File.ContentLength;

                    byte[] data = new byte[imageSize];
                    company.File.InputStream.Read(data, 0, imageSize);

                    company.Image = data;
                }
                using (TokuCinema_DataEntities db = new TokuCinema_DataEntities())
                {
                    db.Companies.Add(company);
                    db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*[Bind(Include = "CompanyId,CompanyName,Image")]*/ Company company)
        {
            // get / retain original
            Company original = db.Companies.Find(company.CompanyId);

            //**original implementation
            //if (ModelState.IsValid)
            //{
            //    db.Entry(company).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(company);

            if (ModelState.IsValid)
            {
                if (company.File == null)
                {
                    // Make changes to original without replacing picture
                    original.CompanyName = company.CompanyName;
                    db.SaveChanges();
                }

                else
                {
                    // Make changes to original including replacing the picture

                    /* Decide on validation later - see comments in upload action method
                    // Validation
                    if (product.File.ContentLength > (2 * 1024 * 1024))
                    {
                        ModelState.AddModelError("CustomError", "File size must be less than 2 MB");
                        return View(product);
                    }
                    */
                    string name = company.File.FileName;
                    int imageSize = company.File.ContentLength;

                    byte[] data = new byte[imageSize];
                    company.File.InputStream.Read(data, 0, imageSize);

                    original.Image = data;
                    original.CompanyName = company.CompanyName;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
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
