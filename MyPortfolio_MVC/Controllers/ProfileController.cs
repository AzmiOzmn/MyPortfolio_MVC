using MyPortfolio_MVC.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class ProfileController : Controller
    {
       

        MyPortfolioDbEntities db = new MyPortfolioDbEntities();

        [HttpGet]
        public ActionResult Index()
        {
            string email = Session["email"].ToString();
            if (string.IsNullOrEmpty(email))
            {
                return RedirectToAction("Index","Login");
            }
            var admin = db.TblAdmins.FirstOrDefault(x => x.Email == email);
            return View(admin);
        }

        [HttpPost]

        public ActionResult Index(TblAdmin model)
        {


            string email = Session["email"].ToString();
            var admin = db.TblAdmins.FirstOrDefault(x => x.Email == email);
            if (admin.Password == model.Password) 
            {
                if (model.ImageFile != null)
                {
                    var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    var saveLocation = currentDirectory + "images\\";
                    var fileName = Path.Combine(saveLocation, model.ImageFile.FileName);
                    model.ImageFile.SaveAs(fileName);
                    admin.ImageUrl = "/images/" + model.ImageFile.FileName;
                }
                admin.Name = model.Name;
                admin.Surname = model.Surname;
                admin.Email = model.Email;
                db.SaveChanges();
                Session.Abandon();
                return RedirectToAction("Index", "Login");
            }

            ModelState.AddModelError("", "Girdiğiniz Şifre Hatalı");
            return View(model); 
            
            

        }
    }
}