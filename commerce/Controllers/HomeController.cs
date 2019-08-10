using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using commerce.Core.Models;
using commerce.Repositories;
using commerce.ViewModels;

namespace commerce.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly UnitOfWork db;

        public HomeController()
        {
            db = new UnitOfWork(new ApplicationDbContext());
        }
        public ActionResult Index()
        {
            var homeView = new HomeViewModel
            {
                CategoriesCount = db.Categories.Find(x => x.IsDeleted == false).Count(),
                CustomersCount = db.ApplicationUsers.Find(x => x.IsDeleted == false).Count(),
                OrdersCount = db.Orders.Find(x => x.IsDeleted == false).Count(),
                ProductsCount = db.Products.Find(x => x.IsDeleted == false).Count(),
                CouponsCount = db.Coupons.Find(x => x.IsDeleted == false).Count(),
                UserName = User.Identity.Name
            };
            return View(homeView);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}