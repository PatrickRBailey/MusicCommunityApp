using Microsoft.AspNetCore.Mvc;
using System;
using MusicCommunityApp.Repositories;

namespace MusicCommunityApp.Controllers
{
    public class HomeController : Controller
    {
        private IMember repository;
        public HomeController(IMember repo)
        {
            repository = repo;
        }
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

        public ViewResult Members()
        {
            return View(repository.GetAllMembers());
        }
    }
}
