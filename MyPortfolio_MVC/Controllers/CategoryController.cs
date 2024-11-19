using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{

    
    public class CategoryController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();

        public ActionResult Index()
        {
            var values = db.TblCategories.ToList();
            return View(values);
        } 

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(TblCategory category)
        {
            db.TblCategories.Add(category);
            db.SaveChanges();
            return RedirectToAction("Index"); 
        }

        public ActionResult DeleteCategory(int id) 
        {
            var value = db.TblCategories.Find(id);
            db.TblCategories.Remove(value); 
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = db.TblCategories.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory (TblCategory model)
        {
            var value = db.TblCategories.Find(model.CategoryId);
            value.Name = model.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}