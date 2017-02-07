using Microsoft.AspNetCore.Mvc;
using MusicCommunityApp.Repositories;
using MusicCommunityApp.Models;

namespace MusicCommunityApp.Controllers
{
    public class ForumController : Controller
    {
        private IMessage messageRepo;
        private IMember memberRepo;
        private Member user = new Member(){FirstName="Luke", LastName="Skywalker", Email="usetheforce@gmail.com"};
        public ForumController(IMessage messRepo, IMember memRepo)
        {
            messageRepo = messRepo;
            memberRepo = memRepo;
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
            var repo = new MessageRepository();
            var messages = repo.GetMessagesForMember(user);
            return View(messages);
        }


    }
}
