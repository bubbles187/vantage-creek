using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VantageCreekApartment2.Models;

namespace VantageCreekApartment2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Floorplans()
        {
            return View();
        }
        public ActionResult Gallery()
        {
            return View();
        }
        public ActionResult Amenities()
        {
            return View();
        }
        public ActionResult Resident()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Resident(Account entry)
        {
            if (string.IsNullOrEmpty(entry.Email))
            {
                ModelState.AddModelError("Email", "Email is required");
            }
            if (string.IsNullOrEmpty(entry.Password))
            {
                ModelState.AddModelError("Password", "Password is required");
            }
            if (ModelState.IsValid)
            {
                Registration newRegistration = new Registration();
                newRegistration.Accounts.Add(entry);
                newRegistration.SaveChanges();
                ModelState.Clear();
                return View("AccountCreated");
            }
            else
            {
                return View();
            }

        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account objUser)
        {
            if (string.IsNullOrEmpty(objUser.Email))
            {
                ModelState.AddModelError("Email", "Email is required");
            }
            if (string.IsNullOrEmpty(objUser.Password))
            {
                ModelState.AddModelError("Password", "Password is required");
            }
            if (ModelState.IsValid)
            {
                using (Registration newRegistration = new Registration())
                {
                    var obj = newRegistration.Accounts.Where(a => a.Email.Equals(objUser.Email) && a.Password.Equals(objUser.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserId"] = obj.UserID.ToString();
                        Session["Email"] = obj.Email.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(objUser);
        }
        public ActionResult UserDashBoard()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Forgot()
        {
            return View();
        }
        public ActionResult Apply()
        {
            return View();
        }
        public ActionResult AccountCreated()
        {
            return View();
        }

        public ActionResult ContactSub()
        {
            return View();
        }
    }
}