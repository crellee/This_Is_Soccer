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
    public class ClubController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Club
        public ActionResult Index()
        {
            var clubModels = db.ClubModels.Include(c => c.Country);
            return View(clubModels.ToList());
        }

        // GET: Club/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubModel clubModel = db.ClubModels.Find(id);
            if (clubModel == null)
            {
                return HttpNotFound();
            }
            return View(clubModel);
        }

        // GET: Club/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName");
            return View();
        }

        // POST: Club/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClubId,ClubName,ClubLogo,CountryId")] ClubModel clubModel)
        {
            if (ModelState.IsValid)
            {
                db.ClubModels.Add(clubModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", clubModel.CountryId);
            return View(clubModel);
        }

        // GET: Club/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubModel clubModel = db.ClubModels.Find(id);
            if (clubModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", clubModel.CountryId);
            return View(clubModel);
        }

        // POST: Club/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClubId,ClubName,ClubLogo,CountryId")] ClubModel clubModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clubModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "CountryName", clubModel.CountryId);
            return View(clubModel);
        }

        // GET: Club/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubModel clubModel = db.ClubModels.Find(id);
            if (clubModel == null)
            {
                return HttpNotFound();
            }
            return View(clubModel);
        }

        // POST: Club/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClubModel clubModel = db.ClubModels.Find(id);
            db.ClubModels.Remove(clubModel);
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
