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
    public class ProductsController : Controller
    {
        private readonly UnitOfWork _db;

        public ProductsController()
        {
            _db = new UnitOfWork(new ApplicationDbContext());
        }

        // GET: Products
        public ActionResult Index()
        {
            var products = _db.Products.GetProductsWithStatus();
            return User.IsInRole(Roles.CanMangeProducts) ? View(_db.Products.GetProductsWithStatus())
                : View("ReadOnly", _db.Products.GetProductsWithStatus());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.Products.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = Roles.CanMangeProducts)]
        public ActionResult Create()
        {
            var status = _db.ProductStatuses.GetAll();
            ViewBag.ProductStatusId = new SelectList(status, "ProductStatusId", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = @"ProductId,Name,Description,RegularPrice,DiscountPrice,Quantity,
                        ProductStatusId,CreatedBy")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.IsDeleted = false;
                product.CreationTime = DateTime.Now;
                product.CreatedBy = User.Identity.Name;
                _db.Products.Add(product);
                _db.Save();
                return RedirectToAction("Index");
            }

            ViewBag.ProductStatusId = new SelectList(_db.ProductStatuses.GetAll(), "ProductStatusId", "Name", product.ProductStatusId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.Products.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductStatusId = new SelectList(_db.ProductStatuses.GetAll(),
                "ProductStatusId", "Name", product.ProductStatusId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = @"ProductId,Name,Description,RegularPrice,DiscountPrice,Quantity,
                            ProductStatusId,IsDeleted,CreatedBy,UpdatedBy,CreationTime,UpdatedTime")] Product product)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(product).State = EntityState.Modified;

                _db.Save();
                return RedirectToAction("Index");
            }
            ViewBag.ProductStatusId = new SelectList(_db.ProductStatuses.GetAll(), "ProductStatusId", "Name", product.ProductStatusId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.Products.Get(id);
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
            Product product = _db.Products.Get(id);
            _db.Products.Remove(product);
            _db.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
