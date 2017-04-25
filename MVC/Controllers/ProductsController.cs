using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
namespace MVC.Controllers
{
    public class ProductsController : Controller
    {
        DbHandlerDataContext db = new DbHandlerDataContext();

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

                product.PImage = new byte[image1.ContentLength];
                image1.InputStream.Read(product.PImage, 0, image1.ContentLength);

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
                p.PImage = new byte[newImage.ContentLength];
                newImage.InputStream.Read(p.PImage, 0, newImage.ContentLength);
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
