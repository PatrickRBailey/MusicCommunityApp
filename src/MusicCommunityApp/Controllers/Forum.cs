using Microsoft.AspNetCore.Mvc;
using MusicCommunityApp.Repositories;
using MusicCommunityApp.Models;
using System.Collections.Generic;

namespace MusicCommunityApp.Controllers
{
    public class ForumController : Controller
    {
        private IMessage repository;
        
        public ForumController(IMessage repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult AllMessages()
        {
            return View(repository.GetAllMessages());
        }

        public ViewResult MyMessages(Member me)
        {
            return View(repository.GetMessagesForMember(me));
        }

       

       


    }
}
