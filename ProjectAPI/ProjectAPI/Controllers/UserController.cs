using ProjectAPI.Context;
using ProjectAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectAPI.Controllers
{
    public class UserController : Controller
    {
        UserContext db = new UserContext();
        // GET: User
        public ActionResult Index()
        {
            using (UserContext db = new UserContext())
            {
                return View(db.users.ToList());
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User newUser)
        {
            if (ModelState.IsValid)
            {
                using (UserContext db = new UserContext())
                {
                    db.users.Add(newUser);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = newUser.FirstName + " Successfully Registered";
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();

        }

        [HttpPost]
        public ActionResult Login(User loginUser)
        {
            using (UserContext db = new UserContext())
            {
                var usr = db.users.Single(user=> user.Email == loginUser.Email && user.Password == loginUser.Password);
                if (usr != null)
                {
                    Session["UserId"] = usr.UserId.ToString();
                    Session["Email"] = usr.Email.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("","Email or Password is incorrect");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
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
    }
}
