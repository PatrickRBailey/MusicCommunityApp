using Microsoft.AspNetCore.Mvc;
using System;

namespace CommunityWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.Date = DateTime.Now.ToString("MM/dd/yyyy");
            return View();
        }

        public ViewResult About()
        {
            return View();
        }
        [Route("Home/About/Contact")]
        public ActionResult Contact()
        {
            return View();
        }

        public ViewResult History()
        {
            return View();
        }
    }
}