using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicCommunityApp.Models
{
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public List<string> Instruments { get; set; }
        public List<Message> Messages { get; set; }
    }
}
