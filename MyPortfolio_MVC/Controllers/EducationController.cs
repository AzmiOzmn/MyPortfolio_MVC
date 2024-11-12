using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class EducationController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var educations = db.TblEducations.ToList();
            return View(educations);
        }

        public ActionResult DeleteEducation(int id)
        {
            var value = db.TblEducations.Find(id);
            db.TblEducations.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        [HttpGet]

        public ActionResult CreateEducation() 
        {
            return View();
        }

        [HttpPost]

        public ActionResult CreateEducation(TblEducation model)
        {
            db.TblEducations.Add(model);
            db.SaveChanges(); 
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]

        public ActionResult UpdateEducation(int id )
        {
            var education = db.TblEducations.Find(id);
            return View(education);
        }

        [HttpPost]
        public ActionResult UpdateEducation(TblEducation model)
        {
            var value = db.TblEducations.Find(model.EducationId);
            value.SchoolName = model.SchoolName;
            value.Description = model.Description;
            value.StartDate = model.StartDate;
            value.EndDate = model.EndDate;
            value.Degree = model.Degree;
            value.Departman = model.Departman;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}