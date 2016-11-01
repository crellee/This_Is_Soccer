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
    [Authorize(Roles = "admin")]
    public class PositionController : Controller
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        private IGenericRepository<PositionModel> repository = null;

        public PositionController()
        {
            this.repository = new GenericRepository<PositionModel>();
        }


        PositionController(IGenericRepository<PositionModel> repository)
        {
            this.repository = repository;
        }

        // GET: Position
        public ActionResult Index()
        {
            List<PositionModel> model = (List<PositionModel>)repository.SelectAll();
            return View(model);
        }

        
        // GET: Position/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionModel positionModel = repository.SelectByID(id);
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
                repository.Insert(positionModel);
                repository.Save();
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
            PositionModel positionModel = repository.SelectByID(id);
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
                repository.Update(positionModel);
                repository.Save();
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
            PositionModel positionModel = repository.SelectByID(id);
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
            repository.Delete(id);
            repository.Save();
            return RedirectToAction("Index");
        }

        /*
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
