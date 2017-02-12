using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicCommunityApp.Models;

namespace MusicCommunityApp.Repositories
{
    public class MemberRepository : IMember
    {
        private ApplicationDbContext context;
        public MemberRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public Member CreateNewMember(string firstName, string lastName, string email)
        {
            return new Member(){FirstName=firstName, LastName=lastName, Email=email};
        }

        public List<Member> GetAllMembers()
        {
           return context.Members.ToList();
        }


    }
}
