using System.Web.Mvc;

namespace FleetTracker.Web.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
    }
}