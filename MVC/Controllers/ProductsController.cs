using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using System.IO;

namespace MVC.Controllers
{
    public class ProductsController : Controller
    {
        DbHandlerDataContext db = new DbHandlerDataContext();

        public ActionResult GetProductImage(int id)
        {
            Product v = db.Products.Where(x => x.Pid == id).FirstOrDefault();
            byte[] b = v.PImage.ToArray();

            MemoryStream ms = new MemoryStream(b);
            return File(ms.ToArray(), "image/jpg");
        }

        public string GetProductVendor(int ?id) {

            Vendor v = db.Vendors.Where(x => x.Vid == (int)id).FirstOrDefault();
            return v.VName;


        }

        // GET: Products
        public ActionResult Index()
        {
            if (Session["VendorId"] == null) { return RedirectToAction("MainPage", "Home"); }
            return View(db.Products.ToList());
        }
        public ActionResult ShowToCustomers() {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Where(x=>x.Pid==id).FirstOrDefault();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            if (Session["VendorName"] != null)
            {
                ViewBag.VendorName = Session["VendorName"].ToString();
                return View();
            }
            else
                return RedirectToAction("MainPage", "Home");

        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase image1)
        {

            if (image1 != null)
            {

                byte[] img = new byte[image1.ContentLength];
                image1.InputStream.Read(img, 0, image1.ContentLength);
                product.PImage = new System.Data.Linq.Binary(img);

                if (ModelState.IsValid)
                {
                    product.VendorId = int.Parse(Session["VendorId"].ToString());
                    db.Products.InsertOnSubmit(product);
                    db.SubmitChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(product);
        }


        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Where(x => x.Pid == id).FirstOrDefault();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, HttpPostedFileBase newImage)
        {

    
                

                if (ModelState.IsValid)
            {
                Product p = db.Products.Where(x => x.Pid == product.Pid).FirstOrDefault();
                p.PName = product.PName;
                p.Quantity = product.Quantity;
                p.Price = product.Price;
                p.Description = product.Description;


                //setting image
                byte[] img = new byte[newImage.ContentLength];
                newImage.InputStream.Read(img, 0, newImage.ContentLength);
                product.PImage = new System.Data.Linq.Binary(img);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Where(x => x.Pid == id).FirstOrDefault();
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Where(x => x.Pid == id).FirstOrDefault();
            db.Products.DeleteOnSubmit(product);
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
