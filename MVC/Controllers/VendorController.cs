using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
namespace MVC.Controllers
{
    public class VendorController : Controller
    {
        DbHandlerDataContext db = new DbHandlerDataContext();

        // GET: Vendor
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [ActionName("vendorSignUp")]
        public ActionResult VendorSignUp()
        {
            return View();
        }

        [HttpPost]
        [ActionName("vendorSignUp")]
        public ActionResult VendorSignUp_post(Vendor v, HttpPostedFileBase VendorImg)
        {

            if (ModelState.IsValid == true)
            {
                Vendor u = db.Vendors.Where(x => x.VEmail == v.VEmail).FirstOrDefault();
                if (u != null)
                {
                    ModelState.AddModelError("", "Email already exists");
                    return View();

                }
                else
                {
                    byte[] img = new byte[VendorImg.ContentLength];
                    VendorImg.InputStream.Read(img, 0, VendorImg.ContentLength);
                    v.VImage = new System.Data.Linq.Binary(img);

                    db.Vendors.InsertOnSubmit(v);
                  
                    db.SubmitChanges();
                    ModelState.Clear();
                    return RedirectToAction("MainPage", "Home");
                }
            }

            else
                return View();



        }

    }
}