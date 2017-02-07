using Microsoft.AspNetCore.Mvc;
using MusicCommunityApp.Repositories;
using MusicCommunityApp.Models;

//TODO: Change the Controller methods to make more sense to fit a forum...ie CRUD stuff
//TODO: Create a member Controller in order to test controller methods

namespace MusicCommunityApp.Controllers
{
    public class ForumController : Controller
    {
        private IMessage repository;
        private Member user = new Member(){FirstName="Luke", LastName="Skywalker", Email="usetheforce@gmail.com"};
        private Message message = new Message() {Subject = "Hey", Body = "How are you doing today?"};
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
