using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicCommunityApp.Models;

namespace MusicCommunityApp.Repositories
{
    public class AppIdentityDbContext : IdentityDbContext<Musician>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options) { }
    }
}
