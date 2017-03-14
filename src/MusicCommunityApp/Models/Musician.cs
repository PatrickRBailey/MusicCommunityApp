using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MusicCommunityApp.Models
{
    public class Musician : IdentityUser
    {
        public int MusicianID { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
