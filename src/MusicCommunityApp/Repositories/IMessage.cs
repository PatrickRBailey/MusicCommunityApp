using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicCommunityApp.Models;

namespace MusicCommunityApp.Repositories
{
    public interface IMessage
    {
        List<Message> GetMessagesForMember(Member member);
        List<Message> GetAllMessages();

    }
}
