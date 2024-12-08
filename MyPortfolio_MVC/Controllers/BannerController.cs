using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class BannerController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var values = db.TblBanners.ToList();
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateShowStatus(int id, bool isShow)
        {
            var banner = db.TblBanners.Find(id);
            if (banner != null)
            {
                banner.IsShow = isShow;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateBanner()
        {
            // DropDown list için seçenekler (true ve false)
            ViewBag.IsShowList = new List<SelectListItem>
    {
        new SelectListItem { Text = "Göster", Value = "true" },
        new SelectListItem { Text = "Gösterme", Value = "false" }
    };

            return View();
        }

        [HttpPost]
        public ActionResult CreateBanner(TblBanner model)
        {
            // Eğer değer null ise, varsayılan olarak false atanır
            if (model.IsShow == null)
            {
                model.IsShow = false;
            }

            if (ModelState.IsValid)
            {
                db.TblBanners.Add(model); // Veriyi kaydet
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult DeleteBanner(int id)
        {
            var value = db.TblBanners.Find(id);
            db.TblBanners.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateBanner(int id)
        {
            var value = db.TblBanners.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateBanner(TblBanner model)
        {
            var value = db.TblBanners.Find(model.BannerId);
            value.Title = model.Title;
            value.Description = model.Description;
            value.IsShow = model.IsShow;

            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }


}









