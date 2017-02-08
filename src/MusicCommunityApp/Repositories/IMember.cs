using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicCommunityApp.Models;

namespace MusicCommunityApp.Repositories
{
    public interface IMember
    {
        Member CreateNewMember(string firstName, string lastName, string email);
        List<Member> GetAllMembers();

    }
}
