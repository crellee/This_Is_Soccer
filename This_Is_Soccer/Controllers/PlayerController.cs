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
using This_Is_Soccer.Models.Interface;
using System.Data.Entity;

namespace This_Is_Soccer.Controllers
{
    public class PlayerController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private PlayerRepository repository = null;

        public PlayerController()
        {
            this.repository = new PlayerRepository();
        }

        
        PlayerController(PlayerRepository repository)
        {
            this.repository = repository;
        }
        

        // GET: Player
        public ActionResult Index()
        {
            var playerModels = repository.SelectAll();
            return View(playerModels.ToList());
        }
        /*
        // GET: Player/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerModel playerModel = db.PlayerModels.Find(id);
            if (playerModel == null)
            {
                return HttpNotFound();
            }
            return View(playerModel);
        }

        // GET: Player/Create
        public ActionResult Create()
        {
            ViewBag.ClubId = new SelectList(db.ClubModels, "ClubId", "ClubName");
            ViewBag.PositionId = new SelectList(db.PositionModels, "PositionId", "PositionName");
            return View();
        }

        // POST: Player/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerId,PlayerName,PlayerPic,ClubId,PositionId")] PlayerModel playerModel)
        {
            if (ModelState.IsValid)
            {
                db.PlayerModels.Add(playerModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClubId = new SelectList(db.ClubModels, "ClubId", "ClubName", playerModel.ClubId);
            ViewBag.PositionId = new SelectList(db.PositionModels, "PositionId", "PositionName", playerModel.PositionId);
            return View(playerModel);
        }

        // GET: Player/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerModel playerModel = db.PlayerModels.Find(id);
            if (playerModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClubId = new SelectList(db.ClubModels, "ClubId", "ClubName", playerModel.ClubId);
            ViewBag.PositionId = new SelectList(db.PositionModels, "PositionId", "PositionName", playerModel.PositionId);
            return View(playerModel);
        }

        // POST: Player/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerId,PlayerName,PlayerPic,ClubId,PositionId")] PlayerModel playerModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(playerModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClubId = new SelectList(db.ClubModels, "ClubId", "ClubName", playerModel.ClubId);
            ViewBag.PositionId = new SelectList(db.PositionModels, "PositionId", "PositionName", playerModel.PositionId);
            return View(playerModel);
        }

        // GET: Player/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerModel playerModel = db.PlayerModels.Find(id);
            if (playerModel == null)
            {
                return HttpNotFound();
            }
            return View(playerModel);
        }

        // POST: Player/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlayerModel playerModel = db.PlayerModels.Find(id);
            db.PlayerModels.Remove(playerModel);
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
        */
        
    }
}
