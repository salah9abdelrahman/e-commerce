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
using commerce.ViewModels;

namespace commerce.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly UnitOfWork _db;

        public CategoriesController()
        {
            this._db = new UnitOfWork(new ApplicationDbContext());
        }

        // GET: Categories
        public ActionResult Index()
        {
            var categories = _db.Categories.GetAll(x => x.IsDeleted == false);
            var categoriesView = new List<CategoryViewModel>();
            foreach (var category in categories)
            {
                var ParentCatId = category.ParentCatId;
                var ParentCat = _db.Categories.Get(ParentCatId);
                categoriesView.Add(new CategoryViewModel
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    UpdatedBy = category.UpdatedBy,
                    CreationTime = category.CreationTime,
                    UpdatedTime = category.UpdatedTime,
                    CreatedBy = category.CreatedBy,
                    ParentCatName = ParentCat == null ? "Empty" : ParentCat.Name,

                });
            }
            return View(categoriesView);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _db.Categories.Get(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            //ViewBag.ParentCatId = new SelectList(_db.Categories.GetAll(x => x.IsDeleted == false),
            //    "CategoryId", "Name");
            var categories = _db.Categories.GetAll(x => x.IsDeleted == false);
            var categoryView = new CreateCategoriesViewModel()
            {
                Categories = categories
            };
            return View(categoryView);
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,ParentCatId,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.IsDeleted = false;
                category.CreationTime = DateTime.Now;
                category.CreatedBy = User.Identity.Name;
                _db.Categories.Add(category);
                _db.Save();
                return RedirectToAction("Index");
            }

            var categoryView = new CreateCategoriesViewModel
            {
                Name = category.Name,
                ParentCatId = category.ParentCatId,
                Categories = _db.Categories.GetAll(x => x.IsDeleted == false)

            };
            return View(categoryView);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _db.Categories.Get(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryId,ParentCatId,Name,IsDeleted,CreatedBy,UpdatedBy,CreationTime,UpdatedTime")] Category category)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(category).State = EntityState.Modified;
                _db.Save();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = _db.Categories.Get(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = _db.Categories.Get(id);
            _db.Categories.Remove(category);
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
