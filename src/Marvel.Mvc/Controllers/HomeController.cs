using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Marvel.Api;
using Marvel.Api.Filters;

namespace Marvel.Mvc.Controllers
{
    public class NameViewModel
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }

    public class ResultViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
    }

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
            List<ResultViewModel> results;

            if (postdata.Type.ToLower() == "character")
            {
                var filter = new CharacterRequestFilter { NameStartsWith = postdata.Name };
                filter.OrderBy(OrderResult.NameAscending);
                filter.Limit = 40;

                var response = client.GetCharacters(filter);

                results =
                    response.Data.Results.Select(res =>
                        new ResultViewModel { Id = res.Id, Name = res.Name, Url = res.Urls.FirstOrDefault(t => t.Type == "detail").URL }).ToList();
            }
            else
            {
                var filter = new ComicRequestFilter { TitleStartsWith = postdata.Name };
                filter.OrderBy(OrderResult.NameAscending);
                filter.Limit = 40;

                var response = client.GetComics(filter);

                results =
                    response.Data.Results.Select(res =>
                        new ResultViewModel { Id = res.Id, Name = res.Title, Url = res.Urls.FirstOrDefault(t => t.Type == "detail").URL }).ToList();
            }

            return Json(results);
        }
    }
}