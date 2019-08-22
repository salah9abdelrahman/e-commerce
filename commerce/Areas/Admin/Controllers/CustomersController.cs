using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using commerce.Core.Models;
using commerce.Repositories;
using commerce.ViewModels;

namespace commerce.Areas.Admin.Controllers
{
    public class CustomersController : Controller
    {
        private readonly UnitOfWork _db;
        public CustomersController()
        {
            _db = new UnitOfWork(new ApplicationDbContext());
        }

        // GET: Customers
        public ActionResult Index()
        {
            var applicationUsers = _db.ApplicationUsers.GetApplicationUsersWithRole();
            var customersView = new List<CustomerViewModel>();
            foreach (var customer in applicationUsers)
            {

                customersView.Add(new CustomerViewModel
                {
                    CreationTime = customer.CreationTime,
                    Email = customer.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber,
                    UpdatedTime = customer.UpdatedTime,
                    UserId = customer.Id,
                    UserName = customer.UserName,
                    RoleId = customer.RoleId
                    //cvm.RegisterAs = customer.Role.Name;

                });
            }
            return View(customersView);
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
            ApplicationUser applicationUser = _db.ApplicationUsers.Get(id);
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
                UpdatedTime = applicationUser.UpdatedTime,
                UserId = applicationUser.Id,
                UserName = applicationUser.UserName
                //RegisterAs = applicationUser.Role.Name,
            };
            return View(customerView);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = _db.ApplicationUsers.Get(id);
            _db.ApplicationUsers.Remove(applicationUser);
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
