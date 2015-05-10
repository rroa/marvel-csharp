using System.Text;
using System.Web.Mvc;
using Marvel.Api;

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