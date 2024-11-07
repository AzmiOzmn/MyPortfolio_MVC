using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio_MVC.Controllers
{
    public class AdminLayoutController : Controller
    {
        
        public ActionResult Layout()
        {
            return View();
        }

        public PartialViewResult AdminLayoutHead() 
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutSpinner()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutSidebar()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutNavbar()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutFooter()
        {
            return PartialView();
        }

        public PartialViewResult AdminLayoutScripts()
        {
            return PartialView();
        }
    }
}