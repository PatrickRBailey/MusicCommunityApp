using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicCommunityApp.Models;


namespace MusicCommunityApp.Repositories
{
    public class MessageRepository : IMessage
    {
        private ApplicationDbContext context;
        public MessageRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Message> GetAllMessages()
        {
            return context.Messages.Include(m => m.From).ToList();
        }

        public IEnumerable<Message> GetMessagesForMember(Member member)
        {
            var filteredMessages = new List<Message>();
            foreach (Message m in context.Messages)
            {
              if (m.From.MemberID == member.MemberID)
              {
                filteredMessages.Add(m);
              }
            }
            return filteredMessages;
        }
    }
}
