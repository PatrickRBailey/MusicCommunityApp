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

        public IQueryable<Message> GetAllMessages()
        {
            // Include Musician might be missing
            return context.Messages.Include(m => m.From).Include(m => m.Comments);
        }


        public IEnumerable<Message> GetMessagesForMember(Member member)
        {
            var filteredMessages = new List<Message>();
            foreach (Message m in context.Messages)
            {
              if (m.From.MusicianID == member.MemberID)
              {
                filteredMessages.Add(m);
              }
            }
            return filteredMessages;
        }
        public int Update (Message message)
        {
            if (message.MessageID == 0)
                context.Messages.Add(message);
            else
                context.Messages.Update(message);

            return context.SaveChanges();

        }
    }
}
