using MapEgora.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MapEgora.Controllers
{
    public class HomeController : Controller
    {
        DbEgoraContext db = new DbEgoraContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // выдать список маршрутов
        [HttpGet]
        public ActionResult Routes()
        {

            return View(db.Routes);
        }

        // перейти на страницу создания маршрута
        public ActionResult AddRoute()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddRoute(Route route, HttpPostedFileBase uploadImage)
        {
            if (uploadImage != null)
            {
                // получаем имя файла
                string fileName = System.IO.Path.GetFileName(uploadImage.FileName);
                // сохраняем файл в папку Files в проекте
                uploadImage.SaveAs(Server.MapPath("~/Files/Img/" + fileName));
            }
            return RedirectToAction("Routes");
        }
    }
}