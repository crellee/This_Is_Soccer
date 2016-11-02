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
    public class LorteController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Lorte
        public ActionResult Index()
        {
            var myTeamModels = db.MyTeamModels.Include(m => m.Player);
            return View(myTeamModels.ToList());
        }

        // GET: Lorte/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyTeamModel myTeamModel = db.MyTeamModels.Find(id);
            if (myTeamModel == null)
            {
                return HttpNotFound();
            }
            return View(myTeamModel);
        }

        // GET: Lorte/Create
        public ActionResult Create()
        {
            ViewBag.PlayerId = new SelectList(db.PlayerModels, "PlayerId", "PlayerName");
            return View();
        }

        // POST: Lorte/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PositionId,PlayerId")] MyTeamModel myTeamModel)
        {
            if (ModelState.IsValid)
            {
                db.MyTeamModels.Add(myTeamModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlayerId = new SelectList(db.PlayerModels, "PlayerId", "PlayerName", myTeamModel.PlayerId);
            return View(myTeamModel);
        }

        // GET: Lorte/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyTeamModel myTeamModel = db.MyTeamModels.Find(id);
            if (myTeamModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerId = new SelectList(db.PlayerModels, "PlayerId", "PlayerName", myTeamModel.PlayerId);
            return View(myTeamModel);
        }

        // POST: Lorte/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PositionId,PlayerId")] MyTeamModel myTeamModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myTeamModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerId = new SelectList(db.PlayerModels, "PlayerId", "PlayerName", myTeamModel.PlayerId);
            return View(myTeamModel);
        }

        // GET: Lorte/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MyTeamModel myTeamModel = db.MyTeamModels.Find(id);
            if (myTeamModel == null)
            {
                return HttpNotFound();
            }
            return View(myTeamModel);
        }

        // POST: Lorte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MyTeamModel myTeamModel = db.MyTeamModels.Find(id);
            db.MyTeamModels.Remove(myTeamModel);
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
