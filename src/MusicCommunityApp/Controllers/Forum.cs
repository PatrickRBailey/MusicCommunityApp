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
            var repo = new MessageRepository();
            var messages = repo.GetAllMessages();
            return View(messages);
        }

        public ViewResult MyMessages()
        {
            MemberRepository memberRepo = new MemberRepository();
            MemberController controller = new MemberController(memberRepo);
            List<Member> members = controller.AllMembers().ViewData.Model as List<Member>;

            Member user = members[0];
            var repo = new MessageRepository();
            var messages = repo.GetMessagesForMember(user);
            return View(messages);
        }

       

       


    }
}
