using Microsoft.AspNetCore.Mvc;
using MusicCommunityApp.Repositories;
using MusicCommunityApp.Models;
using System.Collections.Generic;
using System.Linq;
using System;

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
        public ViewResult MessagesByName(string Fname, string LName)
        {
            return View("Index", repository.GetAllMessages().
                Where(m => m.From.FirstName == Fname && m.From.LastName == LName).ToList());
        }

        public ViewResult MessagesBySubject(string subject)
        {
            return View("Index", repository.GetAllMessages().
                Where(m => m.Subject == subject).ToList());
        }

        [HttpGet]
        public ViewResult NewMessageForm()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult NewMessageForm(int id, string subject, string body, string eventName)
        {
            var member = new Member { FirstName = "Jack", LastName = "Johnson" };
            var message = new Message();
            message.MessageID = id;
            message.Subject = subject;
            message.Body = body;
            message.Date = DateTime.Now;
            message.EventName = eventName;
            message.From = member;
            repository.Update(message);

            return RedirectToAction("AllMessages", "Forum");
        }

       

       


    }
}
