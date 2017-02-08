using Microsoft.AspNetCore.Mvc;
using MusicCommunityApp.Repositories;
using MusicCommunityApp.Models;


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
            var repo = new MessageRepository();
            var messages = repo.GetAllMessages();
            return View(messages);
        }

        public ViewResult MyMessages()
        {
            Member user = new Member(){FirstName="Luke", LastName="Skywalker", Email="usetheforce@gmail.com"};
            var repo = new MessageRepository();
            var messages = repo.GetMessagesForMember(user);
            return View(messages);
        }

       

       


    }
}
