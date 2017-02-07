using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicCommunityApp.Models;

namespace MusicCommunityApp.Repositories
{
    public interface IMember
    {
        Member GetMemberByMessage(Message message);
        List<Member> GetAllMembers();

    }
}
