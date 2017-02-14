using Microsoft.AspNetCore.Mvc;
using MusicCommunityApp.Repositories;
using MusicCommunityApp.Models;
using System.Collections.Generic;
using System.Linq;

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
            return View(repository.GetAllMessages().ToList());
        }

        public ViewResult AllMessages()
        {
            return View(repository.GetAllMessages().ToList());
        }

        public ViewResult MyMessages(Member me)
        {
            return View(repository.GetMessagesForMember(me));
        }

       

       


    }
}
