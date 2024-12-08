using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{

    [AllowAnonymous] // Herkes Buraya Erişebilir .

    public class DefaultController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();

        public ActionResult Index()
        {
            return View();
        }


        public PartialViewResult DefaultBanner()
        {
            var values = db.TblBanners.Where(x => x.IsShow == true).ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultExpertise()
        {
            var values = db.TblExpertises.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultExperience()
        {
            var values = db.TblExperiences.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultEducation()
        {
            var values = db.TblEducations.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultProjects()
        {
            var values = db.TblProjects.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultAbouts()
        {
            var values = db.TblAbouts.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultTestimonials()
        {
            var values = db.TblTestimonials.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public ActionResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult SendMessage(TblMessage model)
        {
            model.IsRead = false;
            db.TblMessages.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public PartialViewResult SocialMedia()
        {
            var values = db.TblSocialMedias.ToList();
            return PartialView(values);
        }

        public PartialViewResult Contacts()
        {
            var values = db.TblContacts.ToList();
            return PartialView(values);
        }

        

    }
}