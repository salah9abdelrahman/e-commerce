using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using commerce.Core.Models;
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
                var parentCatId = category.ParentCatId;
                var parentCat = _db.Categories.Get(parentCatId);
                categoriesView.Add(new CategoryViewModel
                {
                    CategoryId = category.CategoryId,
                    Name = category.Name,
                    UpdatedBy = category.UpdatedBy,
                    CreationTime = category.CreationTime,
                    UpdatedTime = category.UpdatedTime,
                    CreatedBy = category.CreatedBy,
                    ParentCatName = parentCat == null ? "Empty" : parentCat.Name
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

            //get parent category name
            var catParentName = _db.Categories.Get(category.ParentCatId)?.Name;
            ViewBag.catParent = catParentName ?? "There is no parent category";
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
            var categoryView = new CreateCategoriesViewModel
            {
                Name = category.Name,
                ParentCatId = category.ParentCatId,
                Categories = _db.Categories.GetAll(x => x.IsDeleted == false),
                CategoryId = category.CategoryId,
                CreationTime = category.CreationTime,
                CreatedBy = category.CreatedBy
            };
            var catParentName = _db.Categories.Get(category.ParentCatId)?.Name;
            ViewBag.catParentName = catParentName;
            return View(categoryView);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = @"CategoryId,ParentCatId,Name,CreatedBy,CreationTime,UpdatedTime")]
            CreateCategoriesViewModel categoryView)
        {
            if (ModelState.IsValid)
            {
                var category = _db.Categories.Get(categoryView.CategoryId);
                category.CategoryId = categoryView.CategoryId;
                category.Name = categoryView.Name;
                category.ParentCatId = categoryView.ParentCatId;
                category.CreatedBy = categoryView.CreatedBy;
                category.CreationTime = category.CreationTime;
                category.UpdatedBy = User.Identity.Name;
                category.UpdatedTime = DateTime.Now;
                category.IsDeleted = false;

                _db.Save();
                return RedirectToAction("Index");
            }
            return View(categoryView);
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

            var catParentName = _db.Categories.Get(category.ParentCatId)?.Name;
            ViewBag.catParent = catParentName ?? "There is no parent category";
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = _db.Categories.Get(id);
            category.IsDeleted = true;
            category.UpdatedBy = User.Identity.Name;
            category.UpdatedTime = DateTime.Now;
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
