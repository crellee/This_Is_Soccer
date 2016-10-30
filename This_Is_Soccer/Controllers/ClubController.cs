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
        private ClubRepository repository = null;
        private GenericRepository<ClubModel> genRepository = null;

        public ClubController()
        {
            this.repository = new ClubRepository();
            this.genRepository = new GenericRepository<ClubModel>();

        }
        
        ClubController(ClubRepository repository)
        {
            this.repository = repository;
        }


        // GET: Club
        public ActionResult Index()
        {
            var clubModels = repository.SelectAll();
            return View(clubModels);
        }

        // GET: Club/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubModel clubModel = repository.SelectByID(id);
            if (clubModel == null)
            {
                return HttpNotFound();
            }
            return View(clubModel);
        }

        // GET: Club/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(repository.GetCountryModels(), "CountryId", "CountryName");
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
                genRepository.Insert(clubModel);
                genRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(repository.GetCountryModels(), "CountryId", "CountryName", clubModel.CountryId);
            return View(clubModel);
        }

        // GET: Club/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubModel clubModel = repository.SelectByID(id);
            if (clubModel == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(repository.GetCountryModels(), "CountryId", "CountryName", clubModel.CountryId);
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
                genRepository.Update(clubModel);
                genRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(repository.GetCountryModels(), "CountryId", "CountryName", clubModel.CountryId);
            return View(clubModel);
        }

        // GET: Club/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubModel clubModel = repository.SelectByID(id);
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
            genRepository.Delete(id);
            genRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
