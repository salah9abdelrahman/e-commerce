using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using commerce.Models;
using commerce.Repositories;

namespace commerce.Controllers
{
    [AllowAnonymous]
    public class ProductsController : Controller
    {
        private UnitOfWork db;

        public ProductsController()
        {
            db = new UnitOfWork(new ApplicationDbContext());
        }

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.GetProductsWithStatus());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            var status = db.ProductStatuses.GetAll();
            ViewBag.ProductStatusId = new SelectList(status, "ProductStatusId", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Name,Description,RegularPrice,DiscountPrice,Quantity,ProductStatusId,IsDeleted,CreatedBy,UpdatedBy,CreationTime,UpdatedTime")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.Save();
                return RedirectToAction("Index");
            }

            ViewBag.ProductStatusId = new SelectList(db.ProductStatuses.GetAll(), "ProductStatusId", "Name", product.ProductStatusId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductStatusId = new SelectList(db.ProductStatuses.GetAll(), "ProductStatusId", "Name", product.ProductStatusId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Name,Description,RegularPrice,DiscountPrice,Quantity,ProductStatusId,IsDeleted,CreatedBy,UpdatedBy,CreationTime,UpdatedTime")] Product product)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(product).State = EntityState.Modified;

                db.Save();
                return RedirectToAction("Index");
            }
            ViewBag.ProductStatusId = new SelectList(db.ProductStatuses.GetAll(), "ProductStatusId", "Name", product.ProductStatusId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Get(id);
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
            Product product = db.Products.Get(id);
            db.Products.Remove(product);
            db.Save();
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
