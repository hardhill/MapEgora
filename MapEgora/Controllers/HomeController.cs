using MapEgora.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult AddRoute(HttpPostedFileBase uploadImage,HttpPostedFileBase uploadKML, IEnumerable<HttpPostedFileBase> uploadPhotos)
        {
            if ((uploadImage != null)&&(uploadKML!=null))
            {

                // получаем имя файла
                string fileNameImage = System.IO.Path.GetFileName(uploadImage.FileName);
                string fileNameKML = System.IO.Path.GetFileName(uploadKML.FileName);

                string strName = Request.Form.Get("Name");
                string strDescription = Request.Form.Get("Description");
                string urlimg = String.Format("{0}_{1}{2}", DateTime.Now.ToString("yyyyMMddHHmmssfff"), Guid.NewGuid(), Path.GetExtension(fileNameImage));
                string urlkml = String.Format("{0}_{1}{2}", DateTime.Now.ToString("yyyyMMddHHmmssfff"), Guid.NewGuid(), Path.GetExtension(fileNameKML));
                Route route = new Route();
                route.Name = strName;
                route.Description = strDescription;
                route.RouteImage = urlimg;
                try
                {
                    // сохраняем файл в папку Files в проекте
                    uploadImage.SaveAs(Server.MapPath("~/Files/Img/" + urlimg));
                    uploadKML.SaveAs(Server.MapPath("~/Files/Kml/" + urlkml));
                    db.Routes.Add(route);
                    db.SaveChanges();
                }
                catch(Exception e)
                {

                }
                
            }
            return RedirectToAction("Routes");
        }

        public ActionResult Photos()
        {
            return View();
        }
    }
}