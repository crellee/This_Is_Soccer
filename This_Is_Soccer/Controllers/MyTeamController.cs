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
    [Authorize]
    public class MyTeamController : Controller
    {
        private MyTeamRepository repository = new MyTeamRepository();

        // GET: MyTeam
        public ActionResult Index()
        {
            var myTeamArray = repository.GetMyTeam();
            return View(myTeamArray);
        }
        public ActionResult RemovePlayer(int id)
        {
            repository.RemovePlayer(id);
            return RedirectToAction("index");
        }
        
        public ActionResult setPlayersAtPosition(int? id)
        {
            repository.SetPlayersToAdd(id);
            return RedirectToAction("Index");

        }

        public IEnumerable<PlayerModel> getPlayersAtPosition()
        {
            var players = repository.GetPlayersToAdd();
            return players;
        }
        public ActionResult addPlayerToMyTeam(int id)
        {
            repository.AddPlayer(id);
            return RedirectToAction("Index");
        }
        
    }
}