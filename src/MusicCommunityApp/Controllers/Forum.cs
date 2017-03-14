using Microsoft.AspNetCore.Mvc;
using MusicCommunityApp.Repositories;
using MusicCommunityApp.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace MusicCommunityApp.Controllers
{
    public class ForumController : Controller
    {
        private IMessage repository;
        private UserManager<Musician> userManager;
        
        public ForumController(IMessage repo, UserManager<Musician>userMgr)
        {
            repository = repo;
            userManager = userMgr;
            
        }
        [Authorize]
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
        public ViewResult MessagesByName(string Fname, string LName)
        {
            return View("AllMessages", repository.GetAllMessages().
                Where(m => m.From.FirstName == Fname && m.From.LastName == LName).ToList());
        }

        public ViewResult MessagesBySubject(string subject)
        {
            return View("AllMessages", repository.GetAllMessages().
                Where(m => m.Subject == subject).ToList());
        }

        [HttpGet]
        [Authorize]
        public ViewResult NewMessageForm()
        {
            var message = new Models.Message();
            return View(message);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> NewMessageForm(Message m)
        {
            if (ModelState.IsValid)
            {
                var message = new Message();
                message.MessageID = m.MessageID;
                message.Subject = m.Subject;
                message.Body = m.Body;
                message.Date = DateTime.Now;
                message.EventName = m.EventName;

                string name = HttpContext.User.Identity.Name;
                message.From = await userManager.FindByNameAsync(name);
                repository.Update(message);

                return RedirectToAction("AllMessages", "Forum");
            }
            else
                return View();
        }

        [HttpGet]
        public ViewResult CommentForm(int id)
        {
            var commentVm = new CommentViewModel();
            commentVm.MessageID = id;
            commentVm.Comment = new Models.Comment();
            

            return View(commentVm);
        }

        [HttpPost]
        public IActionResult CommentForm(CommentViewModel commentVm)
        {

            Message message = (from m in repository.GetAllMessages()
                         where m.MessageID == commentVm.MessageID
                         select m).FirstOrDefault<Message>();

            message.Comments.Add(commentVm.Comment);
            repository.Update(message);

            return RedirectToAction("AllMessages", "Forum");
        }




    }
}
