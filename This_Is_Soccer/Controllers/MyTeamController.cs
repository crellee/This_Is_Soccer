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
            /*
                        var players = from m in db.MyTeamModels select m;


                            players = players.Where(s => s.Id.Contains(UserId));

                        //var myTeam = db.MyTeamModels.Include(m => m.PositionId).ToList();
                        //var query = db.MyTeamModels.Include(m => m.Id).Include(m => m.PositionId).Include(m => m.PlayerId);
                        //MyTeamModel myTeamModel = db.MyTeamModels.Find(UserId);
                        return View(players);
                        //string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                        //System.Diagnostics.Debug.WriteLine(UserId);
                        */



            var myTeamModels = db.MyTeamModels.Include(m => m.Player).Where(m => m.Id.Contains(UserId));
            var listen = myTeamModels.ToList();
            System.Diagnostics.Debug.WriteLine(listen.Count().ToString());
            System.Diagnostics.Debug.WriteLine("Kig ovenover");

            List<MyTeamModel> classList = db.MyTeamModels.Include(m => m.Player).Where(m => m.Id.Contains(UserId)).ToList();
            int count = classList.Count();
            System.Diagnostics.Debug.WriteLine(count);

            return View(myTeamModels.ToList());
        }
        public ActionResult RemovePlayer(int? id)
        {
            //MyTeamModel myTeamModel = db.MyTeamModels.Find(id);
            MyTeamModel teamModels = db.MyTeamModels.SingleOrDefault(m => m.PlayerId == id);
            db.MyTeamModels.Remove(teamModels);
            db.SaveChanges();
            return RedirectToAction("index");
        }
    }
}