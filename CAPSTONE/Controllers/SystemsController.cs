using CAPSTONE.Controllers.Repository;
using CAPSTONE.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Web.UI.WebControls;

namespace CAPSTONE.Controllers
{
    public class SystemsController : Controller
    {
        // GET: Systems
        public ActionResult Index(string id)
        {
            UserControl userControl = new UserControl();

            SystemsRepository systemsRepository = new SystemsRepository();


            userControl.currentuser = systemsRepository.GetCurrentUser(id);
            
            if (userControl.currentuser.acnttype == "" || userControl.currentuser.acnttype == null) return RedirectToAction("Index", "Login");
            
            userControl.menulist = systemsRepository.GetMenu(userControl.currentuser.acnttype);

            return View(userControl);
        }

        public ActionResult Reports(string id) {
            UserControl userControl = new UserControl();

            SystemsRepository systemsRepository = new SystemsRepository();


            userControl.currentuser = systemsRepository.GetCurrentUser(id);

            if (userControl.currentuser.acnttype == "" || userControl.currentuser.acnttype == null) return RedirectToAction("Index", "Login");

            userControl.menulist = systemsRepository.GetMenu(userControl.currentuser.acnttype);

            return View(userControl);
        }

        public ActionResult Statics(string id)
        {
            UserControl userControl = new UserControl();

            SystemsRepository systemsRepository = new SystemsRepository();


            userControl.currentuser = systemsRepository.GetCurrentUser(id);

            if (userControl.currentuser.acnttype == "" || userControl.currentuser.acnttype == null) return RedirectToAction("Index", "Login");

            userControl.menulist = systemsRepository.GetMenu(userControl.currentuser.acnttype);

            return View(userControl);
        }

        public ActionResult Daily(string id)
        {
            UserControl userControl = new UserControl();

            SystemsRepository systemsRepository = new SystemsRepository();


            userControl.currentuser = systemsRepository.GetCurrentUser(id);

            if (userControl.currentuser.acnttype == "" || userControl.currentuser.acnttype == null) return RedirectToAction("Index", "Login");

            userControl.menulist = systemsRepository.GetMenu(userControl.currentuser.acnttype);

            return View(userControl);
        }
        public ActionResult ConfiscatedLicense(string id)
        {
            UserControl userControl = new UserControl();

            SystemsRepository systemsRepository = new SystemsRepository();


            userControl.currentuser = systemsRepository.GetCurrentUser(id);

            if (userControl.currentuser.acnttype == "" || userControl.currentuser.acnttype == null) return RedirectToAction("Index", "Login");

            userControl.menulist = systemsRepository.GetMenu(userControl.currentuser.acnttype);

            return View(userControl);
        }

        public ActionResult ImpoundedVehicles(string id)
        {
            UserControl userControl = new UserControl();

            SystemsRepository systemsRepository = new SystemsRepository();


            userControl.currentuser = systemsRepository.GetCurrentUser(id);

            if (userControl.currentuser.acnttype == "" || userControl.currentuser.acnttype == null) return RedirectToAction("Index", "Login");

            userControl.menulist = systemsRepository.GetMenu(userControl.currentuser.acnttype);

            return View(userControl);
        }
        public ActionResult SettledApprehensions(string id)
        {
            UserControl userControl = new UserControl();

            SystemsRepository systemsRepository = new SystemsRepository();


            userControl.currentuser = systemsRepository.GetCurrentUser(id);

            if (userControl.currentuser.acnttype == "" || userControl.currentuser.acnttype == null) return RedirectToAction("Index", "Login");

            userControl.menulist = systemsRepository.GetMenu(userControl.currentuser.acnttype);

            return View(userControl);
        }
        public ActionResult EnforcerAccounts(string id)
        {
            UserControl userControl = new UserControl();

            SystemsRepository systemsRepository = new SystemsRepository();


            userControl.currentuser = systemsRepository.GetCurrentUser(id);

            if (userControl.currentuser.acnttype == "" || userControl.currentuser.acnttype == null) return RedirectToAction("Index", "Login");

            userControl.menulist = systemsRepository.GetMenu(userControl.currentuser.acnttype);

            return View(userControl);
        }
        public ActionResult About(string id)
        {
            UserControl userControl = new UserControl();

            SystemsRepository systemsRepository = new SystemsRepository();


            userControl.currentuser = systemsRepository.GetCurrentUser(id);

            if (userControl.currentuser.acnttype == "" || userControl.currentuser.acnttype == null) return RedirectToAction("Index", "Login");

            userControl.menulist = systemsRepository.GetMenu(userControl.currentuser.acnttype);

            return View(userControl);
        }
        public ActionResult PDALocation(string id)
        {
            UserControl userControl = new UserControl();

            SystemsRepository systemsRepository = new SystemsRepository();


            userControl.currentuser = systemsRepository.GetCurrentUser(id);

            if (userControl.currentuser.acnttype == "" || userControl.currentuser.acnttype == null) return RedirectToAction("Index", "Login");

            userControl.menulist = systemsRepository.GetMenu(userControl.currentuser.acnttype);

            return View(userControl);
        }
        public ActionResult Dashboard(string id)
        {
            UserControl userControl = new UserControl();

            SystemsRepository systemsRepository = new SystemsRepository();


            userControl.currentuser = systemsRepository.GetCurrentUser(id);

            if (userControl.currentuser.acnttype == "" || userControl.currentuser.acnttype == null) return RedirectToAction("Index", "Login");

            userControl.menulist = systemsRepository.GetMenu(userControl.currentuser.acnttype);

            return View(userControl);
        }

        public ActionResult Apprehension_Report(string id)
        {
            UserControl userControl = new UserControl();

            SystemsRepository systemsRepository = new SystemsRepository();


            userControl.currentuser = systemsRepository.GetCurrentUser(id);

            if (userControl.currentuser.acnttype == "" || userControl.currentuser.acnttype == null) return RedirectToAction("Index", "Login");

            userControl.menulist = systemsRepository.GetMenu(userControl.currentuser.acnttype);

            return View(userControl);
        }

        public ActionResult Enforcer_Apprehension_Report(string id)
        {
            UserControl userControl = new UserControl();

            SystemsRepository systemsRepository = new SystemsRepository();


            userControl.currentuser = systemsRepository.GetCurrentUser(id);

            if (userControl.currentuser.acnttype == "" || userControl.currentuser.acnttype == null) return RedirectToAction("Index", "Login");

            userControl.menulist = systemsRepository.GetMenu(userControl.currentuser.acnttype);

            return View(userControl);
        }

        public ActionResult Enforcer_Fines_of_Violation(string id)
        {
            UserControl userControl = new UserControl();

            SystemsRepository systemsRepository = new SystemsRepository();


            userControl.currentuser = systemsRepository.GetCurrentUser(id);

            if (userControl.currentuser.acnttype == "" || userControl.currentuser.acnttype == null) return RedirectToAction("Index", "Login");

            userControl.menulist = systemsRepository.GetMenu(userControl.currentuser.acnttype);

            return View(userControl);
        }
        public string insert_citation(
            string fname,
            string address,
            string licneseno,
            string birthdate,
            string dateofapprehension,
            string placeofviolation,
            string violationid,
            string vehicletype,
            string classification,
            string plateno
        )
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.insert_citation(
                fname,
                address,
                licneseno,
                birthdate,
                dateofapprehension,
                placeofviolation,
                violationid,
                vehicletype,
                classification,
                plateno
                );
        }

        public string LoginUser(string username, string password, string acnttype)
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.LoginUser(username, password, acnttype);
        }
        public string getreport()
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.getreport();
        }
        public string getdailyreport()
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.getdailyreport();
        }
        public string get_total()
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.get_total();
        }
        public string get_total_today()
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.get_total_today();
        }
        public string get_violation()
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.get_violation();
        }
        public string insert_ticketcitation(
            int tid,
            string fname,
            string address,
            string licenseno,
            string vehicletype,
            string placeofviolation,
            int violationid
            )
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.insert_ticketcitation(tid, fname, address, licenseno, vehicletype, placeofviolation, violationid);
        }
        public string insert_account(
           string fname,
           string mname,
           string lname,
           string username,
           string password,
           string acnttype
        )
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.insert_account(fname, mname, lname, username, password, acnttype);
        }
        public string delete_citation(string id)
        {
            SystemsRepository systemsRepository =new SystemsRepository();
            return systemsRepository.delete_citation(id);
        }
        public string getuserfullname(string acntuid)
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.GetUserFullName(acntuid);
        }
        public string get_statistics()
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.proc_get_statistics();
        }
        public string prop_get_confiscated_license()
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.prop_get_confiscated_license();
        }
        public string proc_get_setteled_apprehensions()
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.proc_get_setteled_apprehensions();
        }
        public string proc_clear_citation(
            string tid,
            string clearedby
        )
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.proc_clear_citation(
                tid,clearedby
            );
        }
        public string proc_get_all_enforcer_account()
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.proc_get_all_enforcer_account();
        }
        public string proc_update_account(
            string acntid,
            string fname,
            string mname,
            string lname,
            string username,
            string password

        )
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.proc_update_account(acntid, fname, mname, lname, username, password);
        }
        public string prop_get_record_by_plateno(string platenumber)
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.prop_get_record_by_plateno(platenumber);
        }
        public string prop_get_compound()
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.prop_get_compound();
        }
        public string proc_get_monthly_report()
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.proc_get_monthly_report();
        }
        public string proc_get_weekly_report()
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.proc_get_weekly_report();
        }
        public string proc_get_daily_report()
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.proc_get_daily_report();
        }
        public string proc_update_user_location(string uid, string lat, string longi)
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.proc_update_user_location(uid, lat, longi);
        }
        public string proc_get_pda_location()
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.proc_get_pda_location();
        }
        public string proc_update_confiscated_clerk(
            string name,
            string licenseno,
            string dateofapprehension,
            string platenumber,
            string violationid,
            string editid
        )
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.proc_update_confiscated_clerk(name,licenseno,dateofapprehension,platenumber,violationid,editid);
        }
        public string proc_update_impounded_vehicle(
            string name,
            string dateofapprehension,
            string vehicle,
            string violationid,
            string editid
        )
        {
            SystemsRepository systemsRepository = new SystemsRepository();
            return systemsRepository.proc_update_impounded_vehicle(name, dateofapprehension, vehicle, violationid, editid);
        }
    }
}