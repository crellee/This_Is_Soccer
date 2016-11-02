using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using This_Is_Soccer.Models;
using This_Is_Soccer.Models.Entity;

namespace This_Is_Soccer.Controllers
{
    public class MyTeamController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MyTeam
        public ActionResult Index()
        {
            string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            //var myTeam = db.MyTeamModels.Include(m => m.PositionId).ToList();
            var query = db.MyTeamModels.Where(m => UserId == m.Id).Include(m => m.Id).Include(m => m.PositionId).Include(m => m.PlayerId);
            return View(query);
            //string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            //System.Diagnostics.Debug.WriteLine(UserId);
        }
    }
}