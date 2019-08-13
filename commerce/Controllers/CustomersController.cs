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
    public class CustomersController : Controller
    {
        private readonly UnitOfWork db;
        public CustomersController()
        {
            db = new UnitOfWork(new ApplicationDbContext());
        }

        // GET: Customers
        public ActionResult Index()
        {
            var applicationUsers = db.ApplicationUsers.GetApplicationUsersWithRole();
            var customersView = new List<CustomerViewModel>();
            foreach (var customer in applicationUsers)
            {
                var cvm = new CustomerViewModel
                {
                    CreationTime = customer.CreationTime,
                    Email = customer.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber,
                    RegisterAs = customer.Role.Name,
                    UpdatedTime = customer.UpdatedTime,
                    UserId = customer.Id,
                    UserName = customer.UserName
                };
                customersView.Add(cvm);
            }
            return View(customersView);
        }

        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.ApplicationUsers.Get(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        //comment because you can create a customer by register it
        #region Create and edit Customer functions

        // GET: Customers/Create
        //public ActionResult Create()
        //{
        //    ViewBag.RoleId = new SelectList(db.Roles.GetAll(x => x.IsDeleted == false), "RoleId", "Name");
        //    return View();
        //}

        //// POST: Customers/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,FirstName,LastName,RoleId,CreationTime,UpdatedTime,IsDeleted,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.ApplicationUsers.Add(applicationUser);
        //        db.Save();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.RoleId = new SelectList(db.Roles.GetAll(x => x.IsDeleted == false), "RoleId", "Name", applicationUser.RoleId);
        //    return View(applicationUser);
        //} 

        // GET: Customers/Edit/5
        //public ActionResult Edit(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    ApplicationUser applicationUser = db.ApplicationUsers.Get(id);
        //    if (applicationUser == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.RoleId = new SelectList(db.Roles.GetAll(x => x.IsDeleted == false), "RoleId", "Name", applicationUser.RoleId);
        //    return View(applicationUser);
        //}

        //// POST: Customers/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,RoleId,CreationTime,UpdatedTime,IsDeleted,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] ApplicationUser applicationUser)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //db.Entry(applicationUser).State = EntityState.Modified;
        //        db.Save();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.RoleId = new SelectList(db.Roles.GetAll(x => x.IsDeleted == false), "RoleId", "Name", applicationUser.RoleId);
        //    return View(applicationUser);
        //}
        #endregion 

        // GET: Customers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.ApplicationUsers.Get(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            var customerView = new CustomerViewModel
            {
                CreationTime = applicationUser.CreationTime,
                Email = applicationUser.Email,
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                PhoneNumber = applicationUser.PhoneNumber,
                RegisterAs = applicationUser.Role.Name,
                UpdatedTime = applicationUser.UpdatedTime,
                UserId = applicationUser.Id,
                UserName = applicationUser.UserName
            };

            return View(customerView);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.ApplicationUsers.Get(id);
            db.ApplicationUsers.Remove(applicationUser);
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
