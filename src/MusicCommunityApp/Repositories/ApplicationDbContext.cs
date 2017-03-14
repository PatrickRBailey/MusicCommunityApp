using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserRole<string>>();
            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityUser<string>>();
        }

        //TODO: Look at Brians code for OnModelCreating
        //TODO: Use Brians Branch ReviewByReader as a guide
        //TODO: Use Brian's Branch Authorization to see how to add roles
    }
}