using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicCommunityApp.Models;

namespace MusicCommunityApp.Repositories
{
    public interface IMessage
    {
        IEnumerable<Message> GetMessagesForMember(Musician musician);
        IQueryable<Message> GetAllMessages();
        int Update(Message message);

    }
}
