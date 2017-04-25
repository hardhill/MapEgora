using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MapEgora.Models;

namespace MapEgora.Controllers
{
    public class ParticController : Controller
    {
        DbEgoraContext db = new DbEgoraContext();
        // GET: Partic
        public ActionResult Index()
        {
            ViewBag.Partic = db.Participants;
            return View();
        }
    }
}