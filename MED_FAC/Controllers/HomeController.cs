using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MED_FAC.Models;

namespace MED_FAC.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult IndexCustomer()
        {
            return View();
        }
        public ActionResult IndexAdmin()
        {
            return View();
        }
        public ActionResult LoginAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAdmin(tblAdmin a)
        {
            int Result = db.tblAdmins.Where(x => x.ADMIN_EMAIL == a.ADMIN_EMAIL && x.ADMIN_PASSWORD == a.ADMIN_PASSWORD).Count();
            if (Result > 0)
            {
                return RedirectToAction("IndexAdmin");
            }
            else
            {
                ViewBag.message = "Invalid Email or Password";
                return View();
            }
        }

                public ActionResult features()
        {
            return View();
        }
        public ActionResult gallery()
        {
            return View();
        }

        public ActionResult about()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
        }
    }
