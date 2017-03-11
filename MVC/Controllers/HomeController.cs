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
            UpdateModel(user);
            Models.User u = new User();
            u = user;
            Models.User.InsertUser(u);

           return RedirectToAction("DisplayDetails");
        }

        public ActionResult DisplayDetails() {

            User u = new User();
            u=user;
            return View(u);
        }
        public ActionResult MainPage()
        {


            return View();
        }

        [HttpGet]
        [ActionName("vendorSignUp")]
        public ActionResult vendorSignUp() {


            return View();
        }
        [HttpPost]
        [ActionName("vendorSignUp")]
        public ActionResult vendorSignUp_post()
        {

            UpdateModel(vendor);
            Vendor v = new Vendor();
            Vendor.InsertVendor(vendor);

            return RedirectToAction("DisplayDetailsVendor");
        }

        public ActionResult DisplayDetailsVendor() {

            Vendor v = new Vendor();
            v = vendor;
            return View(v);
        }



    }

}