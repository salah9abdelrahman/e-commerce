using System.Linq;
using System.Web.Mvc;
using commerce.Core.Models;
using commerce.Repositories;
using commerce.ViewModels;

namespace commerce.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [RouteArea("Admin")]

    public class HomeController : Controller
    {
        private readonly UnitOfWork _db;

        public HomeController()
        {
            _db = new UnitOfWork(new ApplicationDbContext());
        }
        public ActionResult Index()
        {
            var homeView = new HomeViewModel
            {
                CategoriesCount = _db.Categories.Find(x => x.IsDeleted == false).Count(),
                CustomersCount = _db.ApplicationUsers.Find(x => x.IsDeleted == false).Count(),
                OrdersCount = _db.Orders.Find(x => x.IsDeleted == false).Count(),
                ProductsCount = _db.Products.Find(x => x.IsDeleted == false).Count(),
                CouponsCount = _db.Coupons.Find(x => x.IsDeleted == false).Count(),
                UserName = User.Identity.Name
            };
            return View(homeView);
        }
    }
}