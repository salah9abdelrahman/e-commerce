using System.Linq;
using System.Net;
using System.Web.Mvc;
using commerce.Core;
using commerce.Core.Models;
using commerce.Repositories;

namespace commerce.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IUnitOfWork _db;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _db = unitOfWork;
        }

        // GET: Orders
        public ActionResult Index()
        {
            var orders = _db.Orders.GetOrdersWithCouponWithUser();
            return View(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = _db.Orders.Get(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }


        #region Operations by customer not admin
        // GET: Orders/Create
        //public ActionResult Create()
        //{
        //    ViewBag.CouponId = new SelectList(db.Coupons.GetAll(x => x.IsDeleted == false), "CouponId", "Code");
        //    ViewBag.UserId = new SelectList(db.ApplicationUsers.GetAll(x => x.IsDeleted == false), "Id", "FirstName");
        //    return View();
        //}

        //// POST: Orders/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "OrderDate,Total,CouponId,UserId")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        order.CreationTime = DateTime.Now;
        //        order.CreatedBy = User.Identity.Name;
        //        db.Orders.Add(order);
        //        db.Save();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.CouponId = new SelectList(db.Coupons.GetAll(x => x.IsDeleted == false), "CouponId", "Code", order.CouponId);
        //    ViewBag.UserId = new SelectList(db.ApplicationUsers.GetAll(x => x.IsDeleted == false), "Id", "FirstName", order.UserId);
        //    return View(order);
        //}


        //// GET: Orders/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = db.Orders.Get(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.CouponId = new SelectList(db.Coupons.GetAll(x => x.IsDeleted == false), "CouponId", "Code", order.CouponId);
        //    ViewBag.UserId = new SelectList(db.ApplicationUsers.GetAll(x => x.IsDeleted == false), "Id", "FirstName", order.UserId);
        //    return View(order);
        //}

        //// POST: Orders/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "OrderId,OrderDate,Total,CouponId,UserId,IsDeleted,CreatedBy,UpdatedBy,CreationTime,UpdatedTime")] Order order)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //db.Entry(order).State = EntityState.Modified;
        //        // db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.CouponId = new SelectList(db.Coupons.GetAll(x => x.IsDeleted == false), "CouponId", "Code", order.CouponId);
        //    ViewBag.UserId = new SelectList(db.ApplicationUsers.GetAll(x => x.IsDeleted == false), "Id", "FirstName", order.UserId);
        //    return View(order);
        //}

        //// GET: Orders/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Order order = db.Orders.Get(id);
        //    if (order == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(order);
        //}

        //// POST: Orders/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Order order = db.Orders.Get(id);
        //    db.Orders.Remove(order);
        //    // db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
        #endregion
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
