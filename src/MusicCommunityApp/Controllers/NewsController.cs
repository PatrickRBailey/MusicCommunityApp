using Microsoft.AspNetCore.Mvc;

namespace CommunityWebsite.Controllers{
    public class NewsController : Controller {
        public ViewResult Index()
        {
            return View();
        }
        public ViewResult Today()
        {
            return View();
        }
        public ViewResult Archive()
        {
            return View();
        }
    }
}
