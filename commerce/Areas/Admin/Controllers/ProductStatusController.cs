using System;
using System.Net;
using System.Web.Mvc;
using commerce.Core.Models;
using commerce.Repositories;

namespace commerce.Areas.Admin.Controllers
{
    public class ProductStatusController : Controller
    {
        private readonly UnitOfWork _db;

        public ProductStatusController()
        {
            this._db = new UnitOfWork(new ApplicationDbContext());
        }

        // GET: ProductStatus
        public ActionResult Index()
        {
            return View(_db.ProductStatuses.GetAll(x => x.IsDeleted == false));
        }

        // GET: ProductStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductStatus productStatus = _db.ProductStatuses.Get(id);
            if (productStatus == null)
            {
                return HttpNotFound();
            }
            return View(productStatus);
        }

        // GET: ProductStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] ProductStatus productStatus)
        {
            if (ModelState.IsValid)
            {
                productStatus.CreatedBy = User.Identity.Name;
                productStatus.CreationTime = DateTime.Now;
                productStatus.IsDeleted = false;
                _db.ProductStatuses.Add(productStatus);
                _db.Save();
                return RedirectToAction("Index");
            }

            return View(productStatus);
        }

        // GET: ProductStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductStatus productStatus = _db.ProductStatuses.Get(id);
            if (productStatus == null)
            {
                return HttpNotFound();
            }
            return View(productStatus);
        }

        // POST: ProductStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductStatusId,Name,CreatedBy,CreationTime")] ProductStatus productStatus)
        {
            if (ModelState.IsValid)
            {
                var productStatusEdited = _db.ProductStatuses.Get(productStatus.ProductStatusId);
                productStatusEdited.Name = productStatus.Name;
                productStatusEdited.ProductStatusId = productStatus.ProductStatusId;
                productStatusEdited.CreatedBy = productStatus.CreatedBy;
                productStatusEdited.CreationTime = productStatus.CreationTime;
                productStatusEdited.IsDeleted = false;
                productStatusEdited.UpdatedBy = User.Identity.Name;
                productStatusEdited.UpdatedTime = DateTime.Now;
                _db.Save();
                return RedirectToAction("Index");
            }
            return View(productStatus);
        }

        // GET: ProductStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductStatus productStatus = _db.ProductStatuses.Get(id);
            if (productStatus == null)
            {
                return HttpNotFound();
            }
            return View(productStatus);
        }

        // POST: ProductStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductStatus productStatus = _db.ProductStatuses.Get(id);
            productStatus.UpdatedBy = User.Identity.Name;
            productStatus.UpdatedTime = DateTime.Now;
            productStatus.IsDeleted = true;
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
