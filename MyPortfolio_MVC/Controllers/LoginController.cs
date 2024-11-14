using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyPortfolio_MVC.Controllers
{
    public class LoginController : Controller
    {

        MyPortfolioDbEntities db= new MyPortfolioDbEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin model) 
        {
            var value = db.TblAdmins.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            if (value == null)
            {
                ModelState.AddModelError("", "Email veya Şifre hatalı");
                return View(model);
            }

            FormsAuthentication.SetAuthCookie(value.Email,false);
            Session["nameSurname"]=value.Name+" "+value.Surname;
            return RedirectToAction("Index","Category");
            
        }
    }
}