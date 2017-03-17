using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{ //check

    public class HomeController : Controller
    {
        static Models.User user = new User();
        static Models.Vendor vendor = new Vendor();
        static Login Login = new Login();


        [HttpGet]
        [ActionName("SignUp")]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ActionName("SignUp")]
        public ActionResult SignUp_post()
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction("SignUp");
            }

            if (!TryUpdateModel(user))
            {
                return RedirectToAction("SignUp");
            }

            Models.User u = new User();
            u = user;
            Boolean check = Models.User.InsertUser(u);

            if (check)
                return RedirectToAction("DisplayDetails");
            else
            {
                ViewBag.Message = "The email already exist.Please enter another email";
                return View();
            }
        }

        public ActionResult DisplayDetails()
        {
            User u = new User();
            u = user;
            return View(u);
        }

        public ActionResult MainPage()
        {
            return View();
        }

        [HttpGet]
        [ActionName("vendorSignUp")]
        public ActionResult vendorSignUp()
        {
            return View();
        }

        [HttpPost]
        [ActionName("vendorSignUp")]
        public ActionResult vendorSignUp_post()
        {
            UpdateModel(vendor);
            Vendor v = new Vendor();
            bool check = Vendor.InsertVendor(vendor);
            if (check)
            {
                return RedirectToAction("DisplayDetailsVendor");
            }
            else
            {
                ViewBag.Message = "The email already exists";
                return View();
            }
        }

        public ActionResult DisplayDetailsVendor()
        {
            Vendor v = new Vendor();
            v = vendor;
            return View(v);
        }

        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Login")]
        public ActionResult Login_post()
        {
            if (ModelState.IsValid == false)
            {
                return RedirectToAction("Login");
            }

            if (!TryUpdateModel(Login))
            {
                return RedirectToAction("Login");
            }

            Models.Login l = new Login();
            l = Login;
            Boolean check = Models.Login.CheckLogin(l);

            if (check)
                return RedirectToAction("MainPage");
            else
            {
                ViewBag.Message = "The username or password is incorrect! Please try again";
                return View();
            }
        }
        public ActionResult Edit()
        {
            throw new NotImplementedException();
        }

        public ActionResult Index()
        {
            throw new NotImplementedException();
        }
    }
}