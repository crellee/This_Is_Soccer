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
using This_Is_Soccer.Models.Entity.ViewModels;

namespace This_Is_Soccer.Controllers
{
    public class PlayerController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private  IPlayerRepository repository;
        private IGenericRepository<PlayerModel> genericRepo;

        public PlayerController()
        {
            this.repository = new PlayerRepository();
            this.genericRepo = new GenericRepository<PlayerModel>();
        }

        
        public PlayerController(IPlayerRepository repository, IGenericRepository<PlayerModel> genericRepo)
        {
            this.repository = repository;
            this.genericRepo = genericRepo;
        }
        

        // GET: Player
        public ActionResult Index(string searchString = "")
        {

            var playerModels = repository.Search(searchString);
            return View(playerModels);
        }
        
        // GET: Player/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerModel playerModel = repository.SelectByID(id);
            if (playerModel == null)
            {
                return HttpNotFound();
            }
            return View(playerModel);
        }

        public ActionResult PlayerDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerModel playerModel = repository.SelectByID(id);
            if (playerModel == null)
            {
                return HttpNotFound();
            }
            var playerDetailsViewModel = new PlayerDetailsViewModel();
            playerDetailsViewModel.Player = playerModel;

            var teamMates = repository.getTeamMates(playerModel.ClubId, playerModel.PlayerId);
            playerDetailsViewModel.Players = teamMates.ToList();

            playerDetailsViewModel.Players.ForEach(p => System.Diagnostics.Debug.WriteLine(p.PlayerName));

            System.Diagnostics.Debug.WriteLine(playerDetailsViewModel.Player.PlayerName);

            return View(playerDetailsViewModel);
        }


        // GET: Player/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.ClubId = new SelectList(repository.GetClubModels(), "ClubId", "ClubName");
            ViewBag.PositionId = new SelectList(repository.GetPositionModels(), "PositionId", "PositionName");
            return View();
        }

        // POST: Player/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlayerId,PlayerName,PlayerPic,ClubId,PositionId")] PlayerModel playerModel)
        {
            if (ModelState.IsValid)
            {
                //Here we can use the generic repository
                genericRepo.Insert(playerModel);
                genericRepo.Save();
                return RedirectToAction("Index");
            }

            ViewBag.ClubId = new SelectList(repository.GetClubModels(), "ClubId", "ClubName", playerModel.ClubId);
            ViewBag.PositionId = new SelectList(repository.GetPositionModels(), "PositionId", "PositionName", playerModel.PositionId);
            return View(playerModel);
        }


        // GET: Player/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerModel playerModel = repository.SelectByID(id);
            if (playerModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClubId = new SelectList(repository.GetClubModels(), "ClubId", "ClubName", playerModel.ClubId);
            ViewBag.PositionId = new SelectList(repository.GetPositionModels(), "PositionId", "PositionName", playerModel.PositionId);
            return View(playerModel);
        }


        // POST: Player/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlayerId,PlayerName,PlayerPic,ClubId,PositionId")] PlayerModel playerModel)
        {
            if (ModelState.IsValid)
            {
                genericRepo.Update(playerModel);
                //db.Entry(playerModel).State = EntityState.Modified;
                genericRepo.Save();
                return RedirectToAction("Index");
            }
            ViewBag.ClubId = new SelectList(repository.GetClubModels(), "ClubId", "ClubName", playerModel.ClubId);
            ViewBag.PositionId = new SelectList(repository.GetPositionModels(), "PositionId", "PositionName", playerModel.PositionId);
            return View(playerModel);
        }


        // GET: Player/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlayerModel playerModel = repository.SelectByID(id);
            if (playerModel == null)
            {
                return HttpNotFound();
            }
            return View(playerModel);
        }


        // POST: Player/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            genericRepo.Delete(id);
            genericRepo.Save();
            return RedirectToAction("Index");
        }


        
        
    }
}
