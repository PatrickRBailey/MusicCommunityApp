using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicCommunityApp.Models;

namespace MusicCommunityApp.Repositories
{
    public interface IMessage
    {
        IEnumerable<Message> GetMessagesForMember(Member member);
        IEnumerable<Message> GetAllMessages();
        int Update(Message message);

    }
}
