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
    public class PositionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Position
        public ActionResult Index()
        {
            return View(db.PositionModels.ToList());
        }

        // GET: Position/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionModel positionModel = db.PositionModels.Find(id);
            if (positionModel == null)
            {
                return HttpNotFound();
            }
            return View(positionModel);
        }

        // GET: Position/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Position/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PositionId,PositionName")] PositionModel positionModel)
        {
            if (ModelState.IsValid)
            {
                db.PositionModels.Add(positionModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(positionModel);
        }

        // GET: Position/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionModel positionModel = db.PositionModels.Find(id);
            if (positionModel == null)
            {
                return HttpNotFound();
            }
            return View(positionModel);
        }

        // POST: Position/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PositionId,PositionName")] PositionModel positionModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(positionModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(positionModel);
        }

        // GET: Position/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionModel positionModel = db.PositionModels.Find(id);
            if (positionModel == null)
            {
                return HttpNotFound();
            }
            return View(positionModel);
        }

        // POST: Position/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PositionModel positionModel = db.PositionModels.Find(id);
            db.PositionModels.Remove(positionModel);
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
