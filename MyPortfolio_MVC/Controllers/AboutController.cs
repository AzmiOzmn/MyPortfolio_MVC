using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class AboutController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index(TblAdmin model)
        {
            var values = db.TblAbouts.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAbout(TblAbout p1, HttpPostedFileBase CVFile, HttpPostedFileBase ImageFile)
        {
            if (CVFile != null && CVFile.ContentLength > 0)
            {
                string cvDirectory = Server.MapPath("/files/");
                if (!Directory.Exists(cvDirectory)) Directory.CreateDirectory(cvDirectory);

                string cvPath = "/files/" + Path.GetFileName(CVFile.FileName);
                CVFile.SaveAs(Path.Combine(cvDirectory, Path.GetFileName(CVFile.FileName)));
                p1.CvUrl = cvPath;
            }


            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                string imageDirectory = Server.MapPath("/images/");
                if (!Directory.Exists(imageDirectory)) Directory.CreateDirectory(imageDirectory);

                string imagePath = "/images/" + Path.GetFileName(ImageFile.FileName);
                ImageFile.SaveAs(Path.Combine(imageDirectory, Path.GetFileName(ImageFile.FileName)));
                p1.ImageUrl = imagePath;
            }


            if (ModelState.IsValid)
            {
                db.TblAbouts.Add(p1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(p1);
        }


        public ActionResult DeleteAbout(int id)
        {
            var value = db.TblAbouts.Find(id);
            db.TblAbouts.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = db.TblAbouts.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateAbout(TblAbout model, HttpPostedFileBase ImageFile, HttpPostedFileBase CVFile)
        {

            var value = db.TblAbouts.Find(model.AboutId);
            if (value == null)
            {
                return HttpNotFound("Güncellenecek kayıt bulunamadı.");
            }


            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                string imagePath = "/images/" + Path.GetFileName(ImageFile.FileName);
                ImageFile.SaveAs(Server.MapPath(imagePath));
                value.ImageUrl = imagePath;
            }


            if (CVFile != null && CVFile.ContentLength > 0)
            {

                string cvDirectory = Server.MapPath("/files/");
                if (!Directory.Exists(cvDirectory))
                {
                    Directory.CreateDirectory(cvDirectory);
                }

                string cvPath = "/files/" + Path.GetFileName(CVFile.FileName);
                CVFile.SaveAs(Path.Combine(cvDirectory, Path.GetFileName(CVFile.FileName)));
                value.CvUrl = cvPath;
            }


            value.Title = model.Title;
            value.Description = model.Description;


            db.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}