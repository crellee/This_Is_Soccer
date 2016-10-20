using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using This_Is_Soccer.Models;
using This_Is_Soccer.Models.Entity;

namespace This_Is_Soccer.Controllers
{
    public class CountryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Country
        public ActionResult Index()
        {
            return View(db.Countries.ToList());
        }

        // GET: Country/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryModel countryModel = db.Countries.Find(id);
            if (countryModel == null)
            {
                return HttpNotFound();
            }
            return View(countryModel);
        }

        // GET: Country/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Country/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CountryId,CountryName")] CountryModel countryModel)
        {
            if (ModelState.IsValid)
            {
                db.Countries.Add(countryModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(countryModel);
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryModel countryModel = db.Countries.Find(id);
            if (countryModel == null)
            {
                return HttpNotFound();
            }
            return View(countryModel);
        }

        // POST: Country/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CountryId,CountryName")] CountryModel countryModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(countryModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(countryModel);
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryModel countryModel = db.Countries.Find(id);
            if (countryModel == null)
            {
                return HttpNotFound();
            }
            return View(countryModel);
        }

        // POST: Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CountryModel countryModel = db.Countries.Find(id);
            db.Countries.Remove(countryModel);
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
