using System;
using System.Net;
using System.Web.Mvc;
using commerce.Core;
using commerce.Core.Models;
using commerce.Repositories;

namespace commerce.Areas.Admin.Controllers
{
    public class RolesController : Controller
    {
        private readonly IUnitOfWork _db;

        public RolesController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }


        // GET: Roles
        public ActionResult Index()
        {
            return View(_db.Roles.GetAll(x => x.IsDeleted == false));
        }

        // GET: Roles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = _db.Roles.Get(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] Role role)
        {
            if (ModelState.IsValid)
            {
                role.CreationTime = DateTime.Now;
                role.CreatedBy = User.Identity.Name;
                _db.Roles.Add(role);
                _db.Save();
                return RedirectToAction("Index");
            }

            return View(role);
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = _db.Roles.Get(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoleId,Name,CreatedBy,CreationTime")] Role role)
        {
            if (ModelState.IsValid)
            {
                var roleEdited = _db.Roles.Get(role.RoleId);
                roleEdited.Name = role.Name;
                roleEdited.RoleId = role.RoleId;
                roleEdited.CreatedBy = role.CreatedBy;
                roleEdited.CreationTime = role.CreationTime;
                roleEdited.UpdatedBy = User.Identity.Name;
                roleEdited.UpdatedTime = DateTime.Now;
                _db.Save();
                return RedirectToAction("Index");
            }
            return View(role);
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = _db.Roles.Get(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Role role = _db.Roles.Get(id);
            role.IsDeleted = true;
            role.UpdatedBy = User.Identity.Name;
            role.UpdatedTime = DateTime.Now;
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
