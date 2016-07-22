using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TokuCinema.Controllers
{
    [Authorize] /*Must be logged in to view - no role specified*/
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }
        
    }
}