using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicCommunityApp.Models;

namespace MusicCommunityApp.Repositories
{
    public class MemberRepository : IMember
    {
        public Member CreateNewMember(string firstName, string lastName, string email)
        {
            return new Member(){FirstName=firstName, LastName=lastName, Email=email};
        }

        public List<Member> GetAllMembers()
        {
            var members = new List<Member>();
            members.Add(new Member() { FirstName = "Patrick", LastName = "Bailey",
                Email = "patrickb@blahblah.org" });
            members.Add(new Member()
            {
                FirstName = "Gob",
                LastName = "Bluth",
                Email = "gbluth@blahblah.org"
            });

            return members;
        }


    }
}
