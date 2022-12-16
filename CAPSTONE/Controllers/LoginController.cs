using CAPSTONE.Controllers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAPSTONE.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login_Page(string id)
        {
            if(id==""||id==null) return RedirectToAction("Login", "Login");
            if (id == "Enforcer") ViewBag.id = "Traffic Enforcer";
            else ViewBag.id = id;
            return View();
        }
        public ActionResult Register_Page(string id)
        {
            if (id == "" || id == null) return RedirectToAction("Register", "Login");
            if (id == "Traffic") ViewBag.id = "Traffic Enforcer";
            else ViewBag.id = id;
            return View();
        }
       
    }
}