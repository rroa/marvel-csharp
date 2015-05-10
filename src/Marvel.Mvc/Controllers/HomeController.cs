using System.Web.Mvc;

namespace Marvel.Mvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {            
            return Content("Hello");
        }
    }
}