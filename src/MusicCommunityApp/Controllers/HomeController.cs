using Microsoft.AspNetCore.Mvc;
using System;
using MusicCommunityApp.Repositories;
using Microsoft.AspNetCore.Authorization;
using MusicCommunityApp.Models;

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
            var musicianVm = new MusicianViewModel { Authenticated = false };
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                musicianVm.FirstName = HttpContext.User.Identity.Name;
                musicianVm.Authenticated = true;
            }
            return View(musicianVm);
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
