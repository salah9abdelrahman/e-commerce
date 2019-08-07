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

namespace commerce.Controllers
{
    public class TransactionsController : Controller
    {
        private UnitOfWork db;
        public TransactionsController()
        {
            db = new UnitOfWork(new ApplicationDbContext());
        }

        // GET: Transactions
        public ActionResult Index()
        {
            var transactions = db.Transactions.GetTransactionsWithOrder();
            return View(transactions.ToList());
        }

        // GET: Transactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = db.Transactions.Get(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }
        //#region Will made by customer
        //// GET: Transactions/Create
        //public ActionResult Create()
        //{
        //    ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "UserId");
        //    return View();
        //}

        //// POST: Transactions/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "TransactionId,TransDate,Amount,OrderId,IsDeleted,CreatedBy,UpdatedBy,CreationTime,UpdatedTime")] Transaction transaction)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Transactions.Add(transaction);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "UserId", transaction.OrderId);
        //    return View(transaction);
        //}

        //// GET: Transactions/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Transaction transaction = db.Transactions.Find(id);
        //    if (transaction == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "UserId", transaction.OrderId);
        //    return View(transaction);
        //}

        //// POST: Transactions/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "TransactionId,TransDate,Amount,OrderId,IsDeleted,CreatedBy,UpdatedBy,CreationTime,UpdatedTime")] Transaction transaction)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(transaction).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.OrderId = new SelectList(db.Orders, "OrderId", "UserId", transaction.OrderId);
        //    return View(transaction);
        //}

        //// GET: Transactions/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Transaction transaction = db.Transactions.Find(id);
        //    if (transaction == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(transaction);
        //}

        //// POST: Transactions/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Transaction transaction = db.Transactions.Find(id);
        //    db.Transactions.Remove(transaction);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        //#endregion
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
