using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Marvel.Api;
using Marvel.Api.Filters;
using Marvel.Mvc.Models;

namespace Marvel.Mvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        public JsonResult SomeActionMethod(NameViewModel postdata)
        {
            const string apiKey = "YOUR API PUBLIC KEY";
            const string privateKey = "YOUR API PRIVATE KEY";

            var client = new MarvelRestClient(apiKey, privateKey);
            List<ResultViewModel> results = null;

            if (postdata.Type.ToLower() == "character")
            {
                var filter = new CharacterRequestFilter { NameStartsWith = postdata.Name };
                filter.OrderBy(OrderResult.NameAscending);
                filter.Limit = 40;

                var response = client.GetCharacters(filter);

                if (response.Code == "200")
                {
                    results =
                    response.Data.Results.Select(res =>
                        new ResultViewModel { Id = res.Id, Name = res.Name, Url = res.Urls.FirstOrDefault(t => t.Type == "detail").URL }).ToList();
                }
            }
            else
            {
                var filter = new ComicRequestFilter { TitleStartsWith = postdata.Name };
                filter.OrderBy(OrderResult.NameAscending);
                filter.Limit = 40;

                var response = client.GetComics(filter);

                if (response.Code == "200")
                {
                    results =
                    response.Data.Results.Select(res =>
                        new ResultViewModel { Id = res.Id, Name = res.Title, Url = res.Urls.FirstOrDefault(t => t.Type == "detail").URL }).ToList();
                }
            }
            return Json(results);
        }
    }
}