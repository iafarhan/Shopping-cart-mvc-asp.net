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
                    v.VImage = new byte[VendorImg.ContentLength];
                    VendorImg.InputStream.Read(v.VImage.ToArray(), 0, VendorImg.ContentLength);
                    db.Vendors.InsertOnSubmit(v);
                  
                    db.SubmitChanges();
                    return RedirectToAction("Index", "Products");
                }
            }

            else
                return View();



        }

    }
}