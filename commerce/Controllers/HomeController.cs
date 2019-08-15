using System.Web.Mvc;

namespace commerce.Controllers
{
    //[RouteArea("User")]
    public class HomeController : Controller
    {
        // GET: User/Home
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
    }
}