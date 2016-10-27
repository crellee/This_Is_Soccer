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

namespace This_Is_Soccer.Controllers
{
    public class CountryController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private IGenericRepository<CountryModel> repository = null;

        public CountryController()
        {
            this.repository = new GenericRepository<CountryModel>();
        }
        
        CountryController(IGenericRepository<CountryModel> repository)
        {
            this.repository = repository;
        }


        // GET: Country
        public ActionResult Index()
        {
            List<CountryModel> model = (List<CountryModel>)repository.SelectAll();
            return View(model);
        }

        // GET: Country/Details/5
        public ActionResult Details(int? id)
        {
            CountryModel existing = repository.SelectByID(id);
            return View(existing);
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
            repository.Insert(countryModel);
            repository.Save();
            return RedirectToAction("Index");
            }
            return View(countryModel);
        }

        // GET: Country/Edit/5
        public ActionResult Edit(int? id)
        {
            CountryModel existing = repository.SelectByID(id);
            return View(existing);
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
                repository.Update(countryModel);
                repository.Save();
                return RedirectToAction("Index");
            }
            return View(countryModel);
        }

        // GET: Country/Delete/5
        public ActionResult Delete(int? id)
        {
            CountryModel existing = repository.SelectByID(id);
            return View(existing);
        }

        // POST: Country/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repository.Delete(id);
            repository.Save();
            return RedirectToAction("Index");
        }

      /*  protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }*/
    }
}
