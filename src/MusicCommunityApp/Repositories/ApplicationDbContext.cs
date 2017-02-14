using Microsoft.EntityFrameworkCore;
using MusicCommunityApp.Models;

namespace MusicCommunityApp.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts)
        : base(opts) { }

        public DbSet<Message> Messages {get; set;}
        public DbSet<Member> Members {get; set;}
    }
}