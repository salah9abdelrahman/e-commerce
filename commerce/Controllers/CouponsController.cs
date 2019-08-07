﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using commerce.Core.Models;
using commerce.Repositories;

namespace commerce.Controllers
{
    public class CouponsController : Controller
    {
        private readonly UnitOfWork db;
        public CouponsController()
        {
            db = new UnitOfWork(new ApplicationDbContext());
        }

        // GET: Coupons
        public ActionResult Index()
        {
            return View(db.Coupons.GetAll(x => x.IsDeleted == false));
        }

        // GET: Coupons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupon coupon = db.Coupons.Get(id);
            if (coupon == null)
            {
                return HttpNotFound();
            }
            return View(coupon);
        }

        // GET: Coupons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coupons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CouponId,Code,Description,Active,Value,StartDate,EndDate")]
        Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                coupon.CreationTime = DateTime.Now;
                coupon.CreatedBy = User.Identity.Name;
                db.Coupons.Add(coupon);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(coupon);
        }

        // GET: Coupons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupon coupon = db.Coupons.Get(id);
            if (coupon == null)
            {
                return HttpNotFound();
            }
            return View(coupon);
        }

        // POST: Coupons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = @"CouponId,Code,Description,Active,Value,
                    StartDate,EndDate,CreatedBy,CreationTime")] Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                var _coupon = db.Coupons.Get(coupon.CouponId);
                _coupon.CouponId = coupon.CouponId;
                _coupon.Code = coupon.Code;
                _coupon.Active = coupon.Active;
                _coupon.Description = coupon.Description;
                _coupon.Value = coupon.Value;
                _coupon.StartDate = coupon.StartDate;
                _coupon.CreatedBy = coupon.CreatedBy;
                _coupon.CreationTime = coupon.CreationTime;
                _coupon.UpdatedBy = User.Identity.Name;
                _coupon.UpdatedTime = DateTime.Now;
                db.Save();
                return RedirectToAction("Index");
            }
            return View(coupon);
        }

        // GET: Coupons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Coupon coupon = db.Coupons.Get(id);
            if (coupon == null)
            {
                return HttpNotFound();
            }
            return View(coupon);
        }

        // POST: Coupons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Coupon coupon = db.Coupons.Get(id);
            coupon.IsDeleted = true;
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
