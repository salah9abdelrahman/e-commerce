using System;
using System.Net;
using System.Web.Mvc;
using commerce.Core.Models;
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
            var products = _db.Products.GetProductsWithStatusWithCategory();
            return User.IsInRole(UserRoles.CanMangeProducts) ? View(_db.Products.GetProductsWithStatusWithCategory())
                : View("ReadOnly", _db.Products.GetProductsWithStatusWithCategory());
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
        [Authorize(Roles = UserRoles.CanMangeProducts)]
        public ActionResult Create()
        {
            var status = _db.ProductStatuses.GetAll(x => x.IsDeleted == false);
            ViewBag.ProductStatusId = new SelectList(status, "ProductStatusId", "Name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = @"ProductId,Name,Description,RegularPrice,DiscountPrice,Quantity,
                        ProductStatusId")] Product product)
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

            ViewBag.ProductStatusId = new SelectList(_db.ProductStatuses.GetAll(x => x.IsDeleted == false),
                "ProductStatusId", "Name", product.ProductStatusId);
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
            ViewBag.ProductStatusId = new SelectList(_db.ProductStatuses.GetAll(x => x.IsDeleted == false),
                "ProductStatusId", "Name", product.ProductStatusId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = @"ProductId,Name,Description,RegularPrice,DiscountPrice,Quantity,
                            ProductStatusId")] Product product)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(product).State = EntityState.Modified;
                var _product = _db.Products.Get(product.ProductId);
                _product.Name = product.Name;
                _product.Description = product.Description;
                _product.ProductStatusId = product.ProductStatusId;
                _product.Quantity = product.Quantity;
                _product.DiscountPrice = product.DiscountPrice;
                _product.RegularPrice = product.RegularPrice;
                _product.IsDeleted = false;
                _product.UpdatedTime = DateTime.Now;
                _product.UpdatedBy = User.Identity.Name;
                //categories
                _db.Save();
                return RedirectToAction("Index");
            }
            ViewBag.ProductStatusId = new SelectList(_db.ProductStatuses.GetAll(x => x.IsDeleted == false),
                "ProductStatusId", "Name", product.ProductStatusId);
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
            product.IsDeleted = true;
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
