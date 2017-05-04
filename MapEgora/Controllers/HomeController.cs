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
        public ActionResult AddRoute(HttpPostedFileBase uploadImage,HttpPostedFileBase uploadKML,IEnumerable<HttpPostedFileBase> ffile)
        {
            if ((uploadImage != null)&&(uploadKML!=null))
            {
                // получаем имя файла
                string fileNameImage = System.IO.Path.GetFileName(uploadImage.FileName);
                string fileNameKML = System.IO.Path.GetFileName(uploadKML.FileName);

                string strName = Request.Form.Get("Name");
                string strDescription = Request.Form.Get("Description");
                int arrPhoto = Request.Files.Count;
                string urlimg = String.Format("{0}_{1}{2}", DateTime.Now.ToString("yyyyMMddHHmmssfff"), Guid.NewGuid(), Path.GetExtension(fileNameImage));
                string urlkml = String.Format("{0}_{1}{2}", DateTime.Now.ToString("yyyyMMddHHmmssfff"), Guid.NewGuid(), Path.GetExtension(fileNameKML));
                Route route = new Route();
                route.Name = strName;
                route.Description = strDescription;
                route.RouteImage = urlimg;
                route.RouteKML = urlkml;
                try
                {
                    // сохраняем файл в папку Files в проекте
                    uploadImage.SaveAs(Server.MapPath("~/Files/Img/" + urlimg));
                    uploadKML.SaveAs(Server.MapPath("~/Files/Kml/" + urlkml));
                    
                    if (ffile != null)
                    {
                        foreach (HttpPostedFileBase f in ffile)
                        {
                            string photoNameImage = System.IO.Path.GetFileName(f.FileName);
                            string urlphoto = String.Format("{0}_{1}{2}", DateTime.Now.ToString("yyyyMMddHHmmssfff"), Guid.NewGuid(), Path.GetExtension(photoNameImage));
                            Photo photo = new Photo();
                            photo.PhotoName = urlphoto;
                            photo.Photocreated = DateTime.Now;
                            photo.Description = photoNameImage;
                route.Photos.Add(photo);
                            f.SaveAs(Server.MapPath("~/Files/Photo/" + urlphoto));
                        }
                    }

                    db.Entry(route).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    
                }
                catch(Exception e)
                {

                }



            }
            return RedirectToAction("Routes");
        }

        

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}