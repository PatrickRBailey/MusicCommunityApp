using Microsoft.AspNetCore.Mvc;
using MusicCommunityApp.Repositories;
using MusicCommunityApp.Models;

namespace MusicCommunityApp.Controllers
{
    public class MemberController : Controller
    {
        private IMember repository;

        public MemberController(IMember repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View();
        }

         public ViewResult AllMembers()
        {
            var repo = new MemberRepository();
            var members = repo.GetAllMembers();
            return View(members);
        }

        public ViewResult CreateNewMember()
        {
            var repo = new MemberRepository();
            var newMember = repo.CreateNewMember("Luke" ,"Skywalker" ,"Skywalkersound@gmail.com");
            return View(newMember);
        }
       
    }
}