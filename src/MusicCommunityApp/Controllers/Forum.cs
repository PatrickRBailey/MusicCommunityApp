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
        private Message message = new Message() {Subject = "Hey", Body = "How are you doing today?"};
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

        public ViewResult AllMembers()
        {
            var repo = new MemberRepository();
            var members = repo.GetAllMembers();
            return View(members);
        }

        public ViewResult Member()
        {
            message.From = user;
            var repo = new MemberRepository();
            var member = repo.GetMemberByMessage(message);
            return View(member);
        }


    }
}
