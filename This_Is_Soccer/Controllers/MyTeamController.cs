using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace This_Is_Soccer.Controllers
{
    public class MyTeamController : Controller
    {
        // GET: MyTeam
        public ActionResult Index()
        {
            return View();
        }
    }
}